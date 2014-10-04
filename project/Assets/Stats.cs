using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
	public double Fatigue;
	public double Hunger;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Fatigue += 0.01;
	}

	void increment_fatigue(double value){
		Fatigue += value;
	}

	void increment_hunger(double value){
		Hunger += value;
	}


	double get_fatigue(){
		return Fatigue;
	}

	double get_hunger(){
		return Hunger;
	}
}
