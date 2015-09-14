// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Checkpoints : MonoBehaviour {
	
	public Transform SpawnPoint;
	
	void  OnTriggerEnter ( Collider col  ){
		if(col.tag =="Player")
		{
			SpawnPoint.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);	
		}
		
	}
}