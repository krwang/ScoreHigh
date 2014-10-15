﻿using UnityEngine;
using System.Collections;
using UnityEditor;

public class Dorm : MonoBehaviour {
	private Stats energy;
	private bool isInside = false;
	
	private Character player;
	public Texture bar_back;
	public Texture bar_over;
	public Texture bar_front;

	private AudioSource building_sound_source;
	private AudioClip door_sound;
	private AudioClip restore_sound;
	private Camera main_camera;

	// Use this for initialization
	void Start () {
		energy = (Stats) GameObject.Find ("Energy").GetComponent("Stats");
		player = (Character)GameObject.Find ("Character").GetComponent ("Character");
		bar_back  = AssetDatabase.LoadAssetAtPath ("Assets/Stats/bar_bg.png", typeof(Texture2D)) as Texture2D;
		bar_front = AssetDatabase.LoadAssetAtPath ("Assets/Stats/blue_bar.png", typeof(Texture2D)) as Texture2D;
		bar_over  = AssetDatabase.LoadAssetAtPath ("Assets/Stats/bar_over.png", typeof(Texture2D)) as Texture2D;

		building_sound_source = (AudioSource)gameObject.AddComponent ("AudioSource");
		building_sound_source.volume = 1;
		door_sound = (AudioClip)Resources.Load ("Door"); 
		restore_sound = (AudioClip)Resources.Load ("Restore");
		main_camera = GameObject.Find ("Main Camera").camera;
	}
	
	// Update is called once per frame
	void Update () {
		if (isInside) {
			energy.increment(0.001f);
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
		building_sound_source.clip = restore_sound;
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
		if (isInside) {
			player.renderer.enabled = false;
			player.move = false;
			GUI.Window (1111 ,new Rect (300, 250, 200, 140), diningWindow, "Energy");
		}
	}
	void diningWindow(int id){
		GUI.DrawTexture (new Rect (50, 40, 100, 20), bar_back);
		float length = energy.val;
		GUI.DrawTexture (new Rect (50, 40, length*100, 20), bar_front);
		GUI.DrawTexture (new Rect (50, 40, 100, 20), bar_over);
		string display = string.Format ("{0:0.0%}", length);
		GUI.TextField (new Rect (70, 60, 60, 20), display);
		if(GUI.Button(new Rect(70,80,60,20),"Leave")){
			isInside = false;
			player.move = true;
			player.renderer.transform.Translate(0,-1.3f,0);
			player.renderer.enabled = true;
			player.animator.SetBool ("idle", true);
			player.animator.SetInteger ("direction", 1);
		}
	}
}
