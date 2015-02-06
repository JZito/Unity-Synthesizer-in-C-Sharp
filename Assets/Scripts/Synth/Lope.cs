using UnityEngine;
using System.Collections;

public class Lope : MonoBehaviour {
	public SynthConfigure synthConfig;
    public float attack = 0.003f;
    public float release = 0.2f;
    public float current = 0.0f;
    public bool sustain = false;
    public float amplifier = 1.0f;

    public float delta = 0.0f;

    void Start() {
    	synthConfig = GetComponent<SynthConfigure>();
    }

    public Lope() {
    }

    public  Lope(Lope src, float init) {
        attack = src.attack;
        release = src.release;
        current = init;
        sustain = src.sustain;
        amplifier = src.amplifier;
    }

    public void KeyOn() {
        delta = 1.0f / (attack * synthConfig.kSampleRate );
    }

    public void KeyOff() {
        delta = -1.0f / (release * synthConfig.kSampleRate );
    }

    public void Update() {
        if (delta > 0.0f) {
            current += delta;
            if (current >= 1.0f) {
                current = 1.0f;
                if (!sustain) KeyOff();
            }
        } else {
            current = Mathf.Max(current + delta, 0.0f);
        }
    }

    public float GetLevel() {
        return current * amplifier;
    }
}
