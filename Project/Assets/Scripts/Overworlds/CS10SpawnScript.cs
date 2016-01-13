using UnityEngine;
using System.Collections;

public class CS10SpawnScript : MonoBehaviour {
	TeleportScript tpScript;
	public Transform neuraltubePoint;
	public Transform hearthPoint;
	public Transform playerPrefab;
	GameObject Player;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player(Clone)");
		if (Player == null) {
			Instantiate (playerPrefab, Vector3.zero, Quaternion.identity);
			Player = GameObject.Find ("Player(Clone)");
		}
		if (Player.activeSelf == false) {
			Player.SetActive(true);
		}
		Spawnfunction (currentDermTracker.currentDerm);
	}

	void Spawnfunction(int currentderm){
		switch (currentderm) {
		case 1:
			break;
		case 2:
			break;
		case 3:
			Player.transform.position = hearthPoint.transform.position;
			break;
		case 4:
			Player.transform.position = neuraltubePoint.transform.position;
			break;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
