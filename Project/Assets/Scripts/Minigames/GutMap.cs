using UnityEngine;
using System.Collections;

public class GutMap : MonoBehaviour {

	public Transform[] goalandblob;
	public Vector3[] winpoints;
	public Vector3[] blobs;
	public int points = 0;

	void Start () {
		foreach (Vector3 point in winpoints) {
			Instantiate(goalandblob[0],point,Quaternion.identity);
			points++;
		}
		foreach (Vector3 point in blobs) {
			Instantiate(goalandblob[1],point,Quaternion.identity);
		}
	}

//	GameObject.Find("SaveState").GetComponent<SaveState>().SaveVariable(GameObject.Find("SaveState").GetComponent<SaveState>().loaded_data.lvl+1,0,"");
//	Application.LoadLevel(2);
}
