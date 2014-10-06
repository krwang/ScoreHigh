using UnityEngine;
using System.Collections;


public class Stats_GUI : MonoBehaviour {
	public Stats stat;
	public GameObject stat_background;
	public GameObject stat_foreground;
	public GameObject stat_text;
	private TextMesh stat_text_mesh;

	void Start () {
		stat_text_mesh = stat_text.GetComponent<TextMesh> ();
	}

	void Update() {
		stat_foreground.transform.localScale = new Vector3(stat.val,1,1);
		stat_text_mesh.text = stat.stat_name + ": " + System.String.Format("{0:P}",stat.val);

	}
}
