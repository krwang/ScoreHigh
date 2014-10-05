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
		val -= 0.001f;
	}

	void increment(float value){
		val += value;
	}


	float get(){
		return val;
	}

}
