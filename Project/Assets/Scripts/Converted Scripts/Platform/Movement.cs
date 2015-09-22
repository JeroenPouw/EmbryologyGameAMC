// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	

	float speed= 16.0f;
	bool  particleCollider = false;
	Winds wind;
	public bool  inCameraZone = false;
	bool  singlePress = false;
	//LevelInfo levelinfoScript;

	void Awake(){
		//wind = gameObject.GetComponent<Winds>();
		//levelinfoScript = gameObject.GetComponent<LevelInfo>();
	}
	public void IsMoving (){

	}
	void  Update (){
		if(singlePress == false){
			speed = 12;
		}
		if(singlePress == true){
			speed = 16;
		}
		if(Input.GetKey("left")||Input.GetKey(KeyCode.A))
		{
			singlePress = true;
			//levelinfoScript.infoClicked = false;
			this.transform.rotation = Quaternion.Euler(0, 0, 0);
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		if(Input.GetKey("right")||Input.GetKey(KeyCode.D))
		{	
			singlePress = true;
			//levelinfoScript.infoClicked = false;
			this.transform.rotation = Quaternion.Euler(0, 180, 0);
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		if(Input.GetKey("up")||Input.GetKey(KeyCode.W))
		{
			singlePress = true;
			//levelinfoScript.infoClicked = false;
			this.transform.rotation = Quaternion.Euler(0, 90, 0);
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		if(Input.GetKey("down")||Input.GetKey(KeyCode.S))
		{
			singlePress = true;
			//levelinfoScript.infoClicked = false;
			this.transform.rotation = Quaternion.Euler(0, 270, 0);
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		
		if(Input.GetKey("left") && Input.GetKey("up") || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)){
			singlePress = false;
			//levelinfoScript.infoClicked = false;
			this.transform.rotation = Quaternion.Euler(0, 45, 0);
		}
		if(Input.GetKey("left") && Input.GetKey("down") || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)){
			singlePress = false;
			//levelinfoScript.infoClicked = false;
			this.transform.rotation = Quaternion.Euler(0, 315, 0);
		}
		if(Input.GetKey("right") && Input.GetKey("down") || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)){
			singlePress = false;
			//levelinfoScript.infoClicked = false;
			this.transform.rotation = Quaternion.Euler(0, 225, 0);
		}
		if(Input.GetKey("right") && Input.GetKey("up") || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)){
			singlePress = false;
			//levelinfoScript.infoClicked = false;
			this.transform.rotation = Quaternion.Euler(0, 135, 0);
		}
	}
	void  OnTriggerEnter ( Collider hit  ){
		if(hit.gameObject.name == "HallwayCollide"){
			inCameraZone = true;
		}
		
	}
	void  OnTriggerExit ( Collider hit  ){
		if(hit.gameObject.name == "HallwayCollide"){
			inCameraZone = false;
		}
		
	}
	
}