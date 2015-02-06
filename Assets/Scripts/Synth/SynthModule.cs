using UnityEngine;
using System.Collections;

public class SynthModule : MonoBehaviour {
    public GameObject synth;
	public Osc osc;
    public Lope env;
    public Bitcrush bit;
    public float level;

    public void Awake () {
        osc = synth.GetComponent<Osc>();
        env = synth.GetComponent<Lope>();
        bit = synth.GetComponent<Bitcrush>();
    }

    public void SetParam(float fm_mul, float  fm_mod, float bit_int, float bit_mix) {
        osc.multiplier = fm_mul;
        osc.modulation = fm_mod;
        bit.interval = bit_int;
        bit.mix = bit_mix;
    }

    public float Run() {
        level = bit.Run(osc.Run() * env.GetLevel());
        env.Update();
        return level;
    }
}