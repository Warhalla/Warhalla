using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomInstrumentOnBeat : MonoBehaviour {

	private Text text;
	public Image correct;
	private Instrument requiredInstrument = Instrument.None;
	private MusicManager music;

	// Use this for initialization
	void Start () {
		music = FindObjectOfType<MusicManager>();
		text = GetComponent<Text>();
		MusicManager.OnBar += UpdateText;
	}
	
	void UpdateText(){
		if(requiredInstrument == music.GetActiveInstrument()){
			correct.color = Color.green;
		} else {
			correct.color = Color.red;
		}
		music.ResetInstrument();
		requiredInstrument = RandomInstrument();
		text.text = requiredInstrument.ToString();
	}

	Instrument RandomInstrument(){
		int instrument = Random.Range(0,3);
		return (Instrument) instrument;
	}
}
