using UnityEngine;
using System.Collections;

public class DiningHall : MonoBehaviour {
	//public BoxCollider2D coll;
	private Stats food;
	private bool isInside = false;

	// Use this for initialization
	void Start () {
		//coll = GetComponent<BoxCollider2D> ();
		food = (Stats) GameObject.Find ("Food").GetComponent("Stats");
	}
	
	// Update is called once per frame
	void Update () {
		if (isInside) {
			food.increment(0.001f);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		isInside = true;
	}

	void OnTriggerExit2D(Collider2D other) {
		isInside = false;
	}
}
