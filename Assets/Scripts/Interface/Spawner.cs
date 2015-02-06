using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Spawner : MonoBehaviour {

	public enum soundGroup { bells, kicks, snares, perc, melody };
	public soundGroup group;
	public enum beatCounters {wholeNote, halfNote, patternCount };
	public beatCounters beat;
	public GameObject wholeNoteBeat;
	public GameObject halfNoteBeat;
	public GameObject patternCount1;
	public GameObject goal;
	public float row;
	public float[] floats;
	public int lowRange;
	public int highRange;
	private GameObject MainSpawner;

	public GameObject moverPrefab;
	public GameObject hotPrefab;

	public List<float> timing = new List<float>();

	public void Awake ()
	{
		timing.Add (5.0f);
		timing.Add (8.0f);
		timing.Add (6.0f);
		timing.Add (4.0f);
	}

	public IEnumerator spawnNext() 
	{
		while (true)
		{
			float decider = 1f;
			print (decider + this.name);
			if(decider <= 4)
			{
				//int randomNumber = Random.Range (0,6);
				patternCount1 = MainSpawner.GetComponent<PatternArray> ().patterns [0];
				GameObject g = Instantiate(moverPrefab,new Vector3(16,row,0),Quaternion.identity)as GameObject;
		//		print ((int)group + "group");
				var uniqueArray = MainSpawner.GetComponent<SoundArray> ().arrayOfArrays [(int)group];
		/*		
		  		var gBeatArray = g.GetComponent<Mover> ().beatPositions;
				var ogBeatArray = MainSpawner.GetComponent<BeatArray> ().arrayOfBeats [0];
				System.Array.Copy (ogBeatArray, gBeatArray, 17);
		*/

		//		print (this.name + uniqueArray [Random.Range (lowRange, highRange)]);
				g.GetComponent<Mover> ().sample = uniqueArray[Random.Range (lowRange, highRange)];
				g.GetComponent<Mover> ().pattern = patternCount1;
				g.GetComponentInChildren<SpriteRenderer>().color = MainSpawner.GetComponent<ColorArray>().colorArray[0];
				//
				patternCount1.GetComponent<PatternCounter> ().observers.Add (g);

			}
			else if (decider > 4)
			{
				patternCount1 = MainSpawner.GetComponent<PatternArray> ().patterns [Random.Range (0, 6)];
				GameObject g = Instantiate(hotPrefab,new Vector3(16,row,0),Quaternion.identity)as GameObject;
				//		print ((int)group + "group");
				var uniqueArray = MainSpawner.GetComponent<SoundArray> ().arrayOfArrays [(int)group];
				var gBeatArray = g.GetComponent<MoverHot> ().beatPositions;
				var ogBeatArray = MainSpawner.GetComponent<BeatArray> ().arrayOfBeats [0];
				System.Array.Copy (ogBeatArray, gBeatArray, 17);
				
				//		print (this.name + uniqueArray [Random.Range (lowRange, highRange)]);
				g.GetComponent<MoverHot> ().sample = uniqueArray[Random.Range (lowRange, highRange)];
				g.GetComponent<MoverHot> ().pattern = patternCount1;
				//
				patternCount1.GetComponent<PatternCounter> ().observers.Add (g);
				GameObject goals = Instantiate(goal, new Vector3(Mathf.Round (Random.Range (0, 6)), row, 0), Quaternion.identity) as GameObject;

			}
			yield return new WaitForSeconds(timing[Random.Range (0,3)]);

		//GameObject mover = Instantiate (moverPrefab) as GameObject;
//		g.GetComponent<Mover>.timing = floats[Random.Range(lowRange, highRange)];;
		//mover.GetComponent<Mover>.type = 
		}
	}

	// Use this for initialization
	void Start() {
		MainSpawner = GameObject.FindGameObjectWithTag ("TheSpawner");
//		var audioSR = MainSpawner.GetComponent<SoundArray> ();
//		var audioPlayer = GetComponent<AudioSource>();
		// Spawn initial Group
		StartCoroutine(spawnNext());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
