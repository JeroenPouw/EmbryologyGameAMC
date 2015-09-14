// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Blokkade : MonoBehaviour {
	
	bool  inBlokInfo = false;
	GUISkin questionSkin;
	Vector2 TextSize = new Vector2(430, 250);
	GameObject blokkade;
	GameObject blokkade1;
	GameObject blokkade2;
	void  Start (){
		blokkade = GameObject.FindGameObjectWithTag("Blokkade");
		blokkade1 = GameObject.FindGameObjectWithTag("Blokkade1");
		blokkade2 = GameObject.FindGameObjectWithTag("Blokkade2");
	}
	
	void  OnTriggerEnter ( Collider other  ){
		if(other.gameObject.tag == "BlokInfo"){
			inBlokInfo = true;
		}
		if(other.gameObject.tag == "RemoveBlok"){
			blokkade.SetActive(false);
		}
		if(other.gameObject.tag == "RemoveBlok1"){
			blokkade1.SetActive(false);
		}
		if(other.gameObject.tag == "RemoveBlok2"){
			blokkade2.SetActive(false);
		}
	}
	
	void  OnTriggerExit ( Collider other  ){
		if(other.gameObject.tag == "BlokInfo"){
			inBlokInfo = false;
		}
	}
	
	void  OnGUI (){
		GUI.skin = questionSkin;
		if(inBlokInfo == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string BlokInfo= "You cannot enter this hallway from this side, find another way.";
			GUILayout.Label(BlokInfo); 
			GUILayout.EndArea();
			
		}
	}
}