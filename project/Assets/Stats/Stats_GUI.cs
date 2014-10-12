using UnityEngine;
using System.Collections;


public class Stats_GUI : MonoBehaviour {
	public Stats stat;
	public GameObject stat_background;
	public GameObject stat_foreground;
	public GameObject stat_text;
	public Hue_Script Huescript;
	public int flash_freq;
	public float flash_threshold = 0.1f;
	private TextMesh stat_text_mesh;
	private bool flashing = false;
	private int flash_counter = 0;


	void Start () {
		stat_text_mesh = stat_text.GetComponent<TextMesh> ();
	}

	void Update() {
		stat_foreground.transform.localScale = new Vector3(stat.val,1,1);
		stat_text_mesh.text = stat.stat_name + ": " + System.String.Format("{0:P}",stat.val);

		if (stat.val < flash_threshold) {
			flashing = true;
		}

		if (stat.val > flash_threshold) {
			flash_counter = 0;
			flashing = false;
		}

		if (flashing & (flash_counter % flash_freq) < (flash_freq / 2)) {
			hide (); 
			flash_counter += 1;
		} else if (flashing) {
			show ();
			flash_counter += 1;
		} else {
			show ();
		}
	}
	void hide(){
		stat_background.renderer.enabled = false;
		stat_foreground.renderer.enabled = false;
		stat_text_mesh.renderer.enabled = false;
		Huescript.start ();
	}

	void show(){
		stat_background.renderer.enabled = true;
		stat_foreground.renderer.enabled = true;
		stat_text_mesh.renderer.enabled = true;
		Huescript.end ();
	}
}
