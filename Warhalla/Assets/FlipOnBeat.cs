using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipOnBeat : MonoBehaviour {

	private bool flipped = false;

	// Use this for initialization
	void Start () {
		MusicManager.OnBeat += Flip;
	}

	void Flip(){
		if(!flipped){
			transform.rotation = new Quaternion(0,180,0,0);
		} else {
			transform.rotation = new Quaternion(0,0,0,0);
		}
		flipped = !flipped;
	}
}
