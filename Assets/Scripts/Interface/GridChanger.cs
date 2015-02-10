using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SynchronizerData;

public class GridChanger : MonoBehaviour {

	public Vector3[] beatPositions;
	public List<GameObject> observers = new List<GameObject>();
	public TileDetails details;
	public PatternCounter pattern1;
	public Grid grid;
	public int beatPoint;
	private BeatObserver beatObserver;
	private int beatCounter;
	public float beat;
	public float row;
	public int lowRange;
	public int highRange;
	public AudioClip sample;
	//	public GameObject MainSpawner;
	public int end;
	//	private List<float> pauses = new List<float>();
	private float timer;
	private	Vector3 pos;
	private bool fadeOut;

	//	private bool dropIt = true;
	float time;

	// Use this for initialization
	void Start () {
		grid = GetComponent<Grid> ();
		fadeOut = false;
		beatCounter = 0;
		//MainSpawner = GameObject.FindGameObjectWithTag ("TheSpawner");
		audio.clip = sample;
	//	pattern1.observers.Add (this.gameObject);

		foreach (GameObject observer in observers) {
			beatObserver = observer.gameObject.GetComponent<BeatObserver>();
		}

		//foreach (GameObject g in grid.tiles) {
		//	details = g.GetComponent<TileDetails>();
		//}
		
	}
	
	// Update is called once per frame
	void Update ()
	{
//		print ("update");
		// for int i = 0 i <= observers.length i++
		//
		foreach (GameObject observer in observers)
		//	from bo in observers
		{
			//beatObserver = observer.gameObject.GetComponent<BeatObserver>();
//			print ("for each");
		if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat) {
			if (beatObserver.beatValue != BeatValue.None) {
				beatPoint = beatPoint + Mathf.RoundToInt ((1/BeatDecimalValues.values [(int)beatObserver.beatValue]));//beatPositions[beatCounter];
				print (beatPoint);
				string beatPointString = beatPoint.ToString ();
				foreach (GameObject g in grid.tiles) {
						details = g.GetComponent<TileDetails>();
					if (g.name == beatPointString) { //grid.tiles[beatpoint] = beatpoint???
						details.FadeToBlack();
						} else {
								
							}
						} 
						audio.Play ();
						beatCounter = (++beatCounter == beatPositions.Length ? 0 : beatCounter);
				}			
			}
		}
	}
}
