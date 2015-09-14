// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour {
	
	public static int Score;
	public GUIStyle myStyle;
	
	void  OnGUI (){
		GUI.Label( new Rect(Screen.width - 110, Screen.height - Screen.height + 250, 50, 25), "Score: " + Score, myStyle);
	} 
}