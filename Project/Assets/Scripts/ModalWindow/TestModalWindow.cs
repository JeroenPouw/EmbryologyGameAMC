using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestModalWindow : MonoBehaviour {

	private ModalWindow modalWindow;
	private UnityAction myConfirmAction;

	void Awake(){
		modalWindow = ModalWindow.Instance ();

		myConfirmAction = new UnityAction (TestConfirmFunction);
	}

	void OnTriggerEnter(){
		modalWindow.Confirm ("" +InfoManager.s, myConfirmAction);
		this.gameObject.SetActive (false);

	}

	void TestConfirmFunction(){
		Debug.Log ("Confirmed");
	}
}
