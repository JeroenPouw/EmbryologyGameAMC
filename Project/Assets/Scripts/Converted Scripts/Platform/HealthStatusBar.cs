// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class HealthStatusBar : MonoBehaviour {
	
	public Transform SpawnPoint;
	public GameObject player;
	public Texture2D gameOverTexture;
	bool  playerDead;
	float pauseDelay = 3;
	float firstPauseDelay = 1;
	
	public Texture backgroundTexture;
	public Texture foregroundTexture;
	public Texture frameTexture;
	
	int healthWidth = 242;
	int healthHeight = 67;
	
	int healthMarginLeft = 17;
	int healthMarginTop = 14;
	
	int frameWidth = 266;
	int frameHeight = 65;
	
	int frameMarginLeft = 10;
	int frameMarginTop = 10;
	
	
	public Texture shieldforegroundTexture;
	public Texture shieldframeTexture;
	
	public int shieldWidth = -16;
	public int shieldHeight = 67;
	
	int shieldMarginLeft = 17;
	int shieldMarginTop = 83;
	
	int shieldframeWidth = 266;
	int shieldframeHeight = 65;
	
	int shieldframeMarginLeft = 10;
	int shieldframeMarginTop = 55;
	
	PickUpScript script;
	
	EnemySpawner spawn;
	
	Scores scriptScore;
	Color statColor = Color.magenta;
	
	public AudioClip lostLifeSound;
	public AudioClip gameOverSound;
	public AudioClip nerveHitSound;
	public GameObject enemyhitParticle;

	void Awake(){
		script = gameObject.GetComponent<PickUpScript>();
		spawn = gameObject.GetComponent<EnemySpawner>();
		scriptScore = gameObject.GetComponent<Scores>();
	}
	void  OnGUI (){
		GUI.depth = 1;
		if(playerDead == true){
			GUI.color = statColor;
			GUI.Window (0, new Rect (Screen.width / 2 -200, Screen.height / 4, 400, 150), GameOverWindow, "Game over");
			GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), gameOverTexture);
		}
		if(playerDead == false){
			GUI.DrawTexture( new Rect(frameMarginLeft,frameMarginTop, frameMarginLeft + frameWidth, frameMarginTop + frameHeight), backgroundTexture, ScaleMode.ScaleToFit, true, 0 );
			
			GUI.DrawTexture( new Rect(healthMarginLeft,healthMarginTop,healthWidth + healthMarginLeft, healthHeight), foregroundTexture,ScaleMode.ScaleAndCrop ,true, 10.0f );
			
			GUI.DrawTexture( new Rect(frameMarginLeft,frameMarginTop, frameMarginLeft + frameWidth,frameMarginTop + frameHeight), frameTexture, ScaleMode.ScaleToFit, true, 0 );
			
			GUI.DrawTexture( new Rect(shieldMarginLeft,shieldMarginTop,shieldWidth + shieldMarginLeft, shieldHeight), shieldforegroundTexture,ScaleMode.ScaleAndCrop ,true, 10.0f );
			
			GUI.DrawTexture( new Rect(shieldframeMarginLeft,shieldframeMarginTop, shieldframeMarginLeft + shieldframeWidth,shieldframeMarginTop + shieldframeHeight), shieldframeTexture, ScaleMode.ScaleToFit, true, 0 );
		}
	}
	void  OnCollisionEnter ( Collision hit  ){
		if(hit.gameObject.tag == "Enemy" && shieldWidth <= -16){
			GameObject enemyHit = Instantiate(enemyhitParticle, hit.gameObject.transform.position, Quaternion.Euler(0, 0, 0))as GameObject;
			reduceHealth();
			Destroy(hit.gameObject);
			spawn.enemySpawned -= 1;		
		}
		else if(hit.gameObject.tag == "Enemy" && shieldWidth >= -15){
			GameObject enemyHit2 = Instantiate(enemyhitParticle, hit.gameObject.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
			GetComponent<AudioSource>().PlayOneShot(lostLifeSound);
			script.Ammo -= 1;
			shieldWidth -= 43;
			Destroy(hit.gameObject);
			spawn.enemySpawned -= 1;
		}
	}
	void  reduceHealth (){
		if(healthWidth >= -8) {
			GetComponent<AudioSource>().PlayOneShot(lostLifeSound);
			healthWidth = healthWidth - 25;
		}  
		if(healthWidth <= -17){
			GetComponent<AudioSource>().PlayOneShot(gameOverSound);
			playerDead = true;
			Scores.Score = 0;
			Time.timeScale = 0;
		} 
	}
	public void  reduceHealthElectro (){
		if(healthWidth >= -8) {
			GetComponent<AudioSource>().PlayOneShot(nerveHitSound);
			healthWidth = healthWidth - 25;
		}  
		if(healthWidth <= -17){
			GetComponent<AudioSource>().PlayOneShot(gameOverSound);
			playerDead = true;
			Scores.Score = 0;
			Time.timeScale = 0;
		} 
	}
	void  GameOverWindow (int windowID){
		GUIStyle labelStyle=GUI.skin.label;
		GUI.skin.label.fontSize = 14;
		GUI.color = statColor;
		GUI.Label (new Rect (10, 20, 390, 60), "You can try again by pressing restart or you can go back to the main menu.");
		if(GUI.Button (new Rect(75, 75, 110, 50), "Restart")){
			Time.timeScale = 1.0f;
			playerDead = false;
			player.transform.position = SpawnPoint.position;
			healthWidth = 242;
		}
		if(GUI.Button (new Rect(200, 75, 110, 50), "Back to menu")){
			Application.LoadLevel(0);
			Time.timeScale = 1.0f;
			playerDead = false;
		}
	}
	
}