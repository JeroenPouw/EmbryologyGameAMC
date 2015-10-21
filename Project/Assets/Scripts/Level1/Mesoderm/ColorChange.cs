using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColorChange : MonoBehaviour {
	public bool isCorrect;
	public GameObject child1;
	public GameObject child2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (isCorrect) {
			child1.GetComponent<Renderer>().material.color = Color.green;
			if (child2 != null) {
				child2.GetComponent<Renderer>().material.color = Color.green;
			}
			isCorrect = false;
		}
	}
}
