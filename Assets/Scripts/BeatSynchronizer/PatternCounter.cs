using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SynchronizerData;

/// <summary>
/// This class is responsible for counting and notifying its observers when a beat in the specified pattern sequence occurs.
/// The accuracy of the counter is handled by loopTime, which controls how often it checks whether a beat has happened.
/// Higher settings for loopTime decreases load on the CPU, but will result in less accurate beat synchronization.
/// </summary>
public class PatternCounter : MonoBehaviour {

	//public BeatValue[] beatValues;
	public List<BeatValue> beatvalues = new List<BeatValue> ();
	public List<int> moveValues = new List<int> ();
	public int beatScalar = 1;
	public float loopTime = 30f;
	public AudioSource audioSource;
	public List<GameObject> observers = new List<GameObject> ();
	public Color patternColor;

	private float nextBeatSample;
	private float[] samplePeriods;
	public int sequenceIndex;
	private float currentSample;
	
	
	void Awake ()
	{
		NewSamplePeriods ();

		

	}

	public void NewSamplePeriods () {
		float audioBpm = audioSource.GetComponent<BeatSynchronizer>().bpm;
		samplePeriods = new float[beatvalues.Count];
		
		// Calculate number of samples between each beat in the sequence.
		for (int i = 0; i < beatvalues.Count; ++i) {
			samplePeriods[i] = (60f / (audioBpm * BeatDecimalValues.values[(int)beatvalues[i]])) * audioSource.clip.frequency;
			samplePeriods[i] *= beatScalar;
		}

		nextBeatSample = 0f;
		sequenceIndex = 0;
	}

	/// <summary>
	/// Initializes and starts the coroutine that checks for beat occurrences in the pattern. The nextBeatSample field is initialized to 
	/// exactly match up with the sample that corresponds to the time the audioSource clip started playing (via PlayScheduled).
	/// </summary>
	/// <param name="syncTime">Equal to the audio system's dsp time plus the specified delay time.</param>
	void StartPatternCheck (double syncTime)
	{
		nextBeatSample = (float)syncTime * audioSource.clip.frequency;
		StartCoroutine(PatternCheck());
	}

	/// <summary>
	/// Subscribe the PatternCheck() coroutine to the beat synchronizer's event.
	/// </summary>
	void OnEnable ()
	{
		BeatSynchronizer.OnAudioStart += StartPatternCheck;
	}

	/// <summary>
	/// Unsubscribe the PatternCheck() coroutine from the beat synchronizer's event.
	/// </summary>
	/// <remarks>
	/// This should NOT (and does not) call StopCoroutine. It simply removes the function that was added to the
	/// event delegate in OnEnable().
	/// </remarks>
	void OnDisable ()
	{
		BeatSynchronizer.OnAudioStart -= StartPatternCheck;
	}

	void Update ()
	{
	}

	/// <summary>
	/// This method checks if a beat has occurred in the pattern's sequence by comparing the current sample position of the audio  
	/// versus the next expected sample value. The frequency of the checks is controlled by the loopTime field.
	/// </summary>
	/// <remarks>
	/// The WaitForSeconds() yield statement places the execution of the coroutine right after the Update() call, so by 
	/// setting the loopTime to 0, this method will update as frequently as Update(). If even greater accuracy is 
	/// required, WaitForSeconds() can be replaced by WaitForFixedUpdate(), which will place this coroutine's execution
	/// right after FixedUpdate().
	/// </remarks>
	/// 
	/// 

	IEnumerator PatternCheck ()
	{
		while (audioSource.isPlaying) {
			currentSample = (float)AudioSettings.dspTime * audioSource.clip.frequency;
			
			if (currentSample >= nextBeatSample) {
				// Since this is a specific pattern of beats, we don't need to track different beat types.
				// Instead, client can index a custom beat counter to track which beat in the sequence has fired.
				
				//				foreach (GameObject obj in observers) {
				for (int i = 0; i < observers.Count; i++)
				{
					GameObject obj = observers[i];
					var objScript = obj.GetComponent<BeatObserver>();
				//	if (obj != null)
				//	{
				//		int beatValueIndex = (sequenceIndex - 1 == -1 ? beatvalues.Count -1 : sequenceIndex-1);
						objScript.BeatNotify();

				}
				nextBeatSample += samplePeriods[sequenceIndex];
				sequenceIndex = (++sequenceIndex == beatvalues.Count ? 0 : sequenceIndex);
				print (sequenceIndex + this.name);
			}
			
			yield return new WaitForSeconds(loopTime / 1000f);
		}
	}

}
