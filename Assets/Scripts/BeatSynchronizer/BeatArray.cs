using UnityEngine;
using System.Collections;

public class BeatArray : MonoBehaviour {
	
	public Vector3[] wholeNote;
	public Vector3[] halfNote;
	public Vector3[] quarterNote;
	public Vector3[] eighthNote;
	public Vector3[] sixteenthNote;
	public Vector3[][] arrayOfBeats = new Vector3[5][];
	
	// Use this for initialization
	void Awake () {
		//arrayOfArrays = 
		arrayOfBeats [0] = wholeNote;
		arrayOfBeats [1] = halfNote;
		arrayOfBeats [2] = quarterNote;
		arrayOfBeats [3] = eighthNote;
		arrayOfBeats [4] = sixteenthNote;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}