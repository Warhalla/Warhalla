using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapSpriteOnBeat : MonoBehaviour {

	public Sprite sprite1;
	public Sprite sprite2;
	private SpriteRenderer image;

	private bool swapped = false;

	public bool faster = false;

	// Use this for initialization
	void Start () {
		image = GetComponent<SpriteRenderer>();
		if(faster){
			MusicManager.OnBeat += Swap;
		} else{
			MusicManager.OnHalfBar += Swap;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Swap(){
		if(!swapped){
			image.sprite = sprite1;
		} else {
			image.sprite = sprite2;
		}
		swapped = !swapped;
	}
	void OnDestroy()
	{
		if(faster){
			MusicManager.OnBeat -= Swap;
		} else{
			MusicManager.OnHalfBar -= Swap;
		}
	}
}
