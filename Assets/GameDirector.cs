﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {

	GameObject timerText;
	GameObject pointText;
	float time = 30.0f;
	int point = 0;
	GameObject generator;

	public void GetApple(){
		point += 100;
	}

	public void GetBomb(){
		point /= 2;
	}



	// Use this for initialization
	void Start () {
		this.timerText = GameObject.Find ("Time");
		this.pointText = GameObject.Find ("Point");
		this.generator = GameObject.Find ("ItemGenerator");
	}
	
	// Update is called once per frame
	void Update () {
		this.time -= Time.deltaTime;

		if (this.time < 0) {
			this.generator.GetComponent<ItemGenerator> ().SetParameter (10000.0f, 0, 0);
		}else if (0 <= this.time && this.time < 5) {
			this.generator.GetComponent<ItemGenerator> ().SetParameter (0.7f, -0.04f, 3);
		}else if (5 <= this.time && this.time < 12) {
			this.generator.GetComponent<ItemGenerator> ().SetParameter (0.8f, -0.05f, 6);
		}else if (12 <= this.time && this.time < 23) {
			this.generator.GetComponent<ItemGenerator> ().SetParameter (0.8f, -0.04f, 4);
		}else if (23 <= this.time && this.time < 30) {
			this.generator.GetComponent<ItemGenerator> ().SetParameter (1.0f, -0.03f, 2);
		}





		this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
		this.pointText.GetComponent<Text> ().text = this.point.ToString () + " point";
	}
}