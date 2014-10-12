using UnityEngine;
using System.Collections;

public class Dorm : MonoBehaviour {
	private Stats energy;
	private bool isInside = false;

	// Use this for initialization
	void Start () {
		energy = (Stats) GameObject.Find ("Energy").GetComponent("Stats");

	}
	
	// Update is called once per frame
	void Update () {
		if (isInside) {
			energy.increment(0.001f);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("in dorm");
		isInside = true;
	}
	
	void OnTriggerExit2D(Collider2D other) {
		isInside = false;
	}
}
