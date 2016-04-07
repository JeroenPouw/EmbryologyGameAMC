using UnityEngine;
using System.Collections;

public class PuzzlePiecePickup : MonoBehaviour {

	public string question;
	public string answer;
	public string[] hints;
	public int piecenumber;
	public QuestionAnswerHandler boxref;

	void Start () {
//		if (GameObject.Find ("SaveState").GetComponent<SaveState> ().GetPuzzleStatus (piecenumber) != "o") {
//			this.gameObject.SetActive(false);
//		}
	}
	
	void OnTriggerEnter(Collider _collision) {
		boxref.gameObject.SetActive (true);
		boxref.Question (question, answer, this.gameObject);
	}
}
