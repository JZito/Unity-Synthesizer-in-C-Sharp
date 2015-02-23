﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SynchronizerData;

public class MovementManager : MonoBehaviour {
// add a starting point, a counter up point by either one, 16, or 17 ?
// starting point row or col
	// if row, 0, 16, 32, 48, 64, 80, 96, 112
	//   increase by 1
	// if col, 0-15
	//   increase by 16 or 17
	//what if the tail determines the speed.... it can't get too long and it can't catch up with the user

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
		audio.clip = generate.audioList[ran];
		beatsArray.beats[randomBeatChooser].GetComponent<BeatCounter>().observers.Add (this.gameObject);
		contentTrigger.StartChangeMoves(this.gameObject.GetComponent<MovementManager>());
		StartCoroutine (ChangeBeats ());
	}


	
	// Update is called once per frame
	void Update () {
		Debug.Log (beatObserver.beatMask + "bo");
		if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat) {
			audio.Play ();
			var tile = grid.tiles[moves[moveCounter]].GetComponent<TileDetails>();
			tile.FadeToBlack();
			print ("movecounter"+ moveCounter);
			moveCounter = (++moveCounter == moves.Count ? 0 : moveCounter);
			//              is movecounter + 1 = moves.count? if yes, movecounter is 0. otherwise movecounter (? +1?)
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
