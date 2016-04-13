// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuzzelItem : MonoBehaviour {
	
	public static int count = 0;
	public string[] sizeObjects ;
	public static bool endGame = false;
	public RotateObjects rotatePuzzel;
	public GameObject InvSlots;
	public GameObject infoPanel;
	public GameObject slotsPanel;
	GameObject object1;
	GameObject object2;
	GameObject object3;
	GameObject currentObject;
	public Button slot1;
	public Button slot2;
	public Button slot3;

	void  Start (){
		rotatePuzzel = FindObjectOfType<RotateObjects>();
	}
	
	public void SpawnObjects (int pieceNumber){
		count = pieceNumber - 1;
		InvSlots.SetActive (false);
		infoPanel.SetActive (true);
		slotsPanel.SetActive (true);
		object1 = Instantiate(Resources.Load("Prefabs/" + sizeObjects[count] + "_size1")) as GameObject;
		object1.transform.parent = this.transform;
		object1.transform.localPosition = new Vector3 (slot1.transform.position.x,slot1.transform.position.y, slot1.transform.position.z);
		object1.transform.Rotate (Vector3.forward, 90f);
		object1.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);

		object2 = Instantiate(Resources.Load("Prefabs/" + sizeObjects[count] + "_size2")) as GameObject;
		object2.transform.parent = this.transform;
		object2.transform.localPosition = new Vector3 (slot2.transform.position.x,slot2.transform.position.y, slot2.transform.position.z);
		object2.transform.Rotate (Vector3.forward, 90f);
		object2.transform.localScale = new Vector3 (0.4f, 0.4f, 0.4f);

		object3 = Instantiate(Resources.Load("Prefabs/" + sizeObjects[count] + "_size3")) as GameObject;
		object3.transform.parent = this.transform;
		object3.transform.localPosition = new Vector3 (slot3.transform.position.x,slot3.transform.position.y, slot3.transform.position.z);
		object3.transform.Rotate (Vector3.forward, 90f);
		object3.transform.localScale = new Vector3 (0.6f, 0.6f, 0.6f);

		currentObject = GameObject.Find(sizeObjects[count]);
		currentObject.layer = 17;
	}
}