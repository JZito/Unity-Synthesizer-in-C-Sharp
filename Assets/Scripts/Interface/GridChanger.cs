using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SynchronizerData;

public class GridChanger : MonoBehaviour {

	public Vector3[] beatPositions;
	public List<GameObject> observers = new List<GameObject>();
	public List<AudioClip> soundsArray = new List<AudioClip> ();
	public TileDetails details;
	public PatternCounter pattern1;
	public Grid grid;
	public int beatPoint;
	private BeatObserver beatObserver;
	public GameObject observer;
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

		for (int i = 0; i < observers.Count; i++) {
			print ("in the for loop" + i);	
			observer = observers [i];
			observer.GetComponent<AudioSource>().clip = soundsArray[i];
		}
		/*
		for (int i = 0; i < observers.Count; i++) {
			observer = observers [i];
			beatObserver = observer.gameObject.GetComponent<BeatObserver>();
				}
				*/
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		for (int i = 0; i < observers.Count; i++) {
			int randomizer = Random.Range (0, 3);
			observer = observers [i];
			beatObserver = observer.gameObject.GetComponent<BeatObserver>();
			if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat) {
				observer.GetComponent<AudioSource>().Play ();
//	beatPoint = beatPoint + (Mathf.RoundToInt ((1/BeatDecimalValues.values 
//                                      [(int)beatObserver.beatValue])) * 2);//beatPositions[beatCounter];
				print (beatPoint + "bp");
				//grid.tiles[beatPoint].GetComponent<TileDetails>().FadeToBlack();
				if (randomizer < 2) {
					print ("random zero");
					grid.tiles[beatCounter + (beatCounter + 16)].GetComponent<TileDetails>().FadeToBlack();
				}
				if (randomizer >= 2) {
					print ("random one");
					grid.tiles[beatCounter].GetComponent<TileDetails>().FadeToBlack();
				}
				++beatCounter;
				// beatCounter = (++beatCounter == beatPositions.Length ? 0 : beatCounter);
			}
		}
	}
}
