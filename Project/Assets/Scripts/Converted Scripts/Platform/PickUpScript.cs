// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {
	
	public int Ammo = 0;
	public GameObject DNArepair;
	public GameObject shot;
	public GameObject waterSplash;
	public Transform spawnPoint;
	public float interval = 0.2f;
	float nextShot = 0.2f;
	public AudioClip pickupDNARepairSound;
	public AudioClip shootDNARepairSound;
	public HealthStatusBar healthscript;
	public GameObject pickupParticle;
	public GameObject waterParticle;

	void Awake(){
		healthscript = gameObject.GetComponent<HealthStatusBar>();
	}

	void  Update (){
		if(Input.GetKey(KeyCode.Space) && Ammo > 0){
			Shoot();
		}
	}
	
	IEnumerator  OnCollisionEnter ( Collision hit  ){
		if(hit.gameObject.tag == "DNArepair" && Ammo <= 5){  
			Instantiate(pickupParticle, hit.gameObject.transform.position, Quaternion.Euler(0, 0, 0)); 
			GetComponent<AudioSource>().PlayOneShot(pickupDNARepairSound);
			healthscript.shieldWidth = healthscript.shieldWidth + 43;
			hit.gameObject.active = false;
			Ammo += 1; 
			if(hit.gameObject.active == false){
				yield return new WaitForSeconds(5);
				hit.gameObject.active = true;
				hit.gameObject.GetComponent<Missile>().enabled = false;
			}     
		} 
		if(hit.gameObject.name == "DNA_Repair(Clone)"){
			Destroy(hit.gameObject);
		} 
		else if(hit.gameObject.tag == "DNArepair" && Ammo >= 6){ 
			Instantiate(pickupParticle, hit.gameObject.transform.position, Quaternion.Euler(0, 0, 0)); 
			Destroy(hit.gameObject);
			GetComponent<AudioSource>().PlayOneShot(pickupDNARepairSound);
		}         
	}
	
	void  Shoot (){
		if (Time.time >= nextShot && Time.timeScale != 0){ // only shoot after interval
			nextShot = Time.time + interval; // update nextShot
			shot = Instantiate(DNArepair, spawnPoint.transform.position, Quaternion.identity) as GameObject;
			waterSplash = Instantiate(waterParticle, shot.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject; 
			waterSplash.gameObject.transform.parent = shot.gameObject.transform;
			shot.GetComponent<Missile>().enabled = true;
			GetComponent<AudioSource>().PlayOneShot(shootDNARepairSound);
			Ammo -= 1; 
			healthscript.shieldWidth = healthscript.shieldWidth - 43;
		}         
	}
	
	
	
}