using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {
	public GameObject button;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseOver() {
		this.renderer.material.color = Color.green;
	}

	void OnMouseExit() {
		this.renderer.material.color = Color.white;
	}
}
