using UnityEngine;
using System.Collections;

public class TileDetails : MonoBehaviour {

	public bool touchTrue;
	public bool activeEnemy;
	public bool activePlayer;
	public bool activeTrail;
	public bool activeFlag;
	public bool path = true;
	public bool coroutineRunning = false;
	public Color originalColor;

	public Color touchColor;
	public Color flagColor;
	public Color pathColor;
	public Color enemyColor;
	public float duration = 5f;
	public float smoothness = 0.02f;
	public float note;
	public SpriteRenderer tileColor;
	// Use this for initialization
	void Start () {
		tileColor = gameObject.GetComponent<SpriteRenderer> ();
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
			while (activeEnemy) {
				
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
		if (path) {
			StartCoroutine ("LerpColor");
		}

		else if (!path) {
			print ("boo boo");
		}
	}

	public void FadeToBlack ()
	{
		if (activeEnemy) {
			StopCoroutine("FadeBlack");		
		}
		StartCoroutine ("FadeBlack");
	}

	public IEnumerator LerpColor()
	{
		/*
		for (float t = 0; t <= 5.0f; t += Time.deltaTime)
		{
			Color32 touchColor = new Color(1F, 0f, 0.5F, 0.25f);
			coroutineRunning = true;
			tileColor.color = Color.Lerp(touchColor, originalColor, t);
			yield return null;
			coroutineRunning = false;
		}
		*/

		float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
		float increment = smoothness/duration; //The amount of change to apply.
		
		while(progress < 1)
		{
			coroutineRunning = true;
			tileColor.color = Color.Lerp(touchColor, pathColor, progress);
			progress += increment;
			yield return new WaitForSeconds(smoothness);
		}
		return true;
		coroutineRunning = false;
	}

	public IEnumerator FadeBlack() {
		for (float t = 0; t <= 1.01f; t += Time.deltaTime)
		{
			activeEnemy = true;
			if (path) {
			//	tileColor.color = Color.Lerp(Color.black, pathColor, t);
				tileColor.color = enemyColor;
			}
			else if (!path) {
				tileColor.color = Color.Lerp (Color.black, originalColor, t);
			}
			yield return null;
		}
		tileColor.color = pathColor;
		activeEnemy = false;
	}
	
}
