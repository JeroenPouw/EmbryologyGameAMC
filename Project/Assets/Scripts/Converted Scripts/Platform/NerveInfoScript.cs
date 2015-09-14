// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class NerveInfo : MonoBehaviour {
	
	bool  inNerveWall = false;
	GameObject InfoWallNerve; 
	GameObject InfoWallNerve2; 
	GUISkin tutorialSkin;
	Vector2 TextSize = new Vector2(430, 250);
	
	void  OnTriggerEnter ( Collider other  ){
		if(other.gameObject.name == "InfoWallNerve"){
			inNerveWall = true;
		}
		if(other.gameObject.name == "InfoWallNerve2"){
			inNerveWall = true;
		}
	}
	
	void  OnTriggerExit ( Collider other  ){
		if(other.gameObject.name == "InfoWallNerve"){
			inNerveWall = false;
			InfoWallNerve.SetActive(false);
			InfoWallNerve2.SetActive(false);
		}
		if(other.gameObject.name == "InfoWallNerve2"){
			inNerveWall = false;
			InfoWallNerve.SetActive(false);
			InfoWallNerve2.SetActive(false);
		}
	}
	void  OnGUI (){
		GUI.skin = tutorialSkin;
		if(inNerveWall == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string InfoWall9 = "Watch out for the electrical pulse of this nerve cell";
			GUILayout.Label(InfoWall9); 
			GUILayout.EndArea();
		}
		
	}
}