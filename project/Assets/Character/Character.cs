using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	private int SPEED = 5;
	public int direction = 0; // 0 : back, 1 : right, 2 : down, 3 : left
	public bool idle = true;

	public Stats energy;
	public Stats food;

	public Building dining;
	public Building dorm;

	public Building building1;
	public Building building2;

	public Schedule schedule;

	public Animator animator;

	// Use this for initialization
	void Start() {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame


	void Update() {

		handleMovement ();

	}

	private void handleMovement() {
		// move right
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector2.right * SPEED * Time.deltaTime);
			direction = 1;
			idle = false;
			energy.increment(-0.0001f);
			food.increment(-0.0001f);
			// move left
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-1 * Vector2.right * SPEED * Time.deltaTime);
			direction = 3;
			idle = false;
			energy.increment(-0.0001f);
			food.increment(-0.0001f);
			// move up
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (Vector2.up * SPEED * Time.deltaTime);
			direction = 0;
			idle = false;
			energy.increment(-0.0001f);
			food.increment(-0.0001f);
			// move down
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (-1 * Vector2.up * SPEED * Time.deltaTime);
			direction = 2;
			idle = false;
			energy.increment(-0.0001f);
			food.increment(-0.0001f);
		} else if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) 
		           || Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow) ) 
		{
			idle = true;
			
		}
		
		
		animator.SetBool ("idle", idle);
		animator.SetInteger ("direction", direction);
	}


}
