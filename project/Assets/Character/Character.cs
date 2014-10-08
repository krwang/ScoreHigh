using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public int SPEED = 8;
	private int direction = 0; // 0 : back, 1 : right, 2 : down, 3 : left
	private bool idle = true;

	public Stats energy;
	public Stats food;

	public Building dining;
	public Building dorm;

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
		overlap ();
		Movement();
	}

	void Movement() {


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

	void overlap(){
		if (boxcollider.bounds.Intersects (dining.coll.bounds)) {
			food.increment(0.2f);
			renderer.transform.position = new Vector2(-10f,6f);
		} else if (boxcollider.bounds.Intersects (dorm.coll.bounds)) {
			energy.increment(0.2f);
			renderer.transform.position = new Vector2(-10f,1.28f);
		}
	}
}
