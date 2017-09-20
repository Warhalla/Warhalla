using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BardMovement : MonoBehaviour {

	public float bard_move_lenth;
	public float bard_move_speed;
	private float bard_x_from;
	private float bard_x_to;
	private float start_time;
	private float timer;

	void Start () {
		MusicManager.OnBar += BardMove;
	}

	void Update () {
		//this.transform.position = new Vector2(Mathf.Lerp(bard_x_from, bard_x_to, Time.time - start_time), this.transform.position.y);
		this.transform.position = new Vector2(Mathf.Lerp(bard_x_from, bard_x_to, timer), this.transform.position.y);
		timer += Time.deltaTime * bard_move_speed;
	}

	void BardMove(){
		bard_x_from = this.transform.position.x;
		bard_x_to = bard_x_from + bard_move_lenth;
		start_time = Time.time;
		timer = 0;
	}


	void OnDestroy()
	{
		MusicManager.OnBar -= BardMove;
	}

}
