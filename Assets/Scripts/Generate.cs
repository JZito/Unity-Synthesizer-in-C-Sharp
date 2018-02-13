using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SynchronizerData;

public class Generate : MonoBehaviour {

	// use this script to generate content for musical items. patterns 
	//(filled with enum BeatValue from synchronizer data)  and movement
	//on grid of objects  (in int lists)

	public List<int> moves0 = new List<int>();
	public List<int> moves1 = new List<int>();
	public List<int> moves2 = new List<int>();
	public List<int> moves3 = new List<int>();
	public List<int> moves4 = new List<int>();
	public List<List<int>> movesList = new List<List<int>>();
	public List<int> beats0 = new List<int> ();
	public List<int> beats1 = new List<int> ();
	public List<int> beats2 = new List<int> ();
	public List<int> beats3 = new List<int> ();
	public List<int> beats4 = new List<int> ();
	public List<int> beats5 = new List<int> ();
	public List<List<int>> beatsList = new List<List<int>> ();
	public List<AudioClip> audioList = new List<AudioClip>();

	// Use this for initialization
	void Awake () {
		movesList.Add (moves0);
		movesList.Add (moves1);
		movesList.Add (moves2);
		movesList.Add (moves3);
		movesList.Add (moves4);
		beatsList.Add (beats0);
		beatsList.Add (beats1);
		beatsList.Add (beats2);
		beatsList.Add (beats3);
		beatsList.Add (beats4);
		beatsList.Add (beats5);
	}

	
	// Update is called once per frame
	void Update () {
//		print (movesList.Count);
	
	}
}
