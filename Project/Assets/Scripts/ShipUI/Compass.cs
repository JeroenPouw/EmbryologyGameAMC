using UnityEngine;
using System.Collections;

public class Compass : MonoBehaviour {

	void Update () {
		this.transform.rotation = Quaternion.LookRotation (-Vector3.forward, Vector3.up);
	}
}
