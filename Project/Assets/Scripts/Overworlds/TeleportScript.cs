using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
	GameObject dermSelect;
	GameObject player;
	public Transform connstalkDestination;
	public Transform endoDestination;
	public Transform mesoDestination;
	public Transform ectoDestination;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		dermSelect = GameObject.Find ("DermSelectPanel");
		if (dermSelect != null) {
			dermSelect.SetActive (false);
		}
	}
	// 1 = connecting stalk
	// 2 = Endoderm
	// 3 = Mesoderm
	// 4 = Ectoderm
	public void DermSelect(int derm){
	switch (derm) {
		case 1:
			//do seomething
			break;
		case 2:
			//do seomething
			break;
		case 3:
			//do seomething
			break;
		case 4:
			//do seomething
			break;
		}
	}
	void OnTriggerenter(Collider other){
		dermSelect.SetActive (true);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
