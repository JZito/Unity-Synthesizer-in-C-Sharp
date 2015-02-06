using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SynchronizerData;

public class GridChanger : MonoBehaviour {

	public Vector3[] beatPositions;
	public List<GameObject> observers = new List<GameObject>();
	public PatternCounter pattern1;
	public Grid grid;
	public float beatPoint;
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
		beatObserver = GetComponent<BeatObserver>();
		beatCounter = 0;
		//MainSpawner = GameObject.FindGameObjectWithTag ("TheSpawner");
		audio.clip = sample;
	//	pattern1.observers.Add (this.gameObject);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		print ("update");
		foreach (GameObject bo in observers)
		{
			beatObserver = bo.gameObject.GetComponent<BeatObserver>();
			print ("for each");
		if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat) {
			if (beatObserver.beatValue != BeatValue.None) {
				beatPoint = beatPoint + (1/BeatDecimalValues.values [(int)beatObserver.beatValue]);//beatPositions[beatCounter];
				print (beatPoint);
				string beatPointString = beatPoint.ToString ();
				foreach (GameObject g in grid.tiles) {
					if (g.name == beatPointString) { //grid.tiles[beatpoint] = beatpoint???
						g.GetComponent<TileDetails>().FadeToBlack();
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
