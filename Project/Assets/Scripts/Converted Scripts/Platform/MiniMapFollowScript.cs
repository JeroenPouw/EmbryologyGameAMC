// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class MiniMapFollowScript : MonoBehaviour {
	
	Movement playerMovement; 
	//playerMovement = FindObjectOfType(typeof(Movement));
	void Awake(){
		playerMovement = gameObject.GetComponent<Movement>();
	}
	void  Update (){
		transform.rotation = Quaternion.Euler(90,90,0);
		if(playerMovement.inCameraZone == true){
			GetComponent<Camera>().cullingMask = 1 | 1 << 9 | 1 << 8 | 1 << 7 | 1 << 6 | 1 << 5 | 1 << 4 | 1 << 3 | 1 << 2 | 1 << 10 | 1 << 11 | 1 << 12 | 1 << 15;
		}
		else if(playerMovement.inCameraZone == false){
			GetComponent<Camera>().cullingMask =  2 | 1 << 9 | 1 << 8 | 1 << 7 | 1 << 6 | 1 << 5 | 1 << 4 | 1 << 3 | 1 << 2 | 1 << 10 | 1 << 11 | 1 << 12 | 1 << 15 | 1 << 14 | 1 << 13;
		}
	}
}