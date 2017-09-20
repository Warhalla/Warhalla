using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public delegate void BeatAction();
    public static event BeatAction OnBar;
	public static event BeatAction OnHalfBar;
	public static event BeatAction OnBeat;

	private int beatCounter = 0;

	private AudioSource backgroundMusic;
	public AudioSource[] instruments;
	private bool loopedQuant = false;
	private bool loopedBeat = false;

	private Instrument activeInstrument = Instrument.None;
	private AudioClip[] harps;
	private AudioClip[] flutes;
	private AudioClip[] horns;
	private InstrumentList instrumentList;
	private GameObject player;
	private ProgressUpdate progressBar;
	private int progress = 10;

	private BardMovement moveScript;
	private GameObject canvas;
	public GameObject victoryObj;

	// Use this for initialization
	void Start () {
		backgroundMusic = GetComponent<AudioSource>();
		instrumentList = FindObjectOfType<InstrumentList>();
		harps = Resources.LoadAll<AudioClip>("Audio/Harp");
		flutes = Resources.LoadAll<AudioClip>("Audio/Flute");
		horns = Resources.LoadAll<AudioClip>("Audio/Horn");
		player = GameObject.FindGameObjectWithTag("Player");
		moveScript = player.GetComponent<BardMovement>();
		progressBar = FindObjectOfType<ProgressUpdate>();
		canvas = GameObject.Find ("Canvas");
	}

	public void UpdateActiveInstrument(Instrument instrument){
		activeInstrument = instrument;
	}

	public void CheckInstrument(){
		if(instrumentList.GetCurrentInstrument() == activeInstrument && activeInstrument != Instrument.None){
			Correct();
		} else if(instrumentList.GetCurrentInstrument() == Instrument.None){
		} else {
			Incorrect();
		}
		activeInstrument = Instrument.None;
		progressBar.UpdateProgress();
	}
	
	private void Correct(){
		if(progress == 24){
			print("victory");
			progress = 10;
			GameObject victory = Instantiate (victoryObj, new Vector3 (0, 0, 0), Quaternion.identity);
			for (int i = 0; i < canvas.transform.GetChildCount (); i++) {
				canvas.gameObject.transform.GetChild (i).gameObject.SetActive (false);
			}
			victory.transform.parent = canvas.transform;
			victory.GetComponent<RectTransform> ().localPosition = new Vector3 (0,0,0);
			// Load something
		}
		progress++;
		GameObject viking = instrumentList.GetCurrentViking();
		viking.transform.parent = player.transform;
		viking.transform.localPosition = new Vector3(Random.Range(-3f, -7f), Random.Range(-4f, 0f), 0);
		viking.transform.rotation = new Quaternion(0,180,0,0);
		viking.GetComponent<SpriteRenderer>().sortingOrder = -(int)(viking.transform.localPosition.y * 10);
		viking.SendMessage("StartWalking");
		player.SendMessage("LoudnessUp"); // Tie this to progressmeter instead
		PlayInstrument();
	}

	private void PlayInstrument(){
		if(activeInstrument == Instrument.Harp){
			PlaySound(instruments[(int) activeInstrument], harps);
			moveScript.Play(Instrument.Harp);
		} else if(activeInstrument == Instrument.Flute){
			PlaySound(instruments[(int) activeInstrument],flutes);
			moveScript.Play(Instrument.Flute);
		} else if(activeInstrument == Instrument.Horn){
			PlaySound(instruments[(int) activeInstrument],horns);
			moveScript.Play(Instrument.Horn);
		}
	}

	private void PlaySound(AudioSource audioSource, AudioClip[] clips){
		audioSource.PlayOneShot(clips[Random.Range(0, clips.Length)], 0.5f);
	}

	private void Incorrect(){
		if(progress < 2){
			print("game over!");
			progress = 10;
			SceneManager.LoadScene("Main_menu");
		}
		progress -= 2;
		//correct.color = Color.red;
	}

	public int GetProgress(){
		//print(progress);
		return progress;
	}

	public Instrument GetActiveInstrument(){
		return activeInstrument;
	}

	// Update is called once per frame
	void Update () {
		CheckBeat();
	}

	void CheckBeat(){
		if ((Mathf.Min(backgroundMusic.timeSamples % 21818, Mathf.Abs((backgroundMusic.timeSamples % 21818) - 21818)) < 2000) && !loopedBeat) {
			loopedBeat = true;
			OnBeat();
			beatCounter++;
			if(beatCounter % 2 == 0){
				OnHalfBar();
			}
			if(beatCounter % 4 == 0){
				OnBar();
			}
		}
		if (backgroundMusic.timeSamples % 21818 > 12000 && Mathf.Abs((backgroundMusic.timeSamples % 21818) - 21818) > 4000) {
			loopedBeat = false;
		}	
	}
}
