// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour {
	public float gravity = 100; // gravity acceleration

	void  Start (){
	}
	
	void  FixedUpdate (){
		float distForward = Mathf.Infinity;
		RaycastHit hitForward = new RaycastHit();
		if (Physics.SphereCast(transform.position, 0.50f, -transform.up + transform.forward, out hitForward, 5))
		{
			distForward = hitForward.distance;
		}
		float distDown = Mathf.Infinity;
		RaycastHit hitDown;
		if (Physics.SphereCast(transform.position, 0.50f, -transform.up, out hitDown, 5))
		{
			distDown = hitDown.distance;
		}
		float distBack = Mathf.Infinity;
		RaycastHit hitBack;
		if (Physics.SphereCast(transform.position, 0.50f, -transform.up + -transform.forward, out hitBack, 5))
		{
			distBack = hitBack.distance;
		}
		
		if (distForward < distDown && distForward < distBack)
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.Cross(transform.right, hitForward.normal), hitForward.normal), Time.deltaTime * 5.0f);
		}
		else if (distDown < distForward && distDown < distBack)
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.Cross(transform.right, hitDown.normal), hitDown.normal), Time.deltaTime * 5.0f);
		}
		else if (distBack < distForward && distBack < distDown)
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.Cross(transform.right, hitBack.normal), hitBack.normal), Time.deltaTime * 5.0f);
		}
		
		GetComponent<Rigidbody>().AddForce(-transform.up * gravity);
		

	}
	

}