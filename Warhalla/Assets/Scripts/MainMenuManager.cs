using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	float timer;
	bool startgame;
	float textLift;
	Vector3 backgroundPos;

	public Camera maincam;
	public GameObject fadePlane;
	public GameObject txt;
	public GameObject menuBackground;

	void Start(){
		startgame = false;
		textLift = txt.transform.GetComponent<RectTransform> ().position.y;
		backgroundPos = menuBackground.transform.position;
	}

	void Update () {
		if (Input.anyKey) {
			startgame = true;
		}
		backgroundPos = new Vector3 (backgroundPos.x + Time.deltaTime * -0.2f, backgroundPos.y, backgroundPos.z);
		menuBackground.transform.position = backgroundPos;
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
