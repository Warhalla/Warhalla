﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			SceneManager.LoadScene ("Game", LoadSceneMode.Single);
		}
	}
}