﻿using UnityEngine;
using System.Collections;
using UnityEditor;

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

	public Rect? popWindow;
	private Texture2D bar_back;
	public Texture2D bar_front;
	public Texture2D bar_over;

	private AudioSource building_sound_source;
	private AudioClip door_sound;
	private AudioClip work_sound;
	private Camera main_camera;

	// Use this for initialization
	void Start () {
		coll = GetComponent<BoxCollider2D> ();
		isInside = false;
		energy = (Stats) GameObject.Find ("Energy").GetComponent("Stats");
		food = (Stats) GameObject.Find ("Food").GetComponent("Stats");
		timeColl = (TimeController)GameObject.Find ("Time").GetComponent ("TimeController");
		player = (Character)GameObject.Find ("Character").GetComponent ("Character");

		bar_back  = AssetDatabase.LoadAssetAtPath ("Assets/Stats/bar_bg.png", typeof(Texture2D)) as Texture2D;
		bar_front = AssetDatabase.LoadAssetAtPath ("Assets/Stats/blue_bar.png", typeof(Texture2D)) as Texture2D;
		bar_over  = AssetDatabase.LoadAssetAtPath ("Assets/Stats/bar_over.png", typeof(Texture2D)) as Texture2D;

		building_sound_source = (AudioSource)gameObject.AddComponent ("AudioSource");
		building_sound_source.volume = 1;
		door_sound = (AudioClip)Resources.Load ("Door"); 
		work_sound = (AudioClip)Resources.Load ("Work");
		main_camera = GameObject.Find ("Main Camera").camera;
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

	IEnumerator OnTriggerEnter2D(Collider2D other) {
		isInside = true;
		// make player invisible
		player.renderer.enabled = false;
		// prepare character to look like leaving building
		player.idle = true;
		player.direction = 2;

		main_camera.audio.Pause ();
		building_sound_source.volume = 1f;
		building_sound_source.clip = door_sound;
		building_sound_source.Play ();

		yield return new WaitForSeconds (building_sound_source.clip.length);
		building_sound_source.volume = 0.5f;
		building_sound_source.clip = work_sound;
		building_sound_source.Play ();
	}

	void OnTriggerExit2D(Collider2D other) {
		player.idle = true;
		player.direction = 2;

		building_sound_source.volume = 1f;
		building_sound_source.clip = door_sound;
		building_sound_source.Play ();
		main_camera.audio.Play ();
	}

	void OnGUI(){
		if (isInside && schedule != null) {
			MITClass mitclass = schedule.taskList [taskIdx];
			popWindow = GUI.Window (taskIdx, new Rect (300, 250, 200, 140), classWindow, mitclass.task);
			player.move = false;
		} else if (isInside) {
			popWindow = GUI.Window (taskIdx, new Rect (300, 250, 200, 140), noClassWindow, "No task in this Building");
			player.move = false;
		}
	}
	

	void classWindow(int id){
		GUI.DrawTexture (new Rect (50, 40, 100, 20), bar_back);
		MITClass mitclass = schedule.taskList[taskIdx];
		float length = System.Math.Min(1,mitclass.minutesWorkedOn / mitclass.timeToComplete);
		GUI.DrawTexture (new Rect (50, 40, length*100, 20), bar_front);
		GUI.DrawTexture (new Rect (50, 40, 100, 20), bar_over);
		string display = string.Format ("{0:0.0%}", length);
		GUI.TextField (new Rect (70, 60, 60, 20), display);


		if(GUI.Button(new Rect(70,80,60,20),"Leave")){
			isInside = false;
			player.move = true;
			player.renderer.transform.Translate(0,-0.5f,0);
			player.renderer.enabled = true;
			player.animator.SetBool ("idle", true);
			player.animator.SetInteger ("direction", 1);
		}
	}

	void noClassWindow(int id){
		if(GUI.Button(new Rect(70,80,60,20),"Leave")){
			isInside = false;
			player.move = true;
			player.renderer.transform.Translate(0,-1.3f,0);
			player.renderer.transform.Translate(0,-0.5f,0);
			player.renderer.enabled = true;
			player.animator.SetBool ("idle", true);
			player.animator.SetInteger ("direction", 1);
		}
	}
}
