using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MITClass 
{
	public string className;
	public string task;
	public string display;
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
		display = className + " " + task + " " + taskNumber.ToString ();
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
	public Dictionary<int,MITClass> taskList = new Dictionary<int, MITClass>();
	public HashSet<string> taskSet = new HashSet<string>();
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
		for (int i =0; i<7; i++) {
			taskList.Add(i,null);		
		}
		scheduleText = this.GetComponent<TextMesh> ();
		currentDay = 0;
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
			if (tempTask != null){
				checkDeadline(tempTask);
				if(tempTask.isDeadlinePast){
					PlayerPrefs.SetInt("Win/Lose", points);
					Application.LoadLevel("endScreen");
				}
				if (!tempTask.isComplete) {

					taskString += tempTask.toString();
				}else{
					points += tempTask.point;
					taskList[i]=null;
					taskSet.Remove(tempTask.display);
				}
			}
		}
		scheduleText.text = "Points: "+points.ToString()+"\n\n" + taskString;
	}

	void populateTask(int number){
		int length = System.Math.Min (7, taskSet.Count + number);
		int dayDue;
		int hourDue;
		for (int i=0; i<length; i++) {
			string cname = className[Random.Range(0,className.Length)];
			string tname = task[Random.Range(0,task.Length)];
			int taskNumber = taskTrack[cname+" "+tname];
			int index = 6;
			taskTrack[cname+" "+tname]++;
			if (tname=="project"){
				if(t.hours<16){
					dayDue = t.day;
					hourDue = t.hours+Random.Range(4,8);
				}else{
					dayDue = t.day+1;
					hourDue = Random.Range(14,19);
				}
			}else if (tname =="pset"){
				if(t.hours<18){
					dayDue = t.day;
					hourDue = t.hours+Random.Range(4,6);
				}else{
					dayDue = t.day+1;
					hourDue = Random.Range (9,14);
				}
			}else{
				if(t.hours<16){
					dayDue = t.day;
					hourDue = t.hours+Random.Range(5,8);
				}else{
					dayDue = t.day+1;
					hourDue = Random.Range(16,24);
				}
			}
			for(int j=0;j<7;j++){
				if(taskList[j]==null){
					index = j;
					break;
				}
			}
			taskList[index] = new MITClass(cname,tname,taskNumber,dayDue,hourDue);
			taskSet.Add(cname+" "+tname+" "+taskNumber.ToString());
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
