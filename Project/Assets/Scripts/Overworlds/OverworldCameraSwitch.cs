using UnityEngine;
using System.Collections;

public class OverworldCameraSwitch : MonoBehaviour {

	public OverworldUI uiref;

	public Camera playercam;
	public Camera outercam;

	void Update () {
		if (Input.GetKeyDown(KeyCode.M)) {
			SwitchCameras();
		}
	}

	void SwitchCameras() {
		outercam.GetComponent<StageCenterCamera> ().ChangeStage (this.GetComponent<PlayerAttributeAdjustment> ().Stage);
		uiref.gameObject.SetActive (!uiref.gameObject.activeSelf);
		playercam.gameObject.SetActive (!playercam.gameObject.activeSelf);
		outercam.gameObject.SetActive (!outercam.gameObject.activeSelf);
	}

	public void ButtonSwitch () {
		SwitchCameras();
	}
}
