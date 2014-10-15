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
			// If the player loses, set value to -1
			// else set value to their final score
			PlayerPrefs.SetInt("Win/Lose", -1);
			Application.LoadLevel("endScreen");
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
