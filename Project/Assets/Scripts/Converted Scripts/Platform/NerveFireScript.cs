// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class NerveFireScript : MonoBehaviour {
	
	HealthStatusBar playerHealth;
	//playerHealth = FindObjectOfType(typeof(HealthStatusBarScript));

	void Awake(){
		playerHealth = gameObject.GetComponent<HealthStatusBar>();
	}
	void  OnParticleCollision ( GameObject other  ){
		Debug.Log("raak");
		if(other.gameObject.tag == "Player"){
			Debug.Log("speler");
			playerHealth.reduceHealthElectro();
		}
	}
}