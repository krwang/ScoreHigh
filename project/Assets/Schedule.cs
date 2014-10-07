using UnityEngine;
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

	public void Update ()
	{
		minutesDue -= Time.deltaTime;
		if(minutesDue < 0)
		{
			// Failed a task
		}
	}

	public void TaskExtension(float timeExtended)
	{
		minutesDue += timeExtended;
	}
}

public class Schedule : MonoBehaviour {
	public MITClass taskOne;
	public MITClass taskTwo;
	public MITClass taskThree;
	public float speed;
	
	// Use this for initialization
	void Start () {
		taskOne = new MITClass("Algorithms", "6.006", "Green Building", "Test", 25);
		taskTwo = new MITClass("Game Design", "6.073", "Stata", "Project 3", 25);
		taskThree = new MITClass("Math for Computer Scientist", "6.042", "26-100", "Number Theorey Pset", 25);
	}
	
	// Update is called once per frame
	void Update () {
		taskOne.Update ();
		taskTwo.Update ();
		taskThree.Update ();
		
		
	}
}
