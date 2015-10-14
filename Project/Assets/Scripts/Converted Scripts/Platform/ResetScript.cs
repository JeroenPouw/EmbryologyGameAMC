// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class ResetScript : MonoBehaviour {
	void  OnGUI (){
		if (GUI.Button ( new Rect(190,10,100,30), "RESET")) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}