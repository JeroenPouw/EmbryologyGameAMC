// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class MovingPlatformScript : MonoBehaviour {
	public float amplitude = 5; // platform excursion (+/- 5 units, in this case)
	public float speed = 0.2f; // movements per second
	public Vector3 direction = Vector3.forward; // direction relative to the platform
	private Vector3 p0;
	public GameObject waterLeftParticle;
	private Vector3 currentPos;
	
	IEnumerator  Start (){
		currentPos = transform.position;
		p0 = transform.position;
		GameObject waterLeftPar = Instantiate(waterLeftParticle, this.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject; 
		while (true){
			// convert direction to local space
			Vector3 dir = transform.TransformDirection(direction);
			// set platform position:
			transform.position = p0+amplitude*dir*Mathf.Sin(6.28f*speed*Time.time);
			waterLeftPar.gameObject.transform.LookAt(transform.position);
			yield return 0; // let Unity free till the next frame
		}
	}
	
}