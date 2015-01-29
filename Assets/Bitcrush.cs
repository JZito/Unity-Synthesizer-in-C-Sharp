using UnityEngine;
using System.Collections;

public class Bitcrush : MonoBehaviour {
	private float counter = 0f;
    private float sampled = 0.0f;

    public float interval = 4f;
    public float mix = 1.0f;

    public float Run(float input) {
        if (counter++ % interval == 0f) {
            sampled = input;
        }
        return input * (1.0f - mix) + sampled * mix;
    }
}
