#pragma strict

@script RequireComponent(AudioSource)

@Range(0.0, 1.0)    var volume = 0.5;
@Range(-1.0, 1.0)   var stereo = 0.5;
@Range(1, 24)       var fm_mul = 8;
@Range(0.0, 1.0)    var fm_mod = 0.08;
@Range(1, 16)       var bit_int = 3;
@Range(0.0, 1.0)    var bit_mix = 0.2;

class SynthModule {
    var osc = Oscillator();
    var env = Envelope();
    var bit = Bitcrusher();

    function SetParam(fm_mul : int, fm_mod : float, bit_int : int, bit_mix : float) {
        osc.multiplier = fm_mul;
        osc.modulation = fm_mod;
        bit.interval = bit_int;
        bit.mix = bit_mix;
    }

    function Run() {
        var level = bit.Run(osc.Run() * env.GetLevel());
        env.Update();
        return level;
    }
}

private var modules = [SynthModule(), SynthModule()];
private var switcher = 0;

function Start() {
    audio.clip = AudioClip.Create("(null)", 0xfffffff, 1, SynthConfig.kSampleRate, false, true, function(data:float[]){});
    audio.Play();
}

function Update() {
    for (var mod in modules) mod.SetParam(fm_mul, fm_mod, bit_int, bit_mix);
}

function KeyOn(note : int, env : Envelope) {
    switcher = (switcher + 1) & 1;
    var module = modules[switcher];

    module.env = Envelope(env, module.env.current);
    module.osc.SetNote(note);
    module.env.KeyOn();

    return module.env;
}

function OnAudioFilterRead(data : float[], channels : int) {
    var lv = volume * 0.5 * (stereo + 1);
    var rv = volume - lv;
    for (var i = 0; i < data.Length; i += 2) {
        var s1 = modules[0].Run();
        var s2 = modules[1].Run();
        data[i    ] = s1 * lv + s2 * rv;
        data[i + 1] = s1 * rv + s2 * lv;
    }
}
