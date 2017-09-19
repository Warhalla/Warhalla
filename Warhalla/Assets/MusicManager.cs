using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public delegate void BeatAction();
    public static event BeatAction OnBeat;

	private AudioSource backgroundMusic;
	private bool loopedQuant = false;
	private bool loopedBeat = false;

	// Use this for initialization
	void Start () {
		backgroundMusic = GetComponent<AudioSource>();
		StartCoroutine(BeatEverySecond());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator BeatEverySecond(){
		while(true){
			yield return new WaitForSeconds(1f);
			print("beat");
			OnBeat();
		}
	}

	void CheckBeat(){
		if ((Mathf.Min(backgroundMusic.timeSamples % 12000, Mathf.Abs((backgroundMusic.timeSamples % 12000) - 12000)) < 2000) && !loopedQuant) {
			loopedQuant = true;
			//beat.ReportHalfBeat();
		}
		if (backgroundMusic.timeSamples % 12000 > 6000 && Mathf.Abs((backgroundMusic.timeSamples % 12000) - 12000) > 4000) {
			loopedQuant = false;
		}
		
		if ((Mathf.Min(backgroundMusic.timeSamples % 24000, Mathf.Abs((backgroundMusic.timeSamples % 24000) - 24000)) < 2000) && !loopedBeat) {
			loopedBeat = true;
			OnBeat();
		}
		if (backgroundMusic.timeSamples % 24000 > 12000 && Mathf.Abs((backgroundMusic.timeSamples % 24000) - 24000) > 4000) {
			loopedBeat = false;
		}	
	}
}
