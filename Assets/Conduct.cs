using UnityEngine;
using System.Collections;
using SynchronizerData;

public class Conduct : MonoBehaviour {

	public int masterCount;
	private BeatObserver beatObserver;


	// Use this for initialization
	void Start () {
		beatObserver = GetComponent<BeatObserver>();
	}
	
	// Update is called once per frame
	void Update () {

		if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat) {
			++masterCount;
		}
	
	}
}
