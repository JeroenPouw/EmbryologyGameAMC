// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class MenuText : MonoBehaviour {
	bool isBackButton= false;
	bool isPlayButton= false;
	bool isCreditsButton= false;
	Camera Camera1;
	Camera Camera2;
	bool infoClicked= false;
	Scores score;

//	Loading_Screen loadingScript; //problemo
//	loadingScript = FindObjectOfType(typeof(Loading_Screen));
	
	void  Start (){
		score = gameObject.GetComponent<Scores> ();
		Camera1.enabled = true;
		Camera2.enabled = false;
	}
	void  OnMouseEnter (){
		// change the color of the text
		GetComponent<Renderer>().material.color = Color.black;
	}
	void  OnMouseExit (){
		GetComponent<Renderer>().material.color = Color.white;
	}
	
	void  OnMouseUp (){
		// are we dealing with a Quit button?
//		if(isQuitButton){
//			// quit the game
//			Application.Quit();
//		}
		if(isCreditsButton){
			Application.LoadLevel(6);
		}
//		if(isInfoButton){
//			infoClicked = true;
//			backClicked = false; //bool location unknown
//			Camera1.enabled = false;
//			Camera2.enabled = true;
//		}
//		if(isBackButton){
//			infoClicked = false;
//			backClicked = true;
//			Camera1.enabled = true;
//			Camera2.enabled = false;
//		}
//		else if(isPlayButton){
//			// load level
//			Loading_Screen.LoadingScreenOn = true;
//			loadingScript.ChooseImg();
//			yield return new WaitForSeconds(3);
//			Application.LoadLevel(1);
//			score.Score = 0;
//		}	
	}
}