using UnityEngine;
using System.Collections;

public class Slidingpuzzle : MonoBehaviour {
	public Transform slot;
	public GameObject[] targetSlot;
	float tempX;
	float tempY;
	public GameObject[] tiles;
	int correctTiles;
	// Use this for initialization
	void Start () {
		tiles = GameObject.FindGameObjectsWithTag ("PuzzelTile");
		targetSlot = GameObject.FindGameObjectsWithTag ("PuzzelSlot");
		for (int i = 0; i < tiles.Length; i++) {
			tiles[i] = GameObject.Find("Cube " +i);
		}
		for (int i = 0; i < targetSlot.Length; i++) {
			targetSlot[i] = GameObject.Find("slot " +i);
		}
	}
	void OnMouseDown(){
		correctTiles = 0;
	}

	void OnMouseUp(){
	if (Vector3.Distance(transform.position,slot.position)==1) { //Move clicked tile towards empty slot, if possible
			tempX = transform.position.x;
			tempY = transform.position.y;
			transform.position = new Vector3( slot.position.x,slot.position.y,0);
			transform.position = new Vector3(slot.position.x,slot.position.y,0);
			slot.position = new Vector3(tempX,slot.position.y,0);
			slot.position = new Vector3(slot.position.x,tempY,0);
		}
		for (int i = 0; i < tiles.Length; i++) { // Check how many tiles are in the correct position
			if (tiles[i].transform.position == targetSlot[i].transform.position ) {
				Debug.Log(i);
					correctTiles++;
			}else return;
		
		}
		Debug.Log (correctTiles);
		
	}
	// Update is called once per frame
	void Update () {
		if (correctTiles == 15) { // if all tiles are in the correct position:
			Application.LoadLevel("Overworld"); // Lvl complete! back to overworld.
		}
	
	}
}
