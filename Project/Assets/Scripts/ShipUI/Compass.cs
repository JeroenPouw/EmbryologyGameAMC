using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {

	public Transform playerref;

	void Update () {
		this.transform.rotation = Quaternion.LookRotation (-Vector3.forward, Vector3.up);
	}
}
