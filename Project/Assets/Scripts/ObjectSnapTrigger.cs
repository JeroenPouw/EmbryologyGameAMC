using UnityEngine;
using System.Collections;

public class ObjectSnapTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "PipeL")
		{
			Debug.Log (gameObject.transform.name);
			string partnerName= "Tile";
			GameObject partnerGO = GameObject.Find(gameObject.transform.name);
		}
	}

}
