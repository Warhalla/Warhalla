using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryObject : MonoBehaviour {

	public AudioClip victoryClip;
	public AudioSource audiosource;

	void Awake(){
		audiosource.PlayOneShot (victoryClip, 0.75f);
	}

	void Update () {
		if (Input.anyKey ) {
			SceneManager.LoadScene ("Main_menu", LoadSceneMode.Single);
		}
	}
}
