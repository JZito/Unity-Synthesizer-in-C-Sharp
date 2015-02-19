using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SynchronizerData;

public class MovementManager : MonoBehaviour {

	//public List<TileDetails> triggers = new List<TileDetails> ();
	public int cutoff;
	public int switchCount;
	public List<int> moves = new List<int> ();
	public List<GameObject> previousObservers = new List<GameObject>();
	public GameObject board;
	public BeatsArray beatsArray;
	public ContentTrigger contentTrigger;
	public Generate generate;
	public Grid grid;
	private BeatObserver beatObserver;
	private int moveCounter;
	private int ran;
	private int beatCount;
	public int randomBeatChooser = 2;
	public int randomSwitchInt = 3;

	void Start () {
		grid = board.GetComponent<Grid> ();
		ran = Random.Range (0, 5);
		beatObserver = GetComponent<BeatObserver>();
		moveCounter = 0;
		audio.clip = generate.audioList[ran];
		beatsArray.beats[randomBeatChooser].GetComponent<BeatCounter>().observers.Add (this.gameObject);
		contentTrigger.StartChangeMoves(this.gameObject.GetComponent<MovementManager>());
		StartCoroutine (ChangeBeats ());
	}


	
	// Update is called once per frame
	void Update () {
		if ((beatObserver.beatMask & BeatType.DownBeat) == BeatType.DownBeat) {
			var tile = grid.tiles[moves[moveCounter]].GetComponent<TileDetails>();
			tile.FadeToBlack();
			audio.Play ();
			moveCounter = (++moveCounter == moves.Count ? 0 : moveCounter);
			print ("mc" + moveCounter);
//			if (grid.tiles [moves [moveCounter]] == null) {
//				contentTrigger.StartChangeMoves(this.gameObject.GetComponent<MovementManager>());		
//			}
//			if (switchCount >= cutoff) {
//				contentTrigger.StartChangeBeats(bCounter, this.gameObject);
//				switchCount = 0;
//			}
		}
	}



//		if ((beatObserver.beatMask & BeatType.UpBeat) == BeatType.UpBeat) {
//			transform.Rotate(Vector3.forward, 45f);
//		}
	

	IEnumerator ChangeBeats () {
		if (true) {
			while (switchCount >= randomSwitchInt) {
				for (int i = 0; i< beatsArray.beats.Length; i++) {
					if (beatsArray.beats [i].GetComponent<BeatCounter> ().observers.Contains (this.gameObject)) {
						previousObservers.Remove (this.gameObject);
						print ("whopie");
					}
					var randomNewObservers = beatsArray.beats [randomBeatChooser].GetComponent<BeatCounter> ().observers;    
					randomNewObservers.Add (this.gameObject);
					print ("changebeats");
					switchCount = 0;
					beatCount = 0;
					randomSwitchInt = Random.Range (0, 6);
					randomBeatChooser = Random.Range (0, 9);

				}

			}
			yield return null;
		}		

	}
}
