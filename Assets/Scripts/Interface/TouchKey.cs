using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (SynthControl))]

public class TouchKey : MonoBehaviour {

public Camera gameCam;
[Range(0.003f, 3.0f)] public float env_atk = 1.0f;
[Range(0.003f, 3.0f)] public float env_rel = 1.0f;
[Range(24,48)] public int scale = 24;
public LayerMask touchInputMask;
private GameObject[] touchesOld;
private int lastNoteDegree = -1;
private List<GameObject> touchList = new List<GameObject>();
private Lope envelope;
private RaycastHit2D hit;
private string lastNoteDegreeString;
private SynthControl synth;
private GameObject recipient;
public NReverb reverb;

public void Start() {
    synth = GetComponent<SynthControl>();
    envelope = GetComponent<Lope>();

    envelope.sustain = false;
	reverb = GetComponent<NReverb> ();


   // barTexture = new Texture2D(8, 8);
		//    noise = FindObjectOfType(NoiseController);
		//    seq = GetComponent.<AutoSequencer>();
		//  SYNTH.LOPE.SUSTAIN = false;
}

public void Update() {

// #if UNITY_EDITOR

		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {
			
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();

			RaycastHit2D hit = Physics2D.Raycast(gameCam.ScreenToWorldPoint
			                                     (Input.mousePosition), Vector2.zero); 
			
			GameObject recipient = hit.transform.gameObject;
			var tDetails = recipient.GetComponent<TileDetails>();
			reverb.wetMix = hit.transform.position.x / 24;
			Debug.Log (recipient.gameObject.name + "hit");
			if(hit.collider!=null) {
				

				touchList.Add(recipient);
			//	Debug.Log (recipient.name);
				//lastNoteDegreeString = recipient.name;
				//lastNoteDegree = int.Parse(lastNoteDegreeString);

				
				if (Input.GetMouseButtonDown(0)) {
					lastNoteDegree = scale + (int)tDetails.note;
					envelope = synth.KeyOn(lastNoteDegree, envelope);
					tDetails.OnTouchDown();
				//	recipient.SendMessage("OnTouchDown",hit.point,
				//	                      SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetMouseButtonUp(0)) {
					envelope.KeyOff();
					tDetails.OnTouchExit();
					//recipient.SendMessage("OnTouchUp",hit.point,
					//                      SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetMouseButton(0)) {
					lastNoteDegree = scale + (int)tDetails.note;
					envelope = synth.KeyOn(lastNoteDegree, envelope);
					tDetails.OnTouchStay();
					//recipient.SendMessage("OnTouchStay",hit.point,
					//                      SendMessageOptions.DontRequireReceiver);
				}
				
			}
			
			foreach (GameObject g in touchesOld) {
				if (!touchList.Contains(g)) {
					g.SendMessage("OnTouchExit",hit.point,
					              SendMessageOptions.DontRequireReceiver);
				}
			}
		}
		
		
// #endif

	envelope.attack = env_atk;
	envelope.release = env_rel;
	
		/*
	if (Input.touchCount > 0){
		
	//	touchesOld = new GameObject[touchList.Count];
	//	touchList.CopyTo(touchesOld);
	//	touchList.Clear();
		
	//	foreach (Touch touch in Input.touches) {
		//	var touch = Input.touches;
		for (int i = 0; i < Input.touchCount; i++) {
			Touch touch = Input.GetTouch(i);
			RaycastHit2D hit = Physics2D.Raycast(gameCam.ScreenToWorldPoint
				                             (Input.mousePosition), Vector2.zero);       
			reverb.wetMix = hit.transform.position.x / 30;
			if(hit.collider!=null) {
				
				GameObject recipient = hit.transform.gameObject;
				var tDetails = recipient.GetComponent<TileDetails>();
				touchList.Add(recipient);
				//Debug.Log (recipient.name);
				//lastNoteDegreeString = recipient.name;
				//lastNoteDegree = int.Parse(lastNoteDegreeString);
				
				if (touch.phase == TouchPhase.Began) {
						lastNoteDegree =  scale + (int)recipient.GetComponent<TileDetails>().note;
						envelope = synth.KeyOn(lastNoteDegree, envelope);
						tDetails.OnTouchDown();
				//		recipient.SendMessage("OnTouchDown",hit.point,
				//		                      SendMessageOptions.DontRequireReceiver);
				}

				if (touch.phase == TouchPhase.Moved) {
						lastNoteDegree = scale + (int)tDetails.note;
						envelope = synth.KeyOn(lastNoteDegree, envelope);
				//		recipient.GetComponent<TileDetails>().OnTouchDown();
						//lastNoteDegree = recipient.name;
							//noteRange * (int)Input.mousePosition.y / (int)Screen.height;

					}
				if (touch.phase == TouchPhase.Ended) {
						envelope.KeyOff();
						tDetails.OnTouchExit();
				//		recipient.SendMessage("OnTouchUp",hit.point,
				//		                      SendMessageOptions.DontRequireReceiver);
				}
				if (touch.phase == TouchPhase.Stationary) {
						lastNoteDegree = scale + (int)recipient.GetComponent<TileDetails>().note;
						envelope = synth.KeyOn(lastNoteDegree, envelope);
						tDetails.OnTouchStay();
					//	recipient.SendMessage("OnTouchStay",hit.point,
					//	                      SendMessageOptions.DontRequireReceiver);
				}
				if (touch.phase == TouchPhase.Canceled) {
						envelope.KeyOff();
						tDetails.OnTouchExit();
					//	recipient.SendMessage("OnTouchExit",hit.point,
					//	                      SendMessageOptions.DontRequireReceiver);
				}
				
			}
			
		} // for/ for each each closeing bracket
		foreach (GameObject g in touchesOld) {
			if (!touchList.Contains(g)) {
				g.SendMessage("OnTouchExit",hit.point,
					              SendMessageOptions.DontRequireReceiver);
			}
		}
	}
	*/
}

}
