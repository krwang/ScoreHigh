using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	public BoxCollider2D coll;
	public string location;
	public Character player;
	public bool isInside; 

	public Schedule schedule;
	public int taskIdx;

	// Use this for initialization
	void Start () {
		coll = GetComponent<BoxCollider2D> ();
		isInside = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isInside && schedule != null) {
			schedule.taskList [taskIdx].workOnTask (0.01f);
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		isInside = true;

		// make player invisible
		//player.renderer.enabled = false;
	}

	void OnTriggerExit2D(Collider2D other) {
		isInside = false;
	}

}
