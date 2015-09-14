using UnityEngine;
using System.Collections;

public class DeadTime : MonoBehaviour {
	public int deadTime;
	// Use this for initialization
	void Awake () {
		Destroy (this.gameObject, deadTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
