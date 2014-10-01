using UnityEngine;
using System.Collections;

public class Schedule : MonoBehaviour {
	public float projectThree;
	public float projectTwo;
	public float projectOne;

	// Use this for initialization
	void Start () {
		projectOne = 1f;
		projectTwo = 1f;
		projectThree = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		projectOne -= 0.02f;
	
	}
}
