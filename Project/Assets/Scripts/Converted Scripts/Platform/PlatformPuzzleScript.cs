// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class PlatformPuzzleScript : MonoBehaviour {
	
	GameObject pushbutton;
	GUISkin puzzleSkin;
	bool  puzzleblockinfo = false;
	Vector2 TextSize = new Vector2(430, 250);
	GameObject puzzledoor;
	AudioClip dooropensound;
	AudioClip doorclosedsound; 
	float speed = 0.1f;
	
	bool  buttonAnimation = false;
	bool  playerExit = false;
	float timer = 0;
	float timerback = 0;
	bool  pushColliderInfo = false;
	
	void  Start (){
		pushbutton = GameObject.FindGameObjectWithTag("PushButton");
		puzzledoor = GameObject.FindGameObjectWithTag("PuzzleDoor");  
	}

	void  Update (){
		if(buttonAnimation == true && timer < 1){
			timer += Time.deltaTime;
			Vector3 move = new Vector3(1, 0, 0);
			pushbutton.transform.Translate(move * speed * Time.deltaTime);
		}
		if(timer >= 1){
			Vector3 move = new Vector3(0,0,0);
			pushbutton.transform.Translate(0,0,0);
			buttonAnimation = false;
		}
		if(playerExit == true && buttonAnimation == false){
			timerback += Time.deltaTime;
			Vector3 moveback = new Vector3(-1, 0, 0);
			pushbutton.transform.Translate(moveback * speed * Time.deltaTime);
		}
		if(timerback >= 1){
			Vector3 moveback = new Vector3(0,0,0);
			pushbutton.transform.Translate(0,0,0);
			playerExit = false;
			timerback = 0;
		}
	}
	
	void  OnTriggerEnter ( Collider other  ){
		if(other.gameObject.tag == "PushCollider"){
			buttonAnimation = true;
			puzzledoor.active = false;
			GetComponent<AudioSource>().PlayOneShot(dooropensound);
			playerExit = false;
		}
		if(other.gameObject.name == "PuzzleBlockInfo"){
			puzzleblockinfo = true;
		}
		if(other.gameObject.name == "PushCollider"){
			pushColliderInfo = true;
		}
	}
	
	IEnumerator  OnTriggerExit ( Collider other  ){
		if(other.gameObject.tag == "PushCollider"){
			playerExit = true;
			yield return new WaitForSeconds(1);
			puzzledoor.active = true;
			GetComponent<AudioSource>().PlayOneShot(doorclosedsound);
			timer = 0;
		}
		if(other.gameObject.name == "PuzzleBlockInfo"){
			puzzleblockinfo = false;
		}
		if(other.gameObject.name == "PushCollider"){
			pushColliderInfo = false;
		}
	}
	
	void  OnGUI (){
		GUI.skin = puzzleSkin;
		if(puzzleblockinfo == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string PuzzleInfo= "This door seems closed, maybe you can find a switch to open it";
			GUILayout.Label(PuzzleInfo);
			GUILayout.EndArea();
		}
		if(pushColliderInfo == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string pushColliderText= "There is a switch over here! Maybe you can find something to push against the switch.";
			GUILayout.Label(pushColliderText);
			GUILayout.EndArea();
		}
	}
	
}