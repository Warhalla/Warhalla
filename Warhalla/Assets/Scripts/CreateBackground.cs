using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBackground : MonoBehaviour {

	GameObject[] backgrounds;
	int[][] triplets;

	// Use this for initialization
	void Start () {
		backgrounds = Resources.LoadAll<GameObject>("Backgrounds");
		List<GameObject> creationList = new List<GameObject>();
		for(int i = 0; i < 2;i++){
			int[] triplet = randomTriplet();
			creationList.Add(backgrounds[triplet[0]]);
			creationList.Add(backgrounds[triplet[1]]);
			creationList.Add(backgrounds[triplet[2]]);
		}
		for(int i = 0; i < creationList.Count; i++){
			Instantiate(creationList[i],transform.position + Vector3.right * i * 48,Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	int[] randomTriplet(){
		int[][] triplets = {new int[]{0,1,2},
			new int[]{0,2,1},
			new int[]{1,0,2},
			new int[]{1,2,0},
			new int[]{2,0,1},
			new int[]{2,1,0}
		};
		return triplets[Random.Range(0, triplets.Length)];
	}
}
