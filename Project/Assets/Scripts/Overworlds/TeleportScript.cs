using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
	public GameObject dermSelect;
	GameObject player;
	public Transform primitiveDestination;
	public Transform endoDestination;
	public Transform mesoDestination;
	public Transform ectoDestination;
	int currentDerm = 3; // default state being Mesoderm

	void Start () {
		player = GameObject.Find ("Player(Clone)");
		DermSelect(currentDermTracker.currentDerm);
	}
	// 1 = connecting stalk
	// 2 = Endoderm
	// 3 = Mesoderm
	// 4 = Ectoderm
	public void DermSelect(int derm){
		Debug.Log ("gettriggered");
	switch (derm) {
		case 1:
			player.transform.position = primitiveDestination.transform.position;
			currentDermTracker.currentDerm = 1;
			currentDerm = 1;
			break;
		case 2:
			player.transform.position = endoDestination.transform.position;
			currentDermTracker.currentDerm = 2;
			currentDerm = 2;
			break;
		case 3:
			player.transform.position = mesoDestination.transform.position;
			currentDermTracker.currentDerm = 3;
			currentDerm = 3;
			break;
		case 4:
			player.transform.position = ectoDestination.transform.position;
			currentDermTracker.currentDerm = 4;
			currentDerm = 4;
			break;
		}
		dermSelect.SetActive (false);
	}
	void OnTriggerEnter(Collider other){
		dermSelect.SetActive (true);
	}

}
