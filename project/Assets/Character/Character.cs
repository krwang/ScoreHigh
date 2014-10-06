using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public int SPEED = 8;
	private int direction = 0; // 0 : back, 1 : right, 2 : down, 3 : left
	private bool idle = true;

	public DiningHall cafe;
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
		Movement();
		overlap ();
	}

	void Movement() {


		// move right
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector2.right * SPEED * Time.deltaTime);
			direction = 1;
			idle = false;
		// move left
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-1 * Vector2.right * SPEED * Time.deltaTime);
			direction = 3;
			idle = false;
		// move up
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (Vector2.up * SPEED * Time.deltaTime);
			direction = 0;
			idle = false;
		// move down
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (-1 * Vector2.up * SPEED * Time.deltaTime);
			direction = 2;
			idle = false;
		} else if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) 
		       || Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow) ) 
		{
			idle = true;
			
		}


		animator.SetBool ("idle", idle);
		animator.SetInteger ("direction", direction);
	}

	void overlap(){
		if(boxcollider.bounds.Intersects(cafe.coll.bounds)){
			Debug.Log("Eat");
		}
	}
}
