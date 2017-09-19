using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkOnBeat : MonoBehaviour {

	private Button button;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button>();
		MusicManager.OnBeat += Blink;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Blink(){
		button.interactable = !button.interactable;
	}

	void OnDestroy()
	{
		MusicManager.OnBeat -= Blink;
	}
}
