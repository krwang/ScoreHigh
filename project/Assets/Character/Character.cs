using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	private int SPEED = 5;
	public int direction = 0; // 0 : back, 1 : right, 2 : down, 3 : left
	public bool idle = true;
	public bool move = true;
	public Stats energy;
	public Stats food;

	public Schedule schedule;

	public Animator animator;

	// Use this for initialization
	void Start() {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame


	void Update() {
		if (move) {
			handleMovement ();		
		}

	}

	private void handleMovement() {
		// move right
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector2.right * SPEED * Time.deltaTime);
			direction = 1;
			idle = false;
			energy.increment(-0.0001f);
			food.increment(-0.0001f);
			// move left
		} else if (Input.GetKey (KeyCode.LeftArrow)|| Input.GetKey (KeyCode.A)) {
			transform.Translate (-1 * Vector2.right * SPEED * Time.deltaTime);
			direction = 3;
			idle = false;
			energy.increment(-0.0001f);
			food.increment(-0.0001f);
			// move up
		} else if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector2.up * SPEED * Time.deltaTime);
			direction = 0;
			idle = false;
			energy.increment(-0.0001f);
			food.increment(-0.0001f);
			// move down
		} else if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
			transform.Translate (-1 * Vector2.up * SPEED * Time.deltaTime);
			direction = 2;
			idle = false;
			energy.increment(-0.0001f);
			food.increment(-0.0001f);
		} else if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) 
		           || Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow)
		           || Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.A)
		           || Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.D)) 
		{
			idle = true;
			
		}
		
		
		animator.SetBool ("idle", idle);
		animator.SetInteger ("direction", direction);
	}


}
