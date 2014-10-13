using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {
	public int day, hours, minutes;
	float seconds;
	TextMesh time;
	int speed;
	
	// Use this for initialization
	void Start () {
		hours   = 8;
		minutes = 0;
		seconds = 0;
		day     = 1;
		speed   = 5;
		
		time = this.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update()
	{
		seconds += Time.deltaTime * speed;
		
		if (seconds >= 1) {
			minutes += 1;
			seconds = 0;
		}
		if (minutes >= 60) {
			hours += 1;
			minutes = 0;
		}
		
		if (hours >= 24) {
			hours = 0;
			day += 1;
		}
		
		if (minutes < 10) {
			time.text = "Day " + day + "\n" + hours + ":0" + minutes;
		} else {
			time.text = "Day " + day + "\n" + hours + ":" + minutes;
		}
		
	}
}
