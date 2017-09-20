using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateToMusic : MonoBehaviour {

	private Sprite[] hitSprites;
	int hitIndex = 0;
	private Sprite[] moveSprites;
	int moveIndex = 0;
	private SpriteRenderer image;
	private bool walking = false;
	public string pathToFolders;
	public int variation;

	// Use this for initialization
	void Start () {
		image = GetComponent<SpriteRenderer>();
		hitSprites = Resources.LoadAll<Sprite>("Vikings/" + pathToFolders + variation + "/Hit");
		moveSprites = Resources.LoadAll<Sprite>("Vikings/" + pathToFolders + variation + "/Move");
		MusicManager.OnBeat += ProgressAnimation;
		hitIndex = Random.Range(0,4);
	}


	void ProgressAnimation(){
		if(!walking){
			hitIndex++;
			image.sprite = hitSprites[hitIndex % 4];
		} else if(moveSprites.Length > 0) {
			moveIndex++;
			image.sprite = moveSprites[moveIndex % 2];
		} else {
			hitIndex++;
			image.sprite = hitSprites[hitIndex % 4];	
		}
	}

	void StartWalking(){
		walking = true;
	}
	
	/// <summary>
	/// This function is called when the MonoBehaviour will be destroyed.
	/// </summary>
	void OnDestroy()
	{
		MusicManager.OnBeat -= ProgressAnimation;
	}
}
