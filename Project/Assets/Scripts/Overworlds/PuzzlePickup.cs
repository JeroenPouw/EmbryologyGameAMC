using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class PuzzlePickup : MonoBehaviour {
	TextAsset questionSource;
	public Text question;
	public static string answer;
	private ModalWindow mWindow;
	private UnityAction myConfirmAction;

	void Awake(){
		mWindow = ModalWindow.Instance();
		myConfirmAction = new UnityAction (TestConfirmFunction);
	}
	
	void OnTriggerEnter(){
		// This statement handles the parameters for every puzzle piece. This include the boolean for the puzzle, the question and answer.
		switch (this.gameObject.name) {
		case "Piece1":
			Inventory.PuzzlePiece1 = true;
			questionSource = Resources.Load("MyTexts/"+this.gameObject.name)as TextAsset;
			question.text = "" + questionSource;
			answer = "answer1";
			mWindow.Question(""+question.text
			                ,"You've Encountered a Puzzle Piece!"
			                ,myConfirmAction );
			break;
		case "Piece2":
			Inventory.PuzzlePiece2 = true;
			break;
		case "Piece3":
			Inventory.PuzzlePiece3 = true;
			break;
		case "Piece4":
			Inventory.PuzzlePiece4 = true;
			break;
		case "Piece5":
			Inventory.PuzzlePiece5 = true;
			break;
		case "Piece6":
			Inventory.PuzzlePiece6 = true;
			break;
		case "Piece7":
			Inventory.PuzzlePiece7 = true;
			break;
		case "Piece8":
			Inventory.PuzzlePiece8 = true;
			break;
		case "Piece9":
			Inventory.PuzzlePiece9 = true;
			break;
		case "Piece10":
			Inventory.PuzzlePiece10 = true;
			break;
		case "Piece11":
			Inventory.PuzzlePiece11 = true;
			break;
		case "Piece12":
			Inventory.PuzzlePiece12 = true;
			break;
		case "Piece13":
			Inventory.PuzzlePiece13 = true;
			break;
		case "Piece14":
			Inventory.PuzzlePiece14 = true;
			break;
		case "Piece15":
			Inventory.PuzzlePiece15 = true;
			break;
		}
		Time.timeScale = 0;
		Destroy (this.gameObject);
	}

	void TestConfirmFunction(){
		
	}
}
