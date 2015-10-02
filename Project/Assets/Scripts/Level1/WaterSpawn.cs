using UnityEngine;
using System.Collections;

public class WaterSpawn : MonoBehaviour {
	public Transform water;
	// Use this for initialization
	void Start () {
		for (float y = 0; y < 39; y++) {
			for (float x = 0; x < 64; x++) {
				//Instantiate(water, new Vector3(x-15, y+4, 0), Quaternion.identity);
				Instantiate(water, new Vector3((x*0.5f)-15, (y*0.5f)+14.5f, 0f), Quaternion.identity);

			}
		}
		for (float y = 0; y < 10; y++) {
			for (int x = 0; x < 10; x++) {
				Instantiate(water, new Vector3((x*0.5f)-2f,(y*0.5f)-.3f,0f), Quaternion.identity);
				Instantiate(water, new Vector3((x*0.5f)-14f,(y*0.5f)-.3f,0f), Quaternion.identity);
				Instantiate(water, new Vector3((x*0.5f)+10f,(y*0.5f)-.3f,0f), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
