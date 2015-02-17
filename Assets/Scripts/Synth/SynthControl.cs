using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (AudioSource))]

public class SynthControl : MonoBehaviour {



public SynthModule synthMod0;
public SynthModule synthMod1;
public SynthConfigure synthConfig;
public Lope modEnv;
public GameObject synthMod;

[Range(0.0f, 1.0f)] public float volume = 0.5f;
[Range(-1.0f, 1.0f)] public float stereo = 0.5f;
[Range(1, 24f)] public float fm_mul = 8f;
[Range(0.0f, 1.0f)] public float fm_mod = 0.08f;
[Range(1f, 16f)] public float bit_int = 3f;
[Range(0.0f, 1.0f)] public float bit_mix = 0.2f;

private GameObject[] modules = new GameObject[2];

private int switcher = 0;

void Awake()
{
//	synthMod0 = synthMod.GetComponent<SynthModule> ();
	modules[0] = synthMod;
	modules[1] = synthMod;
	synthMod0 = modules[0].GetComponent<SynthModule>();
	synthMod1 = modules[1].GetComponent<SynthModule>();
}

void Start() {
    synthConfig = GetComponent<SynthConfigure>();
    modEnv = GetComponent<Lope>();
	
  
}

void Update() {

  //  foreach (var mod in modules) mod.GetComponent<SynthModule>().SetParam(fm_mul, fm_mod, bit_int, bit_mix);
		for (int i = 0; i < modules.Length; i++) {
			var mod = modules [i].GetComponent<SynthModule>();
			mod.SetParam(fm_mul, fm_mod, bit_int, bit_mix);
			}

		//	synthMod0.SetParam (fm_mul, fm_mod, bit_int, bit_mix);
}

public Lope KeyOn(int note, Lope env) {
	switcher = (switcher + 1) & 1;
   var module = modules[switcher];
    var    synthModule = module.GetComponent<SynthModule>();
    synthModule.osc.SetNote(note);
    synthModule.env.KeyOn();
   	modEnv = synthModule.env;
//	Debug.Log ("switcher" + switcher);
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
