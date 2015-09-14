// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class TutorialScript : MonoBehaviour {
	
	bool  startInfo = false;
	
	bool  inInfoWall1 = false;
	bool  inInfoWall2 = false;
	bool  inInfoWall3 = false;
	bool  inInfoWall4 = false;
	bool  inInfoWall5 = false;
	bool  inInfoWall6 = false;
	bool  inInfoWall7 = false;
	bool  inInfoWall8 = false;
	bool  inInfoWall9 = false;
	
	GUISkin tutorialSkin;
	Vector2 TextSize = new Vector2(430, 250);
	
	GameObject InfoWall1; 
	GameObject InfoWall2;
	GameObject InfoWall3;
	GameObject InfoWall4;
	GameObject InfoWall5; 
	GameObject InfoWall6;
	GameObject InfoWall7;
	GameObject InfoWall8;
	GameObject InfoWall9;
	
	private float savedTimeScale;
	
	void  Start (){
		startInfo = true;
	}
	
	void  Update (){
		if(Input.GetKey(KeyCode.Return)&& inInfoWall1 == true){
			UnPauseGame();
			InfoWall1.SetActive(false);
			inInfoWall1 = false;
		}
		if(Input.GetKey(KeyCode.Return)&& inInfoWall2 == true){
			UnPauseGame();
			InfoWall2.SetActive(false);
			inInfoWall2 = false;
		}
		if(Input.GetKey(KeyCode.Return)&& inInfoWall3 == true){
			UnPauseGame();
			InfoWall3.SetActive(false);
			inInfoWall3 = false;
		}
		if(Input.GetKey(KeyCode.Return)&& inInfoWall4 == true){
			UnPauseGame();
			InfoWall4.SetActive(false);
			inInfoWall4 = false;
		}
		if(inInfoWall4 == true && Input.GetKeyDown(KeyCode.Tab)){
			inInfoWall4 = false;
			InfoWall4.SetActive(false);
		}
	}
	void  OnTriggerEnter ( Collider other  ){
		if(other.gameObject.name == "InfoWall"){
			startInfo = false;
		}
		
		if(other.gameObject.name == "InfoWall1"){
			inInfoWall1 = true;
			PauseGame();
		}
		
		if(other.gameObject.name == "InfoWall2"){
			inInfoWall2 = true;
			PauseGame();
		}
		
		if(other.gameObject.name == "InfoWall3"){
			inInfoWall3 = true;
			PauseGame();
		}
		
		if(other.gameObject.name == "InfoWall4"){
			inInfoWall4 = true;
		}
		if(other.gameObject.name == "InfoWall5"){
			inInfoWall5 = true;
		}
		if(other.gameObject.name == "InfoWall6"){
			inInfoWall6 = true;
		}
		if(other.gameObject.name == "InfoWall7"){
			inInfoWall7 = true;
		}
		if(other.gameObject.name == "InfoWall8"){
			inInfoWall8 = true;
		}
		if(other.gameObject.name == "InfoWall9"){
			inInfoWall9 = true;
		}
	}
	void  OnTriggerExit ( Collider other  ){
		if(other.gameObject.name == "InfoWall4"){
			inInfoWall4 = false;
			InfoWall4.SetActive(false);
		}
		if(other.gameObject.name == "InfoWall5"){
			inInfoWall5= false;
			InfoWall5.SetActive(false);
			InfoWall8.SetActive(false);
		}
		if(other.gameObject.name == "InfoWall6"){
			inInfoWall6 = false;
			InfoWall6.SetActive(false);
		}
		if(other.gameObject.name == "InfoWall7"){
			inInfoWall7 = false;
			InfoWall7.SetActive(false);
		}
		if(other.gameObject.name == "InfoWall8"){
			inInfoWall8 = false;
			InfoWall8.SetActive(false);
			InfoWall5.SetActive(false);
		}
		if(other.gameObject.name == "InfoWall9"){
			inInfoWall9 = false;
			InfoWall9.SetActive(false);
		}
	}
	
	void  OnGUI (){
		GUI.skin = tutorialSkin;
		if(startInfo == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string BlokInfo= "Use the arrow keys or the WASD keys to move the endoderm around.";
			GUILayout.Label(BlokInfo); 
			GUILayout.EndArea();
		}
		if(inInfoWall1 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string InfoWall1= "These are DNA repairs, if you collect them your shield bar will fill up. You can also shoot them, as long as your shield bar is not empty.\nPress SPACEBAR to shoot DNA repairs to destroy DNA helices from a distance.\n\nPress Enter to continue.";
			GUILayout.Label(InfoWall1); 
			GUILayout.EndArea();
		}
		if(inInfoWall2 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string InfoWall2= "These are DNA helices! They will damage you when you come in contact with them. Try to avoid them or shoot DNA repairs to destroy them.\n\nPress Enter to continue.";
			GUILayout.Label(InfoWall2); 
			GUILayout.EndArea();
		}
		if(inInfoWall3 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string InfoWall3= "You are about to enter a question room, you can gain a lot of points by answering the questions correctly. Each question room has 5 hallways representing an answer. Choose the correct hallway to find an item.\n\nPress Enter to continue.";
			GUILayout.Label(InfoWall3); 
			GUILayout.EndArea();
		}
		if(inInfoWall4 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string InfoWall4= "You have found the Ventral & Dorsal Pancreas, press the TAB key to open your inventory to read information about this item. Good luck finding the other parts.";
			GUILayout.Label(InfoWall4); 
			GUILayout.EndArea();
		}
		if(inInfoWall5 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string InfoWall5= "These are alcohol molecules, they won't hurt you but you have to time your movements to get pass them";
			GUILayout.Label(InfoWall5); 
			GUILayout.EndArea();
		}
		if(inInfoWall6 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string InfoWall6= "This is a stem cell, you can push it around. Maybe you can use it in your advantage.";
			GUILayout.Label(InfoWall6); 
			GUILayout.EndArea();
		}
		if(inInfoWall7 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string InfoWall7= "There is a strong current over here. You can find shelter behind the poles. Time your movements to get through the current";
			GUILayout.Label(InfoWall7); 
			GUILayout.EndArea();
		}
		if(inInfoWall8 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string InfoWall8= "These are alcohol molecules, they won't hurt you but you have to time your movements to get pass them";
			GUILayout.Label(InfoWall8); 
			GUILayout.EndArea();
		}
		if(inInfoWall9 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string InfoWall9= "Watch out! These scalpel blades do a lot of damage if they hit you. Be carefull and time your movements";
			GUILayout.Label(InfoWall9); 
			GUILayout.EndArea();
		}
	}
	
	void  PauseGame (){
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
	}
	
	void  UnPauseGame (){
		Time.timeScale = savedTimeScale;
	}
}