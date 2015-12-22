using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {

	Transform player;
	public bool stage = true;
	public Transform anchor8;
	public Transform anchor10;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (stage) {
			this.transform.rotation = Quaternion.LookRotation ((Vector3.zero - player.position), Vector3.up);
		} else {
			this.transform.rotation = Quaternion.LookRotation ((Vector3.zero - player.position), Vector3.up);
		}
	}
}
