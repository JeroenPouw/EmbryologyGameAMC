using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public static bool[] puzzlepiece;
	private GameObject UIButton;

	void Start () {
		puzzlepiece = new bool[16];
		for (int i = 1; i < puzzlepiece.Length; i++) {
			puzzlepiece[i] = true;
		}
		OnEnable ();
		ReadSaveState ();
	}

	void Update () {

	}

	public void OnEnable () {
		for (int i = 1; i < puzzlepiece.Length; i++) {
			if (puzzlepiece[i]) {
				UIButton = GameObject.Find ("Slot " + i.ToString());
				UIButton.GetComponent<Button> ().interactable = true;
			} else {
				UIButton = GameObject.Find ("Slot " + i.ToString());
				UIButton.GetComponent<Button> ().interactable = false;
			}
		}
	}

	void ReadSaveState () {
		try {
			SaveState save = GameObject.Find ("SaveState").GetComponent<SaveState> ();
			if (save != null) {
				for (int i = 1; i <= 15; i++) {
					if (save.loaded_data.puztrack.Substring(save.loaded_data.puztrack.IndexOf(i.ToString()+1,1)) == "x") {
						puzzlepiece[i] = true;
					}
				}
			}
		}
		catch (UnityException e) {

		}
	}

	public void PiecePlaced (int _piecenumber) {
		puzzlepiece [_piecenumber] = false;
	}
}
