using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressUpdate : MonoBehaviour {

	Sprite[] bar;
	private MusicManager music;
	public Image image;

	// Use this for initialization
	void Start () {
		bar = Resources.LoadAll<Sprite>("ProgressBar");
		music = FindObjectOfType<MusicManager>();
		UpdateProgress();
	}
	
	// Update is called once per frame
	public void UpdateProgress () {
		if(music == null){
			music = FindObjectOfType<MusicManager>();
		}
		int index = Mathf.Clamp(music.GetProgress() / 2, 0, bar.Length - 1);
		if(image != null){
			image.sprite = bar[index];
		}
	}
}
