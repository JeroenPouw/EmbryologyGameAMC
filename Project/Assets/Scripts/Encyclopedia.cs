using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Encyclopedia : MonoBehaviour {

	public Text title;
	public Text description;

	public void ChangeText (int _infonumber) {
		switch (_infonumber) {
		default:
			title.text = "Welcome to the Encyclopedia";
			description.text = "Here you can find all the information you have acquired thus far.";
			break;

		}
	}
	public void Test () {

	}
}
