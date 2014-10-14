using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
	public float val;
	public string stat_name;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (val < 0) {
			Application.LoadLevel(1);
		}
	}

	public void increment(float value){
		val += value;
		if (val > 1) {
			val = 1;		
		}
	}


	float get(){
		return val;
	}

}
