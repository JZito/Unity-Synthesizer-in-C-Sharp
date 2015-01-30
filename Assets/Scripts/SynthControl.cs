using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (AudioSource))]

public class SynthControl : MonoBehaviour {


//	  [System.Serializable]

public SynthModule synthMod0;
public SynthModule synthMod1;
public SynthConfigure synthConfig;
public Lope modEnv;
//public SynthModule synthMod;
public GameObject synthMod;
	//@Range(0.0, 1.0)    var volume = 0.5;
[Range(0.0f, 1.0f)] public float volume = 0.5f;
//@Range(-1.0, 1.0)   var stereo = 0.5;
[Range(-1.0f, 1.0f)] public float stereo = 0.5f;
//@Range(1, 24)       var fm_mul = 8;
[Range(1, 24f)] public float fm_mul = 8f;
//@Range(0.0, 1.0)    var fm_mod = 0.08;
[Range(0.0f, 1.0f)] public float fm_mod = 0.08f;
//@Range(1, 16)       var bit_int = 3;
[Range(1f, 16f)] public float bit_int = 3f;
//@Range(0.0, 1.0)    var bit_mix = 0.2;
[Range(0.0f, 1.0f)] public float bit_mix = 0.2f;

private GameObject[] modules = new GameObject[2];

private int switcher = 0;

void Awake()
{
    modules[0] = synthMod;
    modules[1] = synthMod;
}

void Start() {
//var     synthOut = GetComponent<AudioSource>();
    synthConfig = GetComponent<SynthConfigure>();
    modEnv = GetComponent<Lope>();
    synthMod0 = modules[0].GetComponent<SynthModule>();
    synthMod1 = modules[1].GetComponent<SynthModule>();
    //audioClip myClip = AudioClip.Create("(null)", 0xfffffff, 1, SynthConfig.kSampleRate, false, true, function(data:float[]){});
//  AudioClip myClip = AudioClip.Create("(null)", 0xfffffff, 1, synthConfig.kSampleRate, false, true, OnAudioFilterRead(float[] data, int channels));
//  audio.clip = myClip;
   // audio.clip = myClip;
//  audio.Play();
    
}

void Update() {
    foreach (var mod in modules) mod.GetComponent<SynthModule>().SetParam(fm_mul, fm_mod, bit_int, bit_mix);
}

public Lope KeyOn(int note, Lope env) {

    switcher = (switcher + 1) & 1;
    var module = modules[switcher];
    var    synthModule = module.GetComponent<SynthModule>();
    
//    synthModule.env = new Lope(env, synthModule.env.current);
    synthModule.osc.SetNote(note);
    synthModule.env.KeyOn();
   	modEnv = synthModule.env;
    return modEnv;
}



void OnAudioFilterRead(float[] data, int channels) {
    float lv = volume * 0.5f * (stereo + 1f);
    float rv = volume - lv;
    for (var i = 0; i < data.Length; i += 2) {
        float s1 = synthMod0.Run();
        float s2 = synthMod1.Run();
        data[i    ] = s1 * lv + s2 * rv;
        data[i + 1] = s1 * rv + s2 * lv;
    }
}
}
