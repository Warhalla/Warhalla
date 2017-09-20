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
	private Sprite[] hitSprites;
	int hitIndex = 0;
	private Sprite[] moveSprites;
	int moveIndex = 1;
	private SpriteRenderer image;
	public GameObject[] playposes;

	void Start () {
		image = GetComponent<SpriteRenderer>();
		moveSprites = Resources.LoadAll<Sprite>("main_character/Walk");
		MusicManager.OnBar += BardMove;
	}

	void Update () {
		//this.transform.position = new Vector2(Mathf.Lerp(bard_x_from, bard_x_to, Time.time - start_time), this.transform.position.y);
		this.transform.position = new Vector2(Mathf.Lerp(bard_x_from, bard_x_to, timer), this.transform.position.y);
		timer += Time.deltaTime * bard_move_speed;
	}

	void BardMove(){
		if(image.enabled == false){
			image.enabled = true;
			DisableAnimations();
		}
		image.sprite = moveSprites[moveIndex % 2];
		moveIndex++;
		bard_x_from = this.transform.position.x;
		bard_x_to = bard_x_from + bard_move_lenth;
		start_time = Time.time;
		timer = 0;
	}

	void DisableAnimations(){
		foreach(GameObject g in playposes){
			g.SetActive(false);
		}
	}

	public void Play(Instrument instrument){
		print("playing");
		StartCoroutine(waitAndPlay(instrument));
	}

	IEnumerator waitAndPlay(Instrument instrument){
		yield return new WaitForSeconds(0.1f);
		image.enabled = false;
		playposes[(int)instrument].SetActive(true);
	}

	void OnDestroy()
	{
		MusicManager.OnBar -= BardMove;
	}

}
