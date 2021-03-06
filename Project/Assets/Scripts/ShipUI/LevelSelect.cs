﻿using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {
	public int highlightedlevel = -1;
	public void LevelHighlight(int selectedLevel){
			highlightedlevel = selectedLevel;
	}

	public void Levelconfirm(){
		if (highlightedlevel == -1) {
			Debug.Log("You have no level selected for loading!");
		}
		else if(Application.loadedLevel == highlightedlevel) {
			Debug.Log ("The level you try to load is already loaded!");
		} 
		else {
			Application.LoadLevel (highlightedlevel);
			highlightedlevel = -1;
			if (Time.timeScale != 1) {
				Time.timeScale = 1;
			}
		}
	}
}
