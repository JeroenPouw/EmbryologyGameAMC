using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
	public GameObject dermSelect;
	public Transform primitiveDestination;
	public Transform endoDestination;
	public Transform mesoDestination;
	public Transform ectoDestination;
	private int currentDerm = 3; // default state being Mesoderm
	private GameObject player;

	void Start () {
		player = GameObject.Find ("Player");
		DermSelect(currentDermTracker.currentDerm);
	}
	// 1 = connecting stalk
	// 2 = Endoderm
	// 3 = Mesoderm
	// 4 = Ectoderm
	public void DermSelect(int derm){
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
		player.GetComponent<MouseTorque> ().enabled = true;
		player.GetComponent<MovementScript> ().enabled = true;
		this.gameObject.SetActive (false);
	}

	void OnTriggerEnter(Collider other){
		dermSelect.SetActive (true);
		player.GetComponent<MouseTorque> ().enabled = false;
		player.GetComponent<MovementScript> ().enabled = false;
	}

}
