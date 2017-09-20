using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	float timer;
	bool startgame;

	public Camera maincam;
	public GameObject background;

	void Start(){
		startgame = false;
	}

	void Update () {
		if (Input.anyKey) {
			startgame = true;
		}
		if (startgame) {
			timer += Time.deltaTime;
			maincam.GetComponent<Camera> ().orthographicSize -= Time.deltaTime;
			if (timer > 1f) {
				SceneManager.LoadScene ("Game", LoadSceneMode.Single);
			}
		}
	}
}
