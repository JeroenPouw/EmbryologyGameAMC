// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class CubePuzzles : MonoBehaviour {
	
	GameObject pushbutton;
	GameObject puzzledoor;
	AudioClip dooropensound;
	AudioClip doorclosedsound; 
//	PlatformPuzzles puzzle;
//	puzzle = FindObjectOfType(typeof(PlatformPuzzles));
	void  Start (){
		pushbutton = GameObject.FindGameObjectWithTag("PushButton");
		puzzledoor = GameObject.FindGameObjectWithTag("PuzzleDoor"); 
	}
	
	void  OnTriggerStay ( Collider other  ){
		if(other.gameObject.tag == "PushCollider"){
			//puzzle.buttonAnimation = true;
			puzzledoor.active = false;
			//puzzle.playerExit = false;
			//puzzle.Update();
		}
	}
	
	void  OnTriggerEnter ( Collider other  ){
		if(other.gameObject.tag == "PushCollider"){
			GetComponent<AudioSource>().PlayOneShot(dooropensound);
		}
	}
	
	IEnumerator  OnTriggerExit ( Collider other  ){
		if(other.gameObject.tag == "PushCollider"){
			//puzzle.playerExit = true;
			yield return new WaitForSeconds(1);
			puzzledoor.active = true;
			GetComponent<AudioSource>().PlayOneShot(doorclosedsound);
			//puzzle.timer = 0;
			//puzzle.Update();
		}
	}
}