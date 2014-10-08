﻿using UnityEngine;
using System.Collections;

public class MITClass 
{
	public string className;
	public string courseNumber;
	public string task;
	public string location;
	public float minutesDue;
	
	public MITClass(string name, string number, string building, string assignment, float deadline)
	{
		className = name;
		courseNumber = number;
		location = building;
		task = assignment;
		minutesDue = deadline;
	}

	public void runClock (float minutesPassed)
	{
		Debug.Log("Counting down"); 
		//I use the .1f multiplier to slow the time decay down
		if(minutesDue - minutesPassed * .1f < 0)
		{
			minutesDue = 0;
		}
		else{
			minutesDue -= minutesPassed * .1f;
		}
	}

	public void TaskExtension(float timeExtended)
	{
		minutesDue += timeExtended;
	}

	public string toString() {
		return className + " " + courseNumber + "\n"
				+ "Todo: " + task + "\n"
				+ "Location: " + location + "\n"
				+ "Minutes due: " + minutesDue.ToString("#.00");
	}
}

public class Schedule : MonoBehaviour {
	public MITClass taskOne;
	public MITClass taskTwo;
	public MITClass taskThree;
	TextMesh scheduleText;

	public TextMesh classText;

	// Use this for initialization
	void Start () {
		taskOne = new MITClass("Algorithms", "6.006", "Green Building", "Test", 25);
		taskTwo = new MITClass("Game Design", "6.073", "Stata", "Project 3", 30);
		taskThree = new MITClass("Math for Computer Scientist", "6.042", "26-100", "Number Theorey Pset", 55);

		scheduleText = this.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(taskOne.minutesDue);
		taskOne.runClock (Time.deltaTime);
		taskTwo.runClock (Time.deltaTime);
		taskThree.runClock (Time.deltaTime);
		scheduleText.text = "Schedule: \n" + taskOne.toString() + "\n" + 
			taskTwo.toString() + "\n" + taskThree.toString();
	}
}