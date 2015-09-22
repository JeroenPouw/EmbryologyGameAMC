// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	float speed = 7.0f;
	float timing;
	PickUpScript pickup;
	//pickup = FindObjectOfType(typeof(PickUp));
	float interval = 0.2f;
	float nextTime = 0.2f;
	bool  isHit = false;
	Scores score;
	//score = FindObjectOfType(typeof(Score));
	EnemySpawner spawn;
	//spawn = FindObjectOfType(typeof(Enemy_Spawner_level1));
	QuestionScript scorePlus;
	//scorePlus = FindObjectOfType(typeof(Questions));
	Transform model;
	AudioClip enemyHurt;
	GameObject hitParticle;
	
	void  Start (){
		pickup = gameObject.GetComponent<PickUpScript>();
		score = gameObject.GetComponent<Scores>();
		spawn = gameObject.GetComponent<EnemySpawner>();
		scorePlus = gameObject.GetComponent<QuestionScript> ();
		Vector3 randomDirection = new Vector3(Random.Range(0, 0),Random.Range(-359, 359),Random.Range(0, 0));
		//transform.Rotate(randomDirection);
		timing = 0;
	}
	
	void  Update (){

	}
	void  FixedUpdate (){
		timing+=Time.deltaTime;
		transform.position += transform.forward*speed*Time.deltaTime;
		if(timing > 3){
			ChangeDirection();
			timing = 0;
		}
	}
	
	void  ChangeDirection (){
		Vector3 randomDirection = new Vector3(Random.Range(0, 0),Random.Range(-359, 359),Random.Range(0, 0));
		transform.Rotate(randomDirection);
	}
	
	void  OnCollisionEnter ( Collision hit  ){
		if(hit.gameObject.tag == "DNArepair" && hit.gameObject.GetComponent<Missile>().enabled == false){
			Instantiate(hitParticle, hit.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
			Destroy(hit.gameObject);
			Destroy(this.gameObject);
			spawn.enemySpawned -= 1;
		}
		if(hit.gameObject.tag == "Level1_wall"){
			Vector3 randomDirection = new Vector3(Random.Range(0, 0),Random.Range(-180, -180),Random.Range(0, 0));
			//transform.Rotate(randomDirection);	
		}
		if(hit.gameObject.name == "level2_new" || hit.gameObject.name == "level2_new_minimap" ){
			Vector3 randomDirectionlvl2 = new Vector3(Random.Range(0, 0),Random.Range(-180, -180),Random.Range(0, 0));
			//transform.Rotate(randomDirectionlvl2);	
		}
		if(hit.gameObject.tag == "Level3_wall" || hit.gameObject.name == "level3" || hit.gameObject.name == "level3_minimap" ){
			Vector3 randomDirectionlvl3 = new Vector3(Random.Range(0, 0),Random.Range(-180, -180),Random.Range(0, 0));
			//transform.Rotate(randomDirectionlvl3);	
		}
	}	
	void  OnTriggerEnter ( Collider hit  ){
		if(hit.gameObject.name == "TutorialWalls"){
			Vector3 randomDirection1 = new Vector3(Random.Range(0, 0),Random.Range(-180, -180),Random.Range(0, 0));
			//transform.Rotate(randomDirection1);
		}
		if(hit.gameObject.name == "QuestionRoomWall"){
			Vector3 randomDirection2 = new Vector3(Random.Range(0, 0),Random.Range(-180, -180),Random.Range(0, 0));
			//transform.Rotate(randomDirection2);
		}
	}
	
	
	
	
	
	
}