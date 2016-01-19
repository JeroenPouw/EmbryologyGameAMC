using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {

	Transform player;
	public bool stage = true;
	public Transform ventral8;
	public Transform ventral10;
	public Transform cranial;
	Transform ventralicon;
	Transform dorsalicon;

	void Start () {
		player = GameObject.Find ("Player").transform;
	//	ventral8 = GameObject.Find ("Ventral8").transform;
	//	ventral10 = GameObject.Find ("Ventral10").transform;
	//	cranial = GameObject.Find ("Cranial").transform;
		ventralicon = GameObject.Find ("Ventral_Icon").transform;
		dorsalicon = GameObject.Find ("Dorsal_Icon").transform;

	}
	
	/*
	 * 
	 */
	void Update () {
		if (stage) {
			this.transform.rotation = Quaternion.LookRotation ((ventral8.position - player.position), -cranial.position);
		} else {
			this.transform.rotation = Quaternion.LookRotation ((ventral10.position - player.position), -cranial.position);
		}
		ventralicon.rotation = Quaternion.LookRotation ((ventralicon.position),Vector3.up);
		dorsalicon.rotation = Quaternion.LookRotation ((dorsalicon.position),Vector3.up);
	}
}
