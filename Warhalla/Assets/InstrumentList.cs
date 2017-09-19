using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentList : MonoBehaviour {

	void Start () {
		List<Instrument> instrument_order = new List<Instrument>();

		instrument_order.Add( Instrument.None);
		instrument_order.Add( Instrument.None);
		instrument_order.Add( Instrument.None);
		for (int i = 0; i < 20; i++) {
			instrument_order.Add( RandomInstrument());
		}
		for (int i = 0; i < instrument_order.Count; i++) {
			Debug.Log (instrument_order[i]);
		}
	}

	Instrument RandomInstrument(){
		int instrument = Random.Range(0,3);
		return (Instrument) instrument;
	}

}
