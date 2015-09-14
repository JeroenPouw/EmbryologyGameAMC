// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
	
	public string searchTag;
	private GameObject closestMissle;
	private Transform target;
	public GameObject missileExpObject;
	QuestionScript scorePlus;
	//scorePlus = FindObjectOfType(typeof(Questions));
	Scores score;
	//score = FindObjectOfType(typeof(Score));
	public AudioClip enemyHurt;
	public EnemySpawner spawn;
	//spawn = FindObjectOfType(typeof(Enemy_Spawner_level1));
	public GameObject hitParticle;
	void  Start (){
		scorePlus = gameObject.GetComponent<QuestionScript>();
		score = gameObject.GetComponent<Scores>();
		spawn = gameObject.GetComponent<EnemySpawner>();
		//closestMissle = FindClosestEnemy();	
		if(closestMissle)
		{
			target = closestMissle.transform;
		}
	}
	
	void  Update (){
		transform.LookAt(target);
		transform.Translate(Vector3.forward * 20.0f * Time.deltaTime);
		if(target == null)
		{
			//closestMissle = FindClosestEnemy();
			
			if(closestMissle)
			{
				target = closestMissle.transform;
			}
		}
	}
	void  FindClosestEnemy (){
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag(searchTag);
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		
		foreach(GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			
			if(curDistance < distance)
			{
				closest = go;
				distance = curDistance;
			}
		}		
	//	return closest;
	}
	
	void  OnCollisionEnter ( Collision hit  ){
		if(hit.gameObject.tag == "Level1_wall" || hit.gameObject.name == "level2_new" || hit.gameObject.name == "level2_new_minimap" || hit.gameObject.tag == "Level3_wall" || hit.gameObject.name == "level3" || hit.gameObject.name == "level3_minimap"){
			Instantiate(hitParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0));
			Destroy(this.gameObject);
		}
		if(hit.gameObject.tag == "Enemy" && this.gameObject.GetComponent<Missile>().enabled == true){
			Renderer[] ourRenderer= gameObject.GetComponentsInChildren<Renderer>();
			foreach(Renderer renderer in ourRenderer)
			{
				renderer.enabled = false;
			}
			Instantiate(hitParticle, hit.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
			Scores.Score += 1;
			scorePlus.eenScore = true;
			this.gameObject.GetComponent<Collider>().enabled = false;
			gameObject.GetComponent<Collider>().enabled = false;
			this.gameObject.GetComponent<Renderer>().enabled = false;
			GetComponent<AudioSource>().PlayOneShot(enemyHurt);
			Destroy(hit.gameObject, enemyHurt.length);
			Destroy(this.gameObject, enemyHurt.length);
			spawn.enemySpawned -= 1;
		}
	}
	
	
}