using UnityEngine;
using System.Collections;

public class TileDetails : MonoBehaviour {

	public Color originalColor;
	public Color touchColor;
	public bool touchTrue;

	// Use this for initialization
	void Start () {
//		new Color ogColor = GetComponent<SpriteRenderer>().color;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTouchDown () {
		//GetComponent<SpriteRenderer> ().color = touchColor;

		//GetComponent<SpriteRenderer> ().color = touchColor;
	}

	void OnTouchStay () {
		GetComponent<SpriteRenderer> ().color = touchColor;
	}

	void OnTouchExit () {
		StartCoroutine (LerpBackgroundColor (touchColor, originalColor));
	}

	public IEnumerator LerpBackgroundColor(Color start, Color end)
	{
		for (float t = 0; t <= 1.0f; t += Time.deltaTime)
		{
			GetComponent<SpriteRenderer>().color = Color.Lerp(start, end, t);
			yield return null;
		}
	}
	
}
