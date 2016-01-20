using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {

	void Start () {

	}

	void Update () {
		var rotation = Quaternion.LookRotation(Vector3.up , Vector3.forward);
		transform.rotation = rotation;
	}
}
