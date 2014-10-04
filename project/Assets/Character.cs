using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public int SPEED = 1;
	private int direction = 0; // 0 : forward, 1 : right, 2 : up/back, 3 : left

	Animator animator;

	// Use this for initialization
	void Start() {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update() {
		Movement();
	}

	void Movement() {
		// move right
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector2.right * SPEED * Time.deltaTime);
			direction = 0;
		// move left
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-1 * Vector2.right * SPEED * Time.deltaTime);
			direction = 3;
		// move up
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (Vector2.up * SPEED * Time.deltaTime);
			direction = 2;
		// move down
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (-1 * Vector2.up * SPEED * Time.deltaTime);
			direction = 1;
		}

	}
}
