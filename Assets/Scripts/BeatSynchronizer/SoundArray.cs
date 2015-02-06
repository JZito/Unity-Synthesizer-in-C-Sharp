using UnityEngine;
using System.Collections;

public class SoundArray : MonoBehaviour {
	
	public AudioClip[] bells;
	public AudioClip[] kicks;
	public AudioClip[] snares;
	public AudioClip[] perc;
	public AudioClip[] melody;
	public AudioClip[][] arrayOfArrays = new AudioClip[5][];

	// Use this for initialization
	void Awake () {
		//arrayOfArrays = 
		arrayOfArrays [0] = bells;
		arrayOfArrays [1] = kicks;
		arrayOfArrays [2] = snares;
		arrayOfArrays [3] = perc;
		arrayOfArrays [4] = melody;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
