using UnityEngine;
using System.Collections;

public class Osc : MonoBehaviour {
	public SynthConfigure synthConfig;
	public float multiplier = 1.0f;
	public float modulation = 0.0f;

	private float mx = 0.0f;
	private float cx = 0.0f;
	private float step = 0.0f;

	static private float kPi = 3.14159265359f;
	static private float kPi2 = 6.28318530718f;
	static private float k4dPi = 1.27323954474f;
	static private float k4dPiPi = 0.40528473456f;

	void Start (){
		synthConfig = GetComponent<SynthConfigure>();
	}

	// http://devmaster.net/forums/topic/4648-fast-and-accurate-sinecosine/
	static private float fast_sin(float x) {
		x -= kPi;
		x = k4dPi * x - k4dPiPi * x * Mathf.Abs(x);
        return -0.225f * (x * Mathf.Abs(x) - x) - x;
	}
	
	public void SetNote(float note) {
		float freq = 440.0f * Mathf.Pow(2.0f, 1.0f * (note - 69f) / 12.0f);
		step = freq / synthConfig.kSampleRate;
	}
	
	public float Run() {
		mx += step * multiplier;
		cx += step;
		mx -= Mathf.Floor(mx);
		cx -= Mathf.Floor(cx);
		var x = cx + modulation * fast_sin(kPi2 * mx);
		x -= Mathf.Floor(x);
		return fast_sin(kPi2 * x);
	}
}
