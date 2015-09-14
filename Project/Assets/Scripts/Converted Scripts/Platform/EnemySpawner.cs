// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab; // prefab to spawn
	public int enemySpawned; // enemy spawned
	public bool  spawn; 
	public int minWait;
	public int maxWait;
	public int waitTime;
	
	void  Start (){
		minWait = 1;
		maxWait = 10;
		waitTime = Random.Range(minWait, maxWait);
		spawn = true;
	}
	
	void  Update (){
		if(spawn && enemySpawned <= 2){
			Spawn();
		}
	}
	
	void  Spawn (){
		Instantiate(enemyPrefab, transform.position, transform.rotation); // spawn at spawner loaction
		enemySpawned += 1;
		NewWaitTime();
		spawn = false;
		SetSpawn();	
	} 
	
	IEnumerator  SetSpawn (){
		yield return new WaitForSeconds(waitTime);
		spawn = true;
	}
	
	void  NewWaitTime (){
		waitTime = Random.Range(minWait, maxWait);
	}
}