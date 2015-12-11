using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalWindow : MonoBehaviour {

	public Text message;
	public Image iconImage;
	public Button confirmButton;
	public GameObject modalPanel;

	private static ModalWindow modalWindow;
	
	public static ModalWindow Instance(){
		if (!modalWindow) {
			modalWindow = FindObjectOfType(typeof (ModalWindow)) as ModalWindow;
			if (!modalWindow) {
				Debug.LogError("There needs to be one active ModalWindow script on a GameObject in your scene");
			}
		}
		return modalWindow;
	}

	public void Confirm(string message, UnityAction confirmAction){
		modalPanel.SetActive (true);
		confirmButton.onClick.RemoveAllListeners();
		confirmButton.onClick.AddListener (confirmAction);
		confirmButton.onClick.AddListener (ClosePanel);

		this.message.text = message;
		this.iconImage.gameObject.SetActive (false);
		confirmButton.gameObject.SetActive (true);
	}

	void ClosePanel(){
		modalPanel.SetActive (false);
	}


}
