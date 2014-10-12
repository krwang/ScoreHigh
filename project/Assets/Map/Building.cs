using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	public BoxCollider2D coll;
	public string location;
	// Use this for initialization
	void Start () {
		coll = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("in a buidling");
	}
}
