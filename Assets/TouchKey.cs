using UnityEngine;
using System.Collections;
[RequireComponent (typeof (SynthControl))]

public class TouchKey : MonoBehaviour {


// @Range(0.003, 3.0)  var env_atk = 1.0;
[Range(0.003f, 3.0f)] public float env_atk = 1.0f;
// @Range(0.003, 3.0)  var env_rel = 1.0;
[Range(0.003f, 3.0f)] public float env_rel = 1.0f;
// @Range(5, 12)      var noteRange = 7;
[Range(5,12)] public int noteRange = 0;

// private var lastNoteDegree = -1;
private int lastNoteDegree = -1;

private SynthControl synth;
private MusicScale scale;
private Lope envelope;
//private var noise : NoiseController;
//private var seq : AutoSequencer;
//private var scale = MusicalScale(47, 0);



// var barMaterial : Material;
// private var barTexture : Texture2D;
// private var barAlpha = 0.0;
// var heroCube : GameObject;

public void Start() {
    synth = GetComponent<SynthControl>();
    scale = GetComponent<MusicScale>();
    envelope = GetComponent<Lope>();
    scale.MusicalScale(41);
//    noise = FindObjectOfType(NoiseController);
//    seq = GetComponent.<AutoSequencer>();

    envelope.sustain = false;
    
   // barTexture = new Texture2D(8, 8);
}

public void Update() {
    envelope.attack = env_atk;
    envelope.release = env_rel;
    ///////////////////////// IF TOUCHING AN OBJECT IS TRUE,
    ///////////////////////// USE THAT OBJECT ID FOR PITCH
    if (Input.GetMouseButtonDown(0)) {
      

    }
    
    if (Input.GetMouseButton(0)) {
  //      noise.KeyOn(1.0);
    	lastNoteDegree = noteRange * (int)Input.mousePosition.y / (int)Screen.height;
        envelope = synth.KeyOn(scale.GetNote(lastNoteDegree), envelope);
        //var worldPosition : Vector3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       /////////// New Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //////////heroCube.transform.position.y = worldPosition.y;
        //heroCube.transform.position.y = Input.mousePosition.y;
        //////////barAlpha = Mathf.Clamp(barAlpha + 2.0 * Time.deltaTime, 0.5, 1.0);
    } else {
       /////////// barAlpha = Mathf.Max(0.0, barAlpha - 3.0 * Time.deltaTime);
    }

    if (Input.GetMouseButtonUp(0)) {
        envelope.KeyOff();
    }

   // barMaterial.SetFloat("_Alpha", barAlpha * Random.Range(0.6, 1.0));
}
/*
void OnGUI() {
    if (Event.current.type == EventType.Repaint) {
        var barHeight = 1.0 * Screen.height / noteRange;
        var rect = Rect(0, Screen.height - (lastNoteDegree + 1.2) * barHeight, Screen.width, 1.4 * barHeight);
        Graphics.DrawTexture(rect, barTexture, barMaterial);
    }
}
*/
}
