using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CutoutStageFilter : MonoBehaviour {

	private Button[] buttons;

	void Start () {
		buttons = GetComponentsInChildren<Button> ();
		ToggleStage8 ();
	}

//	public void ToggleStage () {
//		foreach (Button button in buttons) {
//			button.gameObject.SetActive(!button.gameObject.activeSelf);
//		}
//	}
	public void ToggleStage8 () {
		foreach (Button button in buttons) {
			if (button.gameObject.name.StartsWith("Stage8")) {
				button.gameObject.SetActive(!button.gameObject.activeSelf);
			}
		}
	}

	public void ToggleStage10 () {
		foreach (Button button in buttons) {
			if (button.gameObject.name.StartsWith("Stage10")) {
				button.gameObject.SetActive(!button.gameObject.activeSelf);
			}
		}
	}
}
