using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalWindow : MonoBehaviour {

	public Text message;
	public Image iconImage;
	public Button confirmButton;
	public Text titletext;
	public GameObject modalPanel;
	public InputField input;
	string answer;
	GameObject player;

	private static ModalWindow modalWindow;
	PuzzlePickup pickUp;

	void Awake(){
		pickUp = GetComponent<PuzzlePickup> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	public static ModalWindow Instance(){
		if (!modalWindow) {
			modalWindow = FindObjectOfType(typeof (ModalWindow)) as ModalWindow;
			if (!modalWindow) {
				Debug.LogError("There needs to be one active ModalWindow script on a GameObject in your scene");
			}
		}
		return modalWindow;
	}

	// This function gets called when the player triggers a story trigger. Activates all the relevant UI elements.
	public void Confirm(string message,string title, UnityAction confirmAction){
		Time.timeScale = 0;
		modalPanel.SetActive (true);
		confirmButton.onClick.RemoveAllListeners();
		confirmButton.onClick.AddListener (confirmAction);
		confirmButton.onClick.AddListener (ClosePanel);
		player.GetComponent<CameraSwitch> ().enabled = false;

	
		this.message.text = message;
		this.iconImage.gameObject.SetActive (false);
		this.titletext.text = title;
		confirmButton.gameObject.SetActive (true);

	}

	// This functions gets called when the player triggers a puzzle piece. Activates an inputfield where Confirm() activates a confirm button.
	public void Question(string message, string title, UnityAction questionAction){
		Time.timeScale = 0;
		modalPanel.SetActive (true);
		confirmButton.onClick.RemoveAllListeners();
		confirmButton.onClick.AddListener (questionAction);
		confirmButton.onClick.AddListener (ClosePanel);
		//player.GetComponent<CameraSwitch> ().enabled = false;

		this.answer = PuzzlePickup.answer;
		this.message.text = message;
		this.titletext.text = title;
		input.gameObject.SetActive (true);
	}

	// This functions gets called when the player presses the 'Okay' button.
	void ClosePanel(){
		player.GetComponent<CameraSwitch> ().enabled = true;
		confirmButton.gameObject.SetActive (false);
		modalPanel.SetActive (false);
		if (Time.timeScale != 1) {
			Time.timeScale = 1;
		}
	}

	// This function gets called when the player finishes typing, or confirms their input.
	public void InputCheck(){
		Debug.Log (input.text);
		Debug.Log (this.answer);
		if (input.text == this.answer) {
			input.gameObject.SetActive(false);
			confirmButton.gameObject.SetActive(true);
		}
	}

	void Update(){
	if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");
		}
	}


}
