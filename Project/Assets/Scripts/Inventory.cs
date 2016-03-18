using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public static bool PuzzlePiece1;
	public static bool PuzzlePiece2;
	public static bool PuzzlePiece3;
	public static bool PuzzlePiece4;
	public static bool PuzzlePiece5;
	public static bool PuzzlePiece6;
	public static bool PuzzlePiece7;
	public static bool PuzzlePiece8;
	public static bool PuzzlePiece9;
	public static bool PuzzlePiece10;
	public static bool PuzzlePiece11;
	public static bool PuzzlePiece12;
	public static bool PuzzlePiece13;
	public static bool PuzzlePiece14;
	public static bool PuzzlePiece15;
	private GameObject UIButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void OnEnable () {
		if (PuzzlePiece1 == true) {
			UIButton = GameObject.Find ("Slot 1");
			UIButton.GetComponent<Button> ().interactable = true;
		} else {
			UIButton = GameObject.Find ("Slot 1");
			UIButton.GetComponent<Button> ().interactable = false;
		}

	}

	void Update(){
		if (Input.GetKeyUp(KeyCode.A)) {
			PuzzlePiece1 = true;
			OnEnable();
		}
	}

	void ReadSaveState () {
	//	if (
	//	GameObject.Find("SaveState")
	}
}
