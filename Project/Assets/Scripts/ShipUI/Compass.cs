using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {

	void Start () {

	}

	void Update () {
		this.transform.rotation = Quaternion.LookRotation(Vector3.up , Vector3.forward);
	}
}
