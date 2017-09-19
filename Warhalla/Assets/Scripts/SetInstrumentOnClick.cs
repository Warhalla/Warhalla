using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInstrumentOnClick : MonoBehaviour {

	public Instrument instrument;
	private MusicManager music;
	private Button button;

	// Use this for initialization
	void Start () {
		music = FindObjectOfType<MusicManager>();
		button = GetComponent<Button>();
		button.onClick.AddListener(UpdateInstrument);
	}

	void UpdateInstrument(){
		music.UpdateActiveInstrument(instrument);
	}
}
