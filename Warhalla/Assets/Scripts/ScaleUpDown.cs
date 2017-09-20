using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpDown : MonoBehaviour {

	public AnimationCurve animUp;
	public AnimationCurve animDown;

	void Start(){
		MusicManager.OnBar += ScaleUpOnBar;
		MusicManager.OnHalfBar += ScaleDownOnHalfBar;
	}

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


	public void ScaleUpOnBar(){
		StartCoroutine (AnimationScaleUp ());
	}

	public void ScaleDownOnHalfBar(){
		StartCoroutine (AnimationScaleDown ());
	}


	void OnDestroy()
	{
		MusicManager.OnBar -= ScaleUpOnBar;
		MusicManager.OnHalfBar -= ScaleDownOnHalfBar;
	}
}
