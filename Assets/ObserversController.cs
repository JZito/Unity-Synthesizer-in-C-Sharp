using UnityEngine;
using System.Collections;

public class ObserversController : MonoBehaviour {
	public PatternCounter pattern1;
	public PatternCounter pattern2;
	public PatternCounter pattern3;
	public PatternCounter pattern4;
	public GameObject row0;
	public GameObject row1;
	public GameObject row2;
	public GameObject row3;

	void Awake () {
		pattern1.observers.Add (row0);
		pattern2.observers.Add (row1);
		pattern3.observers.Add (row2);
		pattern4.observers.Add (row3);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
