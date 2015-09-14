// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Winds : MonoBehaviour {
	ParticleSystem wind;
	ParticleSystem windSecond;
	float timer = 0;
	float timerWindStart = 3;
	float timerReset = 8;
	float forcePower = 10;
	bool  WindOn = false;
	GameObject player;
	
	bool  playerSafe = false;
	
	void  Update (){
		if(WindOn == true){
			Wind();
		}	
	}
	void  Wind (){
		timer += Time.deltaTime;
		
		if (!playerSafe && timer >= timerWindStart && timer < timerReset){
			WindOnPlayer();
			wind.enableEmission = true;
			if(windSecond != null){
				windSecond.enableEmission = true;
			}
		}
		
		if (timer >= timerReset){
			timer -= timerReset;
		}
		if(timer < timerWindStart){
			wind.enableEmission = false;
			if(windSecond != null){
				windSecond.enableEmission = false;
			}
		}
	}
	
	void  OnTriggerEnter ( Collider hit  ){
		if(hit.gameObject.tag == "Player"){
			player.GetComponent<Rigidbody>().drag = 0.1f;
			WindOn = true;
			timer = 0;	
		}
	}
	
	void  OnTriggerExit ( Collider hit  ){
		if(hit.gameObject.tag == "Player"){
			player.GetComponent<Rigidbody>().drag = 100;
			WindOn = false;	
		}
	}
	
	void  WindOnPlayer (){
		player.GetComponent<Rigidbody>().AddForce(transform.forward * forcePower);
	}
}