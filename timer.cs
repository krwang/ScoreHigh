using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {
	float timeLeft = 30.0f;

	// Use this for initialization
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			guiText.text = "Hello";
		}

	}
}
