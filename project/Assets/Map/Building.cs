using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	public BoxCollider2D coll;
	public string location;
	public Character player;
	public bool isInside; 

	public Schedule schedule;
	public int taskIdx;

	private Stats energy;
	private Stats food;
	private TimeController timeColl;

	public Rect popWindow;
	public Texture bar_back;
	public Texture bar_front;
	// Use this for initialization
	void Start () {
		coll = GetComponent<BoxCollider2D> ();
		isInside = false;
		energy = (Stats) GameObject.Find ("Energy").GetComponent("Stats");
		food = (Stats) GameObject.Find ("Food").GetComponent("Stats");
		timeColl = (TimeController)GameObject.Find ("Time").GetComponent ("TimeController");
	}
	
	// Update is called once per frame
	void Update () {
		if (isInside && schedule != null) {
			schedule.taskList [taskIdx].workOnTask (0.01f);
			timeColl.inBuilding = true;
			timeColl.increaseTime (7);
			energy.increment (-0.0005f);
			food.increment (-0.0005f);
		} else {
			timeColl.inBuilding = false;	
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		isInside = true;
		// make player invisible
		//player.renderer.enabled = false;
	}

	void OnTriggerExit2D(Collider2D other) {
		isInside = false;
	}

	void OnGUI(){
		if (isInside && schedule != null) {
			MITClass mitclass = schedule.taskList[taskIdx];
			popWindow = GUI.Window(taskIdx,new Rect(250,400,200,100),DoMyWindow,mitclass.task);
		}
	}
	void DoMyWindow(int id){
		GUI.DrawTexture (new Rect (50, 40, 100, 20), bar_back);
		MITClass mitclass = schedule.taskList[taskIdx];
		float length = System.Math.Min(1,mitclass.minutesWorkedOn / mitclass.timeToComplete);
		GUI.DrawTexture (new Rect (50, 40, length*100, 20), bar_front);
		string display = string.Format ("{0:0.0%}", length);
		GUI.TextField (new Rect (70, 60, 60, 20), display);
	}
}
