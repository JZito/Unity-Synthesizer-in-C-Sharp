// CCRMA's NRev reverberator class, based on CCRMA STK library.
// https://ccrma.stanford.edu/software/stk/

using UnityEngine;
using System.Collections;

public class NReverb : MonoBehaviour
{
    // T60 decay time.
    [Range(0.0f, 4.0f)]
    public float
        decayTime = 1.0f;

    // Wet signal ratio.
    [Range(0.0f, 1.0f)]
    public float
        wetMix = 0.1f;

    // Delay lines.
    DelayLine[] allpassLines;
    DelayLine[] combLines;

    // Filter coefficients.
    float allpassCoeff = 0.7f;
    float[] combCoeffs;

    // Lowpass filter state.
    float lowpassState;

    // Used for error handling.
    string error;

    void UpdateParameters ()
    {
        float scaler = -3.0f / (decayTime * AudioSettings.outputSampleRate);
        for (var i = 0; i < 6; i++) {
            combCoeffs [i] = Mathf.Pow (10.0f, scaler * combLines [i].Length);
        }
    }

    void Awake ()
    {
        allpassLines = new DelayLine[6];
        combLines = new DelayLine[6];
        combCoeffs = new float[6];

        int[] delays = {
            1433, 1601, 1867, 2053, 2251, 2399,
            347, 113, 37, 59, 53, 43
        };
        
        float scaler = AudioSettings.outputSampleRate / 25641.0f;
        for (var i = 0; i < delays.Length; i++) {
            var delay = Mathf.FloorToInt (scaler * delays [i]);
            if ((delay & 1) == 0)
                delay++;
            while (!MathUtil.IsPrime(delay))
                delay += 2;
            delays [i] = delay;
        }
        
        for (var i = 0; i < 6; i++) {
            combLines [i] = new DelayLine (delays [i]);
        }
        
        for (var i = 0; i < 6; i++) {
            allpassLines [i] = new DelayLine (delays [i + 6]);
        }

        UpdateParameters ();
    }

    void Update ()
    {
        if (error == null) {
            UpdateParameters ();
        } else {
            Debug.LogError (error);
            Destroy (this);
        }
    }
    
    void OnAudioFilterRead (float[] data, int channels)
    {
        if (channels != 2) {
            error = "This filter only supports stereo audio (given:" + channels + ")";
            return;
        }
        
        for (var offset = 0; offset < data.Length; offset += 2) {
            var input = 0.5f * (data [offset] + data [offset + 1]);

            var temp0 = 0.0f;
            for (var i = 0; i < 6; i++) {
                temp0 += combLines [i].Tick (input + combCoeffs [i] * combLines [i].Last);
            }

            for (var i = 0; i < 3; i++) {
                var temp1 = temp0 + allpassCoeff * allpassLines [i].Last;
                temp0 = allpassLines [i].Tick (temp1) - allpassCoeff * temp1;
            }

            // One-pole lowpass filter.
            lowpassState = 0.7f * lowpassState + 0.3f * temp0;
            var temp2 = lowpassState + allpassCoeff * allpassLines [3].Last;
            temp2 = allpassLines [3].Tick (temp2) - allpassCoeff * temp2;

            var out1 = temp2 + allpassCoeff * allpassLines [4].Last;
            var out2 = temp2 + allpassCoeff * allpassLines [5].Last;

            out1 = allpassLines [4].Tick (out1) - allpassCoeff * out1;
            out2 = allpassLines [5].Tick (out2) - allpassCoeff * out2;

            out1 = wetMix * out1 + (1.0f - wetMix) * data [offset];
            out2 = wetMix * out2 + (1.0f - wetMix) * data [offset + 1];
            
            data [offset] = out1;
            data [offset + 1] = out2;
        }
    }
}
