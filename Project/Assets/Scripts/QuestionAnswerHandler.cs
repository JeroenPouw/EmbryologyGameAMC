using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionAnswerHandler : MonoBehaviour {

	public Text questionref;
	public Text answerref;

	private string correctanswer;
	private string[] hints;
	private int hintcounter = 0;

	void Start () {
		hints = new string[3];
		hints [0] = "";
		hints [1] = "";
		hints [2] = "";
	}

	void Update () {

	}

	public void ConfirmAnswer () {
		if (answerref.text == correctanswer) {

			hintcounter = 0;
			questionref.text = "";
			answerref.text = "";
			this.gameObject.SetActive (!this.gameObject.activeSelf);
		} else {
			if (hintcounter < hints.Length) {
				questionref.text += hints[hintcounter];
				hintcounter++;
			}
		}
	}

	void Question () {



	}

	void Question (string _question, string _answer) {
		questionref.text = _question;
		correctanswer = _answer;
	}
}
