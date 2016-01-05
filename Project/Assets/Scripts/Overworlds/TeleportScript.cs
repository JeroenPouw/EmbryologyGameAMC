using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
	GameObject dermSelect;
	GameObject player;
	public Transform primitiveDestination;
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
			player.transform.position = primitiveDestination.transform.position;
			break;
		case 2:
			player.transform.position = endoDestination.transform.position;
			break;
		case 3:
			player.transform.position = mesoDestination.transform.position;
			break;
		case 4:
			player.transform.position = ectoDestination.transform.position;
			break;
		}
		dermSelect.SetActive (false);
	}
	void OnTriggerEnter(Collider other){
		Debug.Log ("derm trigger");
		dermSelect.SetActive (true);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
