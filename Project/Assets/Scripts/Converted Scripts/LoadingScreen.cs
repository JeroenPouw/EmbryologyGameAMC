// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour {
	

	static bool inputTextActive= false;
	int TimerMax = 300;
	int Timer;
	
	public static bool LoadingScreenOn= true;
	bool  showLoad = false;
	bool  loadScreenEnabled = false;
	bool  WaitTimeRunning = false;
	//Texture
	Texture2D Loading_Screen1;
	Texture2D Loading_Screen2;
	Texture2D Loading_Screen3;
	Texture2D Loading_Screen4;
	Texture2D Loading_Screen5;
	Texture2D Loading_Screen6;
	int showCount;
	
	static int count = 0;
	
	void  Start (){	
		if(LoadingScreen.LoadingScreenOn == true)
		{	
			LoadingScreen.LoadingScreenOn = false;
			showLoad = false;
		}
		Timer = TimerMax;
	}
	
	void  Update (){
		if (LoadingScreen.LoadingScreenOn == true)
		{
			showLoad = true;
		}
	}
	
	void  OnGUI (){
		GUI.depth = 0;
		if(showCount == 0 && showLoad == true){
			GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), Loading_Screen1);
		}
		if(showCount == 1 && showLoad == true){
			GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), Loading_Screen2);
		}
		if(showCount == 2 && showLoad == true){
			GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), Loading_Screen3);
		}
		if(showCount == 3 && showLoad == true){
			GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), Loading_Screen4);
		}
		if(showCount == 4 && showLoad == true){
			GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), Loading_Screen5);
		}
		if(showCount == 5 && showLoad == true){
			GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), Loading_Screen6);
		}
	}
	public void  ChooseImg (){
		int randPic= Random.Range(0, 6);
		int chosenPicture = randPic;
		switch (chosenPicture)
		{
		case 0:
			showCount = 0;
			break;
		case 1:
			showCount = 1;
			break;
		case 2:
			showCount = 2;
			break;
		case 3:
			showCount = 3;
			break;
		case 4:
			showCount = 4;
			break;
		case 5:
			showCount = 5;
			break;
		}
	}
}