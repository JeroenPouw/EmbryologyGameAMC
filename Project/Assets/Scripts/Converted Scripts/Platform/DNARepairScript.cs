// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class DNARepairScript : MonoBehaviour {
	
	void  Update (){
		transform.Rotate(0, Time.deltaTime *100, 0);
	}
	
	void  OnCollisionEnter ( Collision hit  ){	
		if(hit.gameObject.tag == "Wall"){
			Destroy(this.gameObject);	
		}	
	}	
}