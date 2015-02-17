using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContentTrigger : MonoBehaviour {

	public PatternArray patternArray;
	public Generate generate;
	public int num = 2;
	public int num2 = 3;

	// Use this for initialization
	void Start () {
		StartCoroutine (ChangePattern ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// so when pattern is out of range, changepattern should be triggered. have a yield return
	//right before pattern copy with 0 as an option
	IEnumerator ChangePattern () {
		//pc.beatvalues
			//invokerepeating random set of repeat times
		while (true) {
			num = Random.Range (0,3);
			num2 = Random.Range (0, 7);
			Debug.Log (num + "num" + num2 + "num2");
			patternArray.patterns [num].GetComponent<PatternCounter> ().beatvalues.Clear ();
			//generate.beatValueList[num2].CopyTo(patternArray.patterns[num].GetComponent<PatternCounter>().beatvalues, 0);
			yield return new WaitForSeconds (5f);
				}
	}
}
