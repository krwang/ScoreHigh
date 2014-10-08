using UnityEngine;
using System.Collections;

public class MITClass 
{
	public string className;
	public string courseNumber;
	public string task;
	public string location;
	public float minutesDue;
	public float minutesWorkedOn;
	public float timeToComplete;
	public bool taskComplete;

	public MITClass(string name, string number, string building, 
	                string assignment, float deadline, float workTime)
	{
		className = name;
		courseNumber = number;
		location = building;
		task = assignment;
		minutesDue = deadline;
		timeToComplete = workTime;
		taskComplete = false;
	}

	public void RunClock (float minutesPassed)
	{
		//I use the .1f multiplier to slow the time decay down
		if(minutesDue - minutesPassed * .1f < 0)
		{
			minutesDue = 0;
		}
		else{
			minutesDue -= minutesPassed * .1f;
		}
	}

	public void workOnTask(float timeWorked)
	{
		minutesWorkedOn += timeWorked;
		if (minutesWorkedOn > timeToComplete) {
			taskComplete = true;
		}
	}


	public string toString() {
		return className + " " + courseNumber + "\n"
				+ "Todo: " + task + "\n"
				+ "Location: " + location + "\n"
				+ "Completion: " + minutesWorkedOn/timeToComplete + "\n"
				+ "Minutes due: " + minutesDue.ToString("#.00") + "\n";
	}
}

public class Schedule : MonoBehaviour {
	public MITClass taskOne;
	public MITClass taskTwo;
	public MITClass taskThree;
	TextMesh scheduleText;
	public MITClass[] taskList = {
		new MITClass("Material Science", "3.091", "26-100", "Reaction Rates Quiz", 25, 10),
		new MITClass("Linear Algebra", "18.06", "34-201", "Eigen Vectors Recitation", 10, 10),
		new MITClass("Digital Humanities", "CMS.833", "Stata", "MFA Guest Speaker", 25, 10),
		new MITClass("Software", "6.005", "Stata", "Test", 15, 10),
		new MITClass("Dorm apple picking", "Simmons", "Dorm", "Get all the apples", 25, 10),
		new MITClass("Game Design", "6.073", "Stata", "Post Mortem", 45, 10),
		new MITClass("Algorithms", "6.006", "Green Building", "Numerics Pset", 105, 10)
	};
	public TextMesh classText;

	// Use this for initialization
	void Start () {
		taskOne = new MITClass("Algorithms", "6.006", "Walker", "Test", 25, 10);
		taskTwo = new MITClass("Game Design", "6.073", "Blue Building", "Project 3", 30, 12);
		taskThree = new MITClass("Math for Computer Scientist", "6.042", "Black Building", "Number Theorey Pset", 55, 20);

		scheduleText = this.GetComponent<TextMesh> ();
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log(taskOne.minutesDue);
		taskOne.RunClock (Time.deltaTime);
		taskTwo.RunClock (Time.deltaTime);
		taskThree.RunClock (Time.deltaTime);
		scheduleText.text = "Schedule: \n\n" + 
			taskTwo.toString() + "\n\n" + taskThree.toString();
	}
}
