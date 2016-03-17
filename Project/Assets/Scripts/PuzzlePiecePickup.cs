using UnityEngine;
using System.Collections;

public class PuzzlePiecePickup : MonoBehaviour {

	public string question;
	public string answer;
	public string[] hints;
	public int piecenumber;
	public QuestionAnswerHandler boxref;

	void Start () {
	//	boxref = GameObject.Find ("Dialog Panel");
	}
	
	void OnTriggerEnter(Collider _collision) {
		boxref.gameObject.SetActive (true);
		boxref.Question (question, answer, this.gameObject);
	}
}
