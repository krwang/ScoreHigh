using UnityEngine;
using System.Collections;

//To use:
//In game, drag a progressbar prefab from assets to the place you want it to be.
//in script, decalre a public gameobject variable.
//In game, point the game object to the progressbar on the scene.
//In script, change progressbar.val to change the filling. Change progressbar.text to change the text.

public class Progress_bar : MonoBehaviour {
	public float val;	//should be a percent value (0 -> 100%)
	public string text; //this text is shown on the progress bar.
	public GameObject background;
	public GameObject foreground;
	public GameObject text_gameobject;
	private TextMesh stat_text_mesh;


	void Start () {
		stat_text_mesh = text_gameobject.GetComponent<TextMesh> ();
	}

	void Update() {
		foreground.transform.localScale = new Vector3(val,1,1);
		stat_text_mesh.text = text;


	}
	void hide(){
		background.renderer.enabled = false;
		foreground.renderer.enabled = false;
		stat_text_mesh.renderer.enabled = false;
	}

	void show(){
		background.renderer.enabled = true;
		foreground.renderer.enabled = true;
		stat_text_mesh.renderer.enabled = true;
	}
}
