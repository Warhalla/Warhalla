using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkOnBeat : MonoBehaviour {

	private Button button;
	public int timeMeasure;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button>();
		if(timeMeasure == 0){
			MusicManager.OnBeat += Blink;
		} else if(timeMeasure == 1){
			MusicManager.OnHalfBar += Blink;
		} else {
			MusicManager.OnBar += Blink;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Blink(){
		button.interactable = !button.interactable;
	}

	void OnDestroy()
	{
		if(timeMeasure == 0){
			MusicManager.OnBeat -= Blink;
		} else if(timeMeasure == 1){
			MusicManager.OnHalfBar -= Blink;
		} else {
			MusicManager.OnBar -= Blink;
		}
	}
}
