using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	private int SPEED = 5;
	private int direction = 0; // 0 : back, 1 : right, 2 : down, 3 : left
	private bool idle = true;
	private bool inBuilding = false;

	public Stats energy;
	public Stats food;

	public Building dining;
	public Building dorm;

	public Building building1;
	public Building building2;

	public Schedule schedule;

	Animator animator;
	BoxCollider2D boxcollider;
	// Use this for initialization
	void Start() {
		animator = GetComponent<Animator> ();
		boxcollider = GetComponent<BoxCollider2D> ();
		Debug.Log (boxcollider.bounds);
	}
	
	// Update is called once per frame


	void Update() {

		if (!inBuilding) {
			handleMovement ();
		}
		handleBuilding ();


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


	private void handleBuilding() {

		if (boxcollider.bounds.Intersects (dining.coll.bounds)) {
			idle = true;
			inBuilding = true;
			food.increment(0.001f);
			if (Input.GetKeyUp (KeyCode.Space) ) { renderer.transform.position = new Vector2(-10f, 6f); inBuilding = false;}

		} else if (boxcollider.bounds.Intersects (dorm.coll.bounds)) {
			idle = true;
			inBuilding = true;
			energy.increment(0.001f);
			if (Input.GetKeyUp (KeyCode.Space) ) { renderer.transform.position = new Vector2(-10f, 1.28f); inBuilding = false;}
		} else if (boxcollider.bounds.Intersects (building1.coll.bounds)) {
			idle = true;
			inBuilding = true;
			schedule.taskThree.workOnTask(0.01f);
			energy.increment(-0.0005f);
			food.increment(-0.0005f);
			if (Input.GetKeyUp (KeyCode.Space) ) { renderer.transform.position = new Vector2(-0.37f, 2.08f); inBuilding = false;;}
		} else if (boxcollider.bounds.Intersects (building2.coll.bounds)) {
			idle = true;
			inBuilding = true;
			schedule.taskTwo.workOnTask(0.02f);
			energy.increment(-0.0005f);
			food.increment(-0.0005f);
			if (Input.GetKeyUp (KeyCode.Space) ) { renderer.transform.position = new Vector2(-4.6f, -4f); inBuilding = false;}
		}
		animator.SetBool ("idle", idle);


	}
	
}
