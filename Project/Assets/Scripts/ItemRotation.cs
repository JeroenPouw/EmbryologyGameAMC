using UnityEngine;
using System.Collections;

public class ItemRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.rotation = Random.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward * Time.deltaTime * 50, Space.Self);
		transform.Rotate(Vector3.up * Time.deltaTime * 75, Space.World);
	}
}
