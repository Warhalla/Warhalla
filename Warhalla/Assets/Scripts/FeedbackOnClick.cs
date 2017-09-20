using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackOnClick : MonoBehaviour {

	private bool selected;
	public GameObject canvas;
	public AnimationCurve animUp;
	public AnimationCurve animDown;

	IEnumerator AnimationScaleUp(){
		float time = 0;
		while (time < 0.25) {
			time += Time.deltaTime;
			this.transform.localScale = new Vector3 (animUp.Evaluate (time), animUp.Evaluate (time), 1);
			yield return new WaitForEndOfFrame();
		}
	}

	IEnumerator AnimationScaleDown(){
		float time = 0;
		while (time < 0.25) {
			time += Time.deltaTime;
			this.transform.localScale = new Vector3 (animDown.Evaluate (time), animDown.Evaluate (time), 1);
			yield return new WaitForEndOfFrame();
		}
	}
		
	public void StretchOnClick(){
		GameObject previousBtn = canvas.GetComponent<ButtonFeedbackManager> ().previousSelectedButton;
		GameObject selectedBtn = canvas.GetComponent<ButtonFeedbackManager> ().selectedButton;
		if(selectedBtn != null){
			previousBtn = selectedBtn;
			previousBtn.transform.GetComponent<FeedbackOnClick> ().Shrink ();
		}
		canvas.GetComponent<ButtonFeedbackManager> ().selectedButton = this.gameObject;
		StartCoroutine(AnimationScaleUp());
		MusicManager.OnBar += ShrinkOnBeat;
	}

	public void Shrink(){
		StartCoroutine (AnimationScaleDown());
	}

	public void ShrinkOnBeat(){
		GameObject selectedBtn = canvas.GetComponent<ButtonFeedbackManager> ().selectedButton;
		if (this.gameObject == selectedBtn) {
			canvas.GetComponent<ButtonFeedbackManager> ().selectedButton = null;
			StartCoroutine (AnimationScaleDown ());
			MusicManager.OnBar -= ShrinkOnBeat;
		}
	}

	void OnDestroy()
	{
		MusicManager.OnBar -= ShrinkOnBeat;
	}
}
