using UnityEngine;
using System.Collections;


public class Stats_GUI : MonoBehaviour {
	public Stats stat;
	public GameObject stat_background;
	public GameObject stat_foreground;

	void Start () {
	}

	void Update() {
		stat_foreground.transform.localScale = new Vector3(stat.val,1,1);
	}
}
