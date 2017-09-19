﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

	public delegate void BeatAction();
    public static event BeatAction OnBar;
	public static event BeatAction OnHalfBar;
	public static event BeatAction OnBeat;

	private int beatCounter = 0;

	private AudioSource backgroundMusic;
	private bool loopedQuant = false;
	private bool loopedBeat = false;

	private Instrument activeInstrument = Instrument.None;
	public Image correct;

	private AudioClip[] harps;
	private AudioClip[] flutes;
	private InstrumentList instrumentList;

	// Use this for initialization
	void Start () {
		backgroundMusic = GetComponent<AudioSource>();
		instrumentList = FindObjectOfType<InstrumentList>();
		harps = Resources.LoadAll<AudioClip>("Audio/Harp");
		flutes = Resources.LoadAll<AudioClip>("Audio/Flute");
	}

	public void UpdateActiveInstrument(Instrument instrument){
		activeInstrument = instrument;
	}

	public void CheckInstrument(){
		if(instrumentList.GetCurrentViking() == activeInstrument){
			Correct();
		} else {
			Incorrect();
		}
		activeInstrument = Instrument.None;
	}
	
	private void Correct(){
		correct.color = Color.green;
		if(activeInstrument == Instrument.Harp){
			PlaySound(harps);
		} else if(activeInstrument == Instrument.Flute){
			PlaySound(flutes);
		}
	}

	private void PlaySound(AudioClip[] clips){
		backgroundMusic.PlayOneShot(clips[Random.Range(0, clips.Length)], 0.5f);
	}

	private void Incorrect(){
		correct.color = Color.red;
	}

	public Instrument GetActiveInstrument(){
		return activeInstrument;
	}

	// Update is called once per frame
	void Update () {
		CheckBeat();
	}

	void CheckBeat(){
		if ((Mathf.Min(backgroundMusic.timeSamples % 21818, Mathf.Abs((backgroundMusic.timeSamples % 21818) - 21818)) < 2000) && !loopedBeat) {
			loopedBeat = true;
			OnBeat();
			beatCounter++;
			if(beatCounter % 2 == 0){
				OnHalfBar();
			}
			if(beatCounter % 4 == 0){
				OnBar();
			}
		}
		if (backgroundMusic.timeSamples % 21818 > 12000 && Mathf.Abs((backgroundMusic.timeSamples % 21818) - 21818) > 4000) {
			loopedBeat = false;
		}	
	}
}
