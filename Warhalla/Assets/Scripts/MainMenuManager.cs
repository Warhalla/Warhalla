using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	float timer;
	bool startgame;
	float textLift;

	public Camera maincam;
	public GameObject fadePlane;
	public GameObject txt;

	void Start(){
		startgame = false;
		textLift = txt.transform.GetComponent<RectTransform> ().position.y;
	}

	void Update () {
		if (Input.anyKey) {
			startgame = true;
		}
		if (startgame) {
			timer += Time.deltaTime;
			maincam.GetComponent<Camera> ().orthographicSize -= Time.deltaTime * 0.5f;
			Color tmp = fadePlane.GetComponent<SpriteRenderer>().color;
			tmp.a = timer;
			fadePlane.GetComponent<SpriteRenderer>().color = tmp;

			textLift += timer * 1;
			Vector3 txtPos = new Vector3 (315.5f, textLift, 0);
			txt.transform.GetComponent<RectTransform> ().position = txtPos;

			if (timer > 1f) {
				SceneManager.LoadScene ("Game", LoadSceneMode.Single);
			}
		}
	}
}
