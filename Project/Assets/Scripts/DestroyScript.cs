using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter(Collision other){
		switch (this.gameObject.tag) { // switch case to check who is doing the colliding
		case "DNArepair":
			switch (other.gameObject.tag) {//switch case to check who we're colliding with
			case "Enemy":
				Destroy(this.gameObject);
				Destroy(other.gameObject);
			break;
			case "newcase": 
				break;
			}
						break;
		case "Player":
			switch (other.gameObject.tag) {
			case "Enemy":
				Destroy(this.gameObject);
			break;
			}
			break;
				}

	}
	// Update is called once per frame
	void Update () {
	}
}
