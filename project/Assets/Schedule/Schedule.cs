using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MITClass 
{
	public string className;
	public string task;
	public int taskNumber;
	public float minutesWorkedOn;
	public float timeToComplete;
	public bool isComplete;
	public bool isDeadlinePast;
	public int dayDue;
	public int hourDue;
	public int minuteDue;
	public string dueDate;
	public int point;
	
	public MITClass(string _name, string _task, int _taskNumber, int _dayDue, int _hourDue)
	{
		className = _name;
		taskNumber = _taskNumber;
		task = _task;
		minutesWorkedOn = 0;
		isComplete = false;
		isDeadlinePast = false;
		if (task == "project") {
			timeToComplete = 10;
			point = 20;
		} else if (task == "pset") {
			timeToComplete = 5;	
			point = 10;
		} else{
			timeToComplete = 15;
			point = 30;
		}
		dayDue = _dayDue;
		hourDue = _hourDue;
		minuteDue = 0;
		dueDate = "\nDay: " + dayDue + " at " + hourDue + ":" + minuteDue;
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
		return className+" "+task+" "+taskNumber.ToString()+ "\n"
				+ "Completion: " + string.Format("{0:0.0%}",minutesWorkedOn/timeToComplete) + "\n"
				+ "Due: " + dueDate + "\n\n\n";
	}
}

public class Schedule : MonoBehaviour {
	public int numberOfTasks;
	public TextMesh scheduleText;
	public int currentDay;
	public int points;

	public TimeController t;
	public List<MITClass> taskList = new List<MITClass>();
	private string[] className = {"6.073","18.06","6.005","6.006"};
	private string[] task = {"project","test","pset"};
	private Dictionary<string, int> taskTrack = new Dictionary<string, int>();
	// Use this for initialization
	void Start () {
		for (int i=0; i<className.Length; i++) {
			for (int j=0;j<task.Length;j++){
				taskTrack.Add (className[i]+" "+task[j],1);
			}		
		}
		numberOfTasks = 3;
		scheduleText = this.GetComponent<TextMesh> ();
		currentDay = 1;
		points = 0;
		t = GameObject.Find ("Time").GetComponent<TimeController> ();
	}
	
	// Update is called once per frame
	void Update () {
		string taskString = "";
		if (t.day != currentDay) {
			populateTask(t.day+2);
			currentDay = t.day;
		}
		if (taskList.Count == 0) {
			populateTask(t.day+2);		
		}
		for (int i = 0; i < taskList.Count; i++)
		{   
			MITClass tempTask = taskList[i];
			checkDeadline(tempTask);
			if(tempTask.isDeadlinePast){
				PlayerPrefs.SetInt("Win/Lose", points);
				Application.LoadLevel("endScreen");
			}
			if (!tempTask.isComplete) {
				taskString += tempTask.toString();
			}else{
				points += tempTask.point;
				taskList.Remove(tempTask);
			}
		}
		scheduleText.text = "Points: "+points.ToString()+"\n\n" + taskString;
	}

	void populateTask(int number){
		int length = System.Math.Min (7, taskList.Count + number);
		int dayDue;
		int hourDue;
		for (int i=0; i<length; i++) {
			string cname = className[Random.Range(0,className.Length)];
			string tname = task[Random.Range(0,task.Length)];
			int taskNumber = taskTrack[cname+" "+tname];
			taskTrack[cname+" "+tname]++;
			if (tname=="project"){
				if(t.hours<20){
					dayDue = t.day;
					hourDue = t.hours+4;
				}else{
					dayDue = t.day+1;
					hourDue = 12;
				}
			}else if (tname =="pset"){
				if(t.hours<22){
					dayDue = t.day;
					hourDue = t.hours+3;
				}else{
					dayDue = t.day+1;
					hourDue = 9;
				}
			}else{
				if(t.hours<17){
					dayDue = t.day;
					hourDue = t.hours+5;
				}else{
					dayDue = t.day+1;
					hourDue = 14;
				}
			}
			taskList.Add (new MITClass(cname,tname,taskNumber,dayDue,hourDue));
		}
	}
	bool checkDeadline(MITClass c){
		int timeRemaining = (c.dayDue * 24 * 60 + c.hourDue * 60 + c.minuteDue) - 
			(t.day * 24 * 60 + t.hours * 60 + t.minutes);
		if (timeRemaining < 0) {
			c.isDeadlinePast = true;   
			return true;
		} else {
			return false;	
		}
	}
}
