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
	public List<BeatValue> pattern0 = new List<BeatValue>();
	public List<BeatValue> pattern1 = new List<BeatValue>();
	public List<BeatValue> pattern2 = new List<BeatValue>();
	public List<BeatValue> pattern3 = new List<BeatValue>();
	public List<BeatValue> pattern4 = new List<BeatValue>();
	public List<BeatValue> pattern5 = new List<BeatValue>();
	public List<BeatValue> pattern6 = new List<BeatValue>();
	public List<BeatValue> pattern7 = new List<BeatValue>();
	public List<List<BeatValue>> beatValueList = new List<List<BeatValue>> ();
	public List<AudioClip> audioList = new List<AudioClip>();

	// Use this for initialization
	void Start () {
		movesList.Add (moves0);
		movesList.Add (moves1);
		movesList.Add (moves2);
		movesList.Add (moves3);
		movesList.Add (moves4);
		beatValueList.Add (pattern0);
		beatValueList.Add (pattern1);
		beatValueList.Add (pattern2);
		beatValueList.Add (pattern3);
		beatValueList.Add (pattern4);
		beatValueList.Add (pattern5);
		beatValueList.Add (pattern6);
		beatValueList.Add (pattern7);

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
