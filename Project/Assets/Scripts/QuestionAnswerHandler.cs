using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionAnswerHandler : MonoBehaviour {

	public Text questionref;
	public Text answerref;

	private string correctanswer = "";
	private string[] hints;
	private int hintcounter = 0;
	public GameObject player;

	private GameObject pieceref;

	void Start () {
		hints = new string[3];
		hints [0] = "";
		hints [1] = "";
		hints [2] = "";
	}

	void OnEnable () {
		player.GetComponent<MouseTorque> ().enabled = false;
		player.GetComponent<MovementScript> ().enabled = false;
	}

	void OnDisable () {
		player.GetComponent<MouseTorque> ().enabled = true;
		player.GetComponent<MovementScript> ().enabled = true;
	}

	public void ConfirmAnswer () {
		if (answerref.text == correctanswer) {

			hintcounter = 0;
			questionref.text = "";
			answerref.text = "";
//			GameObject.Find("SaveState").GetComponent<SaveState> ().SaveVariable(0,pieceref.GetComponent<PuzzlePiecePickup>().piecenumber, "");
			pieceref.SetActive(false);
			this.gameObject.SetActive (!this.gameObject.activeSelf);
		} else {
			if (hintcounter < hints.Length) {
				questionref.text += hints[hintcounter];
				hintcounter++;
			}
		}
	}

	public void Cancel () {
		this.gameObject.SetActive (!this.gameObject.activeSelf);
	}

	public void Question () {



	}

	public void Question (string _question, string _answer, GameObject _pieceref) {
		questionref.text = _question;
		correctanswer = _answer;
		pieceref = _pieceref;
	}
}
