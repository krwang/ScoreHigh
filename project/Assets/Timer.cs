using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	float timeLeft;

	// Use this for initialization
	void Start () {
		timeLeft = 100.0f;
	}
	
	void Update()
	{
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			// Game Over
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

}

