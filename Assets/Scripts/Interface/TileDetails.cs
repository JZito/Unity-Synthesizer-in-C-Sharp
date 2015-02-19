using UnityEngine;
using System.Collections;

public class TileDetails : MonoBehaviour {

	public Color originalColor;
	public SpriteRenderer tileColor;
	public Color touchColor;
	public bool touchTrue;
	public bool trigger;
	public bool coroutineRunning = false;
	public float note;

	// Use this for initialization
	void Start () {
		tileColor = gameObject.GetComponent<SpriteRenderer> ();
//		print (this.name + note);
		trigger = false;
//		new Color ogColor = GetComponent<SpriteRenderer>().color;
	
	}
	
	// Update is called once per frame
	void Update () {

//		print (coroutineRunning);
	
	}

	public void OnTouchDown () {
		tileColor.color = touchColor;

		while (coroutineRunning) {
				StopCoroutine ("LerpColor");
				print ("stop!");
				coroutineRunning = false;

				}

	}

	public void OnTouchStay () {
		tileColor.color = touchColor;

		while (coroutineRunning) {
			StopCoroutine ("LerpColor");
			print ("stop!");
			coroutineRunning = false;

		}

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
			coroutineRunning = true;
			tileColor.color = Color.Lerp(touchColor, originalColor, t);
			yield return null;
			coroutineRunning = false;
		}
	}

	public IEnumerator FadeBlack() {
		for (float t = 0; t <= 2.0f; t += Time.deltaTime)
		{
			tileColor.color = Color.Lerp(Color.black, originalColor, t);

			yield return null;
		}

	}
	
}
