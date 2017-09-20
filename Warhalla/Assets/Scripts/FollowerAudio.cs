using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FollowerAudio : MonoBehaviour {

	public AudioSource voices;
	private AudioClip[] voiceclips;
	private AudioMixer mixer;
	private float loudness = 0f;
	private bool doubled = false;
	private bool tripled = false;
	private int shoutCounter = 0;

	// Use this for initialization
	void Start () {
		voices = GetComponent<AudioSource>();
		mixer = voices.outputAudioMixerGroup.audioMixer;
		voiceclips = Resources.LoadAll<AudioClip>("Audio/Voices");
		MusicManager.OnBar += Yell;
	}
	
	// Update is called once per frame
	void Update () {
		//mixer.SetFloat("VoiceVolume", 1);'
		if(Input.GetKeyDown(KeyCode.L)){
			LoudnessUp();
		}
	}

	public void LoudnessUp(){
		print("louder!");
		loudness += 0.1f; // Tie this to progressmeter!
		if(loudness > 0.9f){
			if(!doubled){
				DoubleTempo();
			} else if(doubled && !tripled){
				TripleTempo();
			}
		}
	}

	public void DoubleTempo(){
		doubled = true;
		loudness = 0.3f;
		print("doubling");
		MusicManager.OnBar -= Yell;
		MusicManager.OnHalfBar += Yell;
	}

	public void TripleTempo(){
		tripled = true;
		loudness = 0.3f;
		print("tripling");
		MusicManager.OnHalfBar -= Yell;
		MusicManager.OnBeat += YellThreeOfFour;
	}

	void Yell(){
		//mixer.SetFloat("VoiceVolume", loudness++);
		voices.PlayOneShot(voiceclips[Random.Range(0, voiceclips.Length)], loudness);
	}

	void YellThreeOfFour(){
		if(shoutCounter % 3 != 0 && shoutCounter != 0){
			if(voices == null){
				voices = GetComponent<AudioSource>();
			} else {
				voices.PlayOneShot(voiceclips[Random.Range(0, voiceclips.Length)], loudness);		
			}
		}
		shoutCounter = (shoutCounter + 1 ) % 5;
	}

	void OnDestroy()
	{
		MusicManager.OnHalfBar -= Yell;
		MusicManager.OnBeat -= YellThreeOfFour;
		MusicManager.OnBar -= Yell;
	}
}
