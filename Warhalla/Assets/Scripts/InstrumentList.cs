using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentList : MonoBehaviour {

	private float vikingSpawnX;

	public GameObject viking_flute;
	public GameObject viking_harp;
	public GameObject viking_horn;

	void Start () {
		List<Instrument> instrument_order = new List<Instrument>();

		instrument_order.Add( Instrument.None);
		instrument_order.Add( Instrument.None);
		instrument_order.Add( Instrument.None);
		for (int i = 0; i < 40; i++) {
			instrument_order.Add( RandomInstrument());
		}
		for (int i = 0; i < instrument_order.Count; i++) {
			if (instrument_order [i] == Instrument.Flute) {
				Instantiate (viking_flute, new Vector2 (i * 2, 0), Quaternion.identity);
			}
			if (instrument_order [i] == Instrument.Harp) {
				Instantiate (viking_harp, new Vector2 (i * 2, 0), Quaternion.identity);
			}
			if (instrument_order [i] == Instrument.Horn) {
				Instantiate (viking_horn, new Vector2 (i * 2, 0), Quaternion.identity);
			}
		}
	}

	Instrument RandomInstrument(){
		int instrument = Random.Range(0,3);
		return (Instrument) instrument;
	}

}
