using UnityEngine;
using System.Collections;
using UnityEditor;

public class DiningHall : MonoBehaviour {
	//public BoxCollider2D coll;
	private Stats food;
	private Character player;
	public Texture bar_back;
	public Texture bar_over;
	public Texture bar_front;
	private bool isInside = false;

	// Use this for initialization
	void Start () {
		//coll = GetComponent<BoxCollider2D> ();
		food = (Stats) GameObject.Find ("Food").GetComponent("Stats");
		player = (Character)GameObject.Find ("Character").GetComponent ("Character");
		bar_back  = AssetDatabase.LoadAssetAtPath ("Assets/Stats/bar_bg.png", typeof(Texture2D)) as Texture2D;
		bar_front = AssetDatabase.LoadAssetAtPath ("Assets/Stats/blue_bar.png", typeof(Texture2D)) as Texture2D;
		bar_over  = AssetDatabase.LoadAssetAtPath ("Assets/Stats/bar_over.png", typeof(Texture2D)) as Texture2D;

	}
	
	// Update is called once per frame
	void Update () {
		if (isInside) {
			food.increment(0.001f);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		isInside = true;
	}

	void OnGUI(){
		if (isInside) {
			player.move = false;
			player.renderer.enabled = false;
			GUI.Window (1111 ,new Rect (300, 250, 200, 140), diningWindow, "Food");
		}
	}
	void diningWindow(int id){
		GUI.DrawTexture (new Rect (50, 40, 100, 20), bar_back);
		float length = food.val;
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
