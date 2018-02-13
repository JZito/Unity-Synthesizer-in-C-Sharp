using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SynchronizerData;

public class MovementManager : MonoBehaviour {

	//public List<TileDetails> triggers = new List<TileDetails> ();
	public int cutoff;
	public int switchCount;
	public List<int> moves = new List<int> ();
	//public List<GameObject> previousObservers = new List<GameObject>();
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
		GetComponent<AudioSource>().clip = generate.audioList[ran];
		beatsArray.beats[randomBeatChooser].GetComponent<BeatCounter>().observers.Add (this.gameObject);
		contentTrigger.StartChangeMoves(this.gameObject.GetComponent<MovementManager>());
		StartCoroutine (ChangeBeats ());
	}


	
	// Update is called once per frame
	void Update () {
		if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat) {
			var tile = grid.tiles[moves[moveCounter]].GetComponent<TileDetails>();
			tile.FadeToBlack();
			GetComponent<AudioSource>().Play ();
			moveCounter = (++moveCounter == moves.Count ? 0 : moveCounter);
			++switchCount;
		}
	}

	public bool switcher () {
			if (switchCount >= randomSwitchInt)
			{
				return true;
			}

			return false;
		}

//		if ((beatObserver.beatMask & BeatType.UpBeat) == BeatType.UpBeat) {
//			transform.Rotate(Vector3.forward, 45f);
//		}
	

	IEnumerator ChangeBeats () {
		print ("change called");
		print (switcher ());
		print (randomSwitchInt + "randomSwitchInt");

			if (switcher()) {
				print ("switchcount >= randomswitch");
				for (int i = 0; i< beatsArray.beats.Length; i++) {
					if (beatsArray.beats [i].GetComponent<BeatCounter> ().observers.Contains (this.gameObject)) {
						beatsArray.beats [i].GetComponent<BeatCounter> ().observers.Remove (this.gameObject);
						print ("whopie");
					}
					var randomNewObservers = beatsArray.beats [randomBeatChooser].GetComponent<BeatCounter> ().observers;    
					randomNewObservers.Add (this.gameObject);
					print ("changebeats");
					switchCount = 0;
					beatCount = 0;
					randomSwitchInt = Random.Range (3, 16);
					randomBeatChooser = Random.Range (0, 9);

				}

			}
			yield return new WaitForSeconds (0.05f);
				

	}
}
