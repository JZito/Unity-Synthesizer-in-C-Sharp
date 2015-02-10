using UnityEngine;
using System.Collections;

public class TileDetails : MonoBehaviour {

	public Color originalColor;
	public Color touchColor;
	public bool touchTrue;
	public bool trigger;
	public float note;

	// Use this for initialization
	void Start () {
		print (this.name + note);
		trigger = false;
//		new Color ogColor = GetComponent<SpriteRenderer>().color;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTouchDown () {
//		print ("hello");
		//GetComponent<SpriteRenderer> ().color = touchColor;
		GetComponent<SpriteRenderer> ().color = touchColor;
		StopCoroutine ("LerpColor");
		//GetComponent<SpriteRenderer> ().color = touchColor;
	}

	public void OnTouchStay () {
		GetComponent<SpriteRenderer> ().color = touchColor;
	}

	public void OnTouchExit () {
		StartCoroutine ("LerpColor");
	}

	public void FadeToBlack ()
	{
		trigger = true;
		StartCoroutine (FadeBlack ());
	}

	public IEnumerator LerpColor()
	{
		for (float t = 0; t <= 1.0f; t += Time.deltaTime)
		{
			GetComponent<SpriteRenderer>().color = Color.Lerp(touchColor, originalColor, t);
			yield return null;
		}
	}

	public IEnumerator FadeBlack() {
		for (float t = 0; t <= 2.0f; t += Time.deltaTime)
		{
			GetComponent<SpriteRenderer>().color = Color.Lerp(Color.black, originalColor, t);

			yield return null;
		}

	}
	
}
