using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (SynthControl))]

public class TouchKey : MonoBehaviour {

public Camera gameCam;
[Range(0.003f, 3.0f)] public float env_atk = 1.0f;
[Range(0.003f, 3.0f)] public float env_rel = 1.0f;
[Range(5,12)] public int noteRange = 12;
public LayerMask touchInputMask;
private GameObject[] touchesOld;
private int lastNoteDegree = -1;
private List<GameObject> touchList = new List<GameObject>();
private Lope envelope;
private RaycastHit hit;
private string lastNoteDegreeString;
private SynthControl synth;

public void Start() {
    synth = GetComponent<SynthControl>();
    envelope = GetComponent<Lope>();
//    noise = FindObjectOfType(NoiseController);
//    seq = GetComponent.<AutoSequencer>();
		//  SYNTH.LOPE.SUSTAIN = false;
    envelope.sustain = false;
    
   // barTexture = new Texture2D(8, 8);
}

public void Update() {

#if UNITY_EDITOR

		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0)) {
			
			touchesOld = new GameObject[touchList.Count];
			touchList.CopyTo(touchesOld);
			touchList.Clear();
			
			
			RaycastHit2D hit = Physics2D.Raycast(gameCam.ScreenToWorldPoint
			                                     (Input.mousePosition), Vector2.zero);       
			
			if(hit.collider!=null) {
				
				GameObject recipient = hit.transform.gameObject;
				touchList.Add(recipient);
				Debug.Log (recipient.name);
				lastNoteDegreeString = recipient.name;
				lastNoteDegree = int.Parse(lastNoteDegreeString);
				
				if (Input.GetMouseButtonDown(0)) {
					envelope = synth.KeyOn(lastNoteDegree, envelope);
					recipient.SendMessage("OnTouchDown",hit.point,
					                      SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetMouseButtonUp(0)) {
					envelope.KeyOff();
					recipient.SendMessage("OnTouchUp",hit.point,
					                      SendMessageOptions.DontRequireReceiver);
				}
				if (Input.GetMouseButton(0)) {
					lastNoteDegreeString = recipient.name;
					lastNoteDegree = int.Parse(lastNoteDegreeString);
					envelope = synth.KeyOn(lastNoteDegree, envelope);
					recipient.SendMessage("OnTouchStay",hit.point,
					                      SendMessageOptions.DontRequireReceiver);
				}
				
			}
			
			foreach (GameObject g in touchesOld) {
				if (!touchList.Contains(g)) {
					g.SendMessage("OnTouchExit",hit.point,
					              SendMessageOptions.DontRequireReceiver);
				}
			}
		}
		
		
#endif
	envelope.attack = env_atk;
	envelope.release = env_rel;
	if (Input.touchCount > 0){
		
		touchesOld = new GameObject[touchList.Count];
		touchList.CopyTo(touchesOld);
		touchList.Clear();
		
		foreach (Touch touch in Input.touches) {
			
			RaycastHit2D hit = Physics2D.Raycast(gameCam.ScreenToWorldPoint
				                             (Input.mousePosition), Vector2.zero);       
			
			if(hit.collider!=null) {
				
				GameObject recipient = hit.transform.gameObject;
				touchList.Add(recipient);
				Debug.Log (recipient.name);
				lastNoteDegreeString = recipient.name;
				lastNoteDegree = int.Parse(lastNoteDegreeString);

				if (touch.phase == TouchPhase.Began) {
						envelope = synth.KeyOn(lastNoteDegree, envelope);
						recipient.SendMessage("OnTouchDown",hit.point,
						                      SendMessageOptions.DontRequireReceiver);
				}

				if (touch.phase == TouchPhase.Moved) {
						lastNoteDegreeString = recipient.name;
						lastNoteDegree = int.Parse(lastNoteDegreeString);
						envelope = synth.KeyOn(lastNoteDegree, envelope);
						//lastNoteDegree = recipient.name;
							//noteRange * (int)Input.mousePosition.y / (int)Screen.height;

					}
				if (touch.phase == TouchPhase.Ended) {
						envelope.KeyOff();
						recipient.SendMessage("OnTouchUp",hit.point,
						                      SendMessageOptions.DontRequireReceiver);
				}
				if (touch.phase == TouchPhase.Stationary) {
						lastNoteDegreeString = recipient.name;
						lastNoteDegree = int.Parse(lastNoteDegreeString);
						envelope = synth.KeyOn(lastNoteDegree, envelope);
						recipient.SendMessage("OnTouchStay",hit.point,
						                      SendMessageOptions.DontRequireReceiver);
				}
				if (touch.phase == TouchPhase.Canceled) {
						envelope.KeyOff();
						recipient.SendMessage("OnTouchExit",hit.point,
						                      SendMessageOptions.DontRequireReceiver);
				}
				
			}
			
		}
		foreach (GameObject g in touchesOld) {
			if (!touchList.Contains(g)) {
				g.SendMessage("OnTouchExit",hit.point,
					              SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}

}
