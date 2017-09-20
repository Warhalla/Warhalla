using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentList : MonoBehaviour {

	private float vikingSpawnX;

	public GameObject viking_flute;
	public GameObject viking_harp;
	public GameObject viking_horn;
	private int index = 0;
	private List<Instrument> instrument_order;
	private List<GameObject> viking_order;
	private MusicManager music;

	public int viking_distance = 3;

	void Start () {
		instrument_order = new List<Instrument>();
		viking_order = new List<GameObject>();
		music = FindObjectOfType<MusicManager>();

		SpawnGap();SpawnGap();SpawnGap();
		for (int i = 0; i < 40; i++) {
			SpawnViking();
		}
		MusicManager.OnBar += IncrementIndex;
	}

	private void SpawnGap(){
		instrument_order.Add(Instrument.None);
		viking_order.Add(null);
	}	

	private void SpawnViking(){
		instrument_order.Add(RandomInstrument());
		int i = instrument_order.Count - 1;
		if (instrument_order [i] == Instrument.Flute) {
			viking_order.Add(Instantiate (viking_flute, new Vector2 (i * viking_distance, -1f), Quaternion.identity));
		} else if (instrument_order [i] == Instrument.Harp) {
			viking_order.Add(Instantiate (viking_harp, new Vector2 (i * viking_distance, -1f), Quaternion.identity));
		} else if (instrument_order [i] == Instrument.Horn) {
			viking_order.Add(Instantiate (viking_horn, new Vector2 (i * viking_distance, -1f), Quaternion.identity));
		} else {
			viking_order.Add(null);
		}
	}

	private void IncrementIndex(){
		index++;
		music.CheckInstrument();
		SpawnViking();
	}

	public Instrument GetCurrentInstrument(){
		return instrument_order[index];
	}

	public GameObject GetCurrentViking(){
		return viking_order[index];
	}

	Instrument RandomInstrument(){
		int instrument = Random.Range(0,4);
		return (Instrument) instrument;
	}

	void OnDestroy()
	{
		MusicManager.OnBar -= IncrementIndex;
	}
}
