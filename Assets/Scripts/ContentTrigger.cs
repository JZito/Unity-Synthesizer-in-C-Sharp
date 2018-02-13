using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SynchronizerData;

public class ContentTrigger : MonoBehaviour {

	public BeatsArray beatsArray;
	public Generate generate;
	public int randomBeatChooser = 2;
	public int randomSwitchInt = 3;
	
	//public void StartChangeBeats (BeatCounter bc, GameObject bo ) {
	//	StartCoroutine (ChangeBeats (bc, bo));
	//}

	public void StartChangeMoves (MovementManager mm) {
		StartCoroutine (ChangeMoves (mm));
	}
	// so when pattern is out of range, changepattern should be triggered. have a yield return
	//right before pattern copy with 0 as an option
	/*
	IEnumerator ChangeBeats (BeatCounter beatCounter, GameObject beatObs) {
		var mm = beatObs.GetComponent<MovementManager> ();
		randomBeatChooser = Random.Range (0,9);
		randomSwitchInt = Random.Range (0, 6);
		if (mm.switchCount >= mm.cutoff) {
			beatsArray.beats[randomBeatChooser].GetComponent<BeatCounter>().observers.Add (beatObs);
			beatCounter.observers.Remove (beatObs);
			mm.switchCount = 0;
		}
		mm.switchCount = 0;
		mm.cutoff = randomSwitchInt;
		yield return null;
	}
	*/

	IEnumerator ChangeMoves (MovementManager movementManager) {
		int num3 = Random.Range (0, 3);
//		List<int> list = new List<int> ();
//		generate.movesList [num3].CopyTo (list);
//		var banana = generate.movesList [num3];
//		for (int h = 0; h < banana.Count; h++) {

//				list.Add (banana[h]);
//				}

		for (int i = 0; i < generate.movesList[num3].Count; i++) {
			movementManager.moves.Add(generate.movesList[num3][i]);
//			print ("moves" + i);
		}
//		patternCounter.NewSamplePeriods();
		yield return null;
	}
}
