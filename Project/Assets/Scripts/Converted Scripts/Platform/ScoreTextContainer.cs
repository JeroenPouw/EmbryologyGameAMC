// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class ScoreTextContainer : MonoBehaviour {
	

	void  Update (){  
		transform.position = Camera.main.transform.position + new Vector3(0,0,0) + Camera.main.transform.forward * 1;
		transform.rotation = Camera.main.transform.rotation;
	}
}