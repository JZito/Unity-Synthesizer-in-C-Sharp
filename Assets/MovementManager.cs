using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SynchronizerData;

public class MovementManager : MonoBehaviour {

	//public List<GameObject> objects = new List<GameObject>();
	public List<TileDetails> tDetails = new List<TileDetails> ();

	//public TileDetails[] tDetails;
	//public TileDetails[] triggers;
	public List<TileDetails> triggers = new List<TileDetails> ();
	public GameObject board;
	public Generate generate;
	public PatternArray patternArray;
	public GameObject pattern;

	public Vector3[] beatPositions;
	//public List<int> intList = new List<int>();
	
	private BeatObserver beatObserver;
	private int beatCounter;

	// Use this for initialization
	void Start () {
		var tilesList = board.GetComponent<Grid> ();

		int random = Random.Range (0, 5);
		pattern = patternArray.patterns [Random.Range (0, 3)];
		pattern.GetComponent<PatternCounter>().observers.Add (this.gameObject);
		beatObserver = GetComponent<BeatObserver>();
		beatCounter = 0;
		audio.clip = generate.audioList[random];
		var boo = generate.movesList [random];
		for (int i = 0; i < tilesList.tiles.Count; i++) {
			print ("boo");
			tDetails.Add(tilesList.tiles[i].GetComponent<TileDetails>());		
		}
		for(int i = 0; i < generate.movesList[random].Count; i++) {
			print ("for");
			print (tDetails.Count);
			triggers.Add (tDetails[boo[i]]);}
	
	}
	
	// Update is called once per frame
	void Update () {

		if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat) {

	//		transform.position = new Vector3(beatPositions[beatCounter].x, transform.position.y, 0);
			triggers[beatCounter].FadeToBlack();
//			print (beatCounter + "bc");
			audio.Play ();
			beatCounter = (++beatCounter == beatPositions.Length ? 0 : beatCounter);
		}
	
	}
}
