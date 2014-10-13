﻿using UnityEngine;
using System.Collections;

public class MITClass 
{
	public string className;
	public string courseNumber;
	public string task;
	public string location;
	public float minutesWorkedOn;
	public float timeToComplete;
	public bool isComplete;
	public bool isDeadlinePast;
	public int dayDue;
	public int hourDue;
	public int minuteDue;
	public string dueDate;
	
	public MITClass(string name, string number, string building, 
	                string assignment, float workTime, int dayDue, 
	                int hourDue, int minuteDue)
	{
		className = name;
		courseNumber = number;
		location = building;
		task = assignment;
		timeToComplete = workTime;
		isComplete = false;
		isDeadlinePast = false;
		dayDue = dayDue;
		hourDue = hourDue;
		minuteDue = minuteDue;
		dueDate = "\nDay: " + dayDue + " at " + hourDue + ":" + minuteDue;
	}
	
	public void checkDeadline(){
		GameObject timer = GameObject.Find ("Clock");
		TimeController t = timer.GetComponent<TimeController>();
		int timeRemaining = dayDue - t.day + hourDue - t.hours + minuteDue - t.minutes;
		if (timeRemaining < 0) {
			isDeadlinePast = true;         
		}
	}
	
	public void workOnTask(float timeWorked)
	{
		if (!isDeadlinePast) {
			minutesWorkedOn += timeWorked;
			if (minutesWorkedOn > timeToComplete) {
				isComplete = true;
			}
		}
	}
	
	public string toString() {
		//        className + " " + courseNumber + "\n"
		
		return task + "\n"
			+ "Location: " + location + "\n"
				+ "Completion: " + (minutesWorkedOn/timeToComplete).ToString("#.00") + "\n"
				+ "Due: " + dueDate + "\n\n\n";
	}
}

public class Schedule : MonoBehaviour {
	public int numberOfTasks;
	public TextMesh scheduleText;
	public int currentDay;
	public MITClass[] taskList = {
		new MITClass("Algorithms", "6.006", "Walker", "Test", 15, 1, 11, 45),
		new MITClass("Game Design", "6.073", "Blue Building", "Project 3", 6, 1, 9, 11),
		new MITClass("Math for Computer Scientist", "6.042", "Black Building", "Number Theorey Pset", 200, 1, 23, 55),
		new MITClass("Material Science", "3.091", "26-100", "Reaction Rates Quiz", 110, 1, 22, 5),
		new MITClass("Linear Algebra", "18.06", "34-201", "Eigen Vectors Recitation", 20, 2, 2, 22),
		new MITClass("Digital Humanities", "CMS.833", "Stata", "MFA Guest Speaker", 30, 2, 2, 10),
		new MITClass("Software", "6.005", "Stata", "Test", 60, 2, 12, 5),
		new MITClass("Dorm apple picking", "Simmons", "Dorm", "Get all the apples", 120, 3, 8, 12),
		new MITClass("Game Design", "6.073", "Stata", "Post Mortem", 10, 2, 20, 11),
		new MITClass("Algorithms", "6.006", "Green Building", "Numerics Pset", 100, 3, 12, 44)
	};
	
	// Use this for initialization
	void Start () {
		numberOfTasks = 3;
		scheduleText = this.GetComponent<TextMesh> ();
		currentDay = 1; 
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(taskOne.minutesDue);
		string taskString = "";
		//Update the current day based on time controller class.
		numberOfTasks = currentDay * numberOfTasks;
		for (int i = 0; i < numberOfTasks; i++)
		{    
			MITClass tempTask = taskList[i];
			if (!tempTask.isComplete) {
				taskString += tempTask.toString();
			}
		}
		scheduleText.text = "Schedule: \n\n" + taskString;
	}
}
