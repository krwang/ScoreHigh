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

	public void runClock (float minutesPassed)
	{
		Debug.Log("Counting down"); 
		minutesDue -= minutesPassed;
		if(minutesDue < 0)
		{
			// Failed a task
		}
	}

	public float getTimeDue(){
		return minutesDue;
	}

	public void TaskExtension(float timeExtended)
	{
		minutesDue += timeExtended;
	}

	public string toString() {
		return className + " " + courseNumber + "\n"
				+ "todo: " + task + "\n"
				+ "location: " + location + "\n"
				+ "minutes due: " + minutesDue.ToString("F2");
	}
}

public class Schedule : MonoBehaviour {
	public MITClass taskOne;
	public MITClass taskTwo;
	public MITClass taskThree;
	public TextMesh classText;

	// Use this for initialization
	void Start () {
		taskOne = new MITClass("Algorithms", "6.006", "Green Building", "Test", 25);
		taskTwo = new MITClass("Game Design", "6.073", "Stata", "Project 3", 30);
		taskThree = new MITClass("Math for Computer Scientist", "6.042", "26-100", "Number Theorey Pset", 55);


		classText = this.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(taskOne.getTimeDue());
		taskOne.runClock (Time.deltaTime);
		taskTwo.runClock (Time.deltaTime);
		taskThree.runClock (Time.deltaTime);


		classText.text = taskOne.toString () + "\n\n"
						+ taskTwo.toString () + "\n\n"
						+ taskThree.toString ();
	}

	private bool guiIsOn = true;
	
//	void OnGUI()
//	{
//		if(guiIsOn)
//		{
//			Debug.Log("In gui");
//			GUI.Label(new Rect(5,5,5,5), "HELPP");
//		}
//	}
}
