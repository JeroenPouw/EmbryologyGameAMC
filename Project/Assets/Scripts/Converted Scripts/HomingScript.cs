// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class HomingScript : MonoBehaviour {

	float _velocity = 10;
	float _torque = 5;
	Transform _target;
	public Rigidbody _rigidbody;
	
	
	
	void  Start (){
		
		//_rigidbody = transform.rigidbody;

		
	}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Enemy") {
			Fire ();
				}
	}
	
	void  Fire (){
		
		float distance= Mathf.Infinity;
		
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
		{ 
			
			float diff= (go.transform.position - transform.position).sqrMagnitude;   
			if(diff < distance)
			{
				
				distance = diff;
				
				_target =  go.transform;
				
			}
			
		}
		
	}
	
	
	
	void  FixedUpdate (){
		
		if(_target == null || _rigidbody == null)
			
			return;
		
		_rigidbody.velocity = transform.forward * _velocity;
		
		
		
		Quaternion targetRotation= Quaternion.LookRotation(_target.position - transform.position);
		
		_rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, _torque));
		
	}
}