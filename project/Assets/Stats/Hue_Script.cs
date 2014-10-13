using UnityEngine;
using System.Collections;

public class Hue_Script : MonoBehaviour {
	private float alpha = 0;
	private bool started = false;
	private MeshRenderer meshrenderer;

	// Use this for initialization
	void Start () {
		meshrenderer = this.gameObject.GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Color current_color = meshrenderer.material.color;
		meshrenderer.material.color = new Color (current_color.r, current_color.g, current_color.b, alpha/255.0f);
		if (started & alpha < 255.0f) {
			alpha += 5.0f;
		} else if (alpha > 0.0f) {
			alpha -= 2.5f;
		}
	}

	public void start(){
		started = true;
	}

	public void end(){
		started = false;
	}
}
