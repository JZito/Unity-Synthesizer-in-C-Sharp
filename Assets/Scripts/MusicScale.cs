using UnityEngine;
using System.Collections;

public class MusicScale : MonoBehaviour {

//static private var intervals0 = [0f, 2f, 4f, 7f, 9f, 11f]; // 
	public int[] intervals0;
//	static private var intervals1 = [0f, 7f];				 // 1th + 5th
//////////	private float[] intervals1 = float[0f, 7f];

	// private var base = 0;
	private int baseNote = 0;
	// private var octave_offset = 0;
	private int octave_offset = 0;
	// private var intervals = intervals0;

//currently msuicalscale(41, 0)
	public void MusicalScale(int aBase) {
		octave_offset = aBase / 12;
		baseNote = aBase % 12;
		Debug.Log (baseNote + "base");
		Debug.Log (octave_offset + "octave offset");
	/////////////	if (aType) intervals = intervals1;
	}

	public int GetNote(int degree) {
		degree = Mathf.Max(0, degree + intervals0.Length * octave_offset);
		return baseNote + 12 * (degree / intervals0.Length) + intervals0[degree % intervals0.Length];
	}
}
