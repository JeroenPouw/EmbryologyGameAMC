	using UnityEngine;
using System.Collections;

public class SceneSwitchScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		switch (this.gameObject.tag) {
		case "Yolk Sac":
			Debug.Log(gameObject.tag);
			break;
		case "Endoderm":
			Debug.Log(gameObject.tag);
			break;
		case "Ectoderm":
			Debug.Log(gameObject.tag);
			break;
		case "Mesoderm":
			Debug.Log(gameObject.tag);
			break;
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (Input.GetKeyDown(KeyCode.P)) {
			switch (this.gameObject.tag) {
			case "Yolk Sac":
				Application.LoadLevel("Yolk Sac Level");
				break;
			case "Endoderm":
				Application.LoadLevel("Endoderm Level");
				break;
			case "Ectoderm":
				Application.LoadLevel("Ectoderm Level");
				break;
			case "Mesoderm":
				Application.LoadLevel("Mesoderm 1");
				break;
			}
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
