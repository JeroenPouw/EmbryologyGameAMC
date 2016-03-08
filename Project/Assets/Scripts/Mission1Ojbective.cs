using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class Mission1Ojbective : MonoBehaviour {
	private ModalWindow modalWindow;
	private UnityAction myconfirmAction;

	TextAsset startMessage;
	TextAsset objective1Message;
	TextAsset objective2Message;
	TextAsset objective3Message;
	TextAsset objective4Message;
	TextAsset objective5Message;
	TextAsset objective6Message;

	TextAsset startLog;
	TextAsset objective1Log;
	TextAsset objective2Log;
	TextAsset objective3Log;
	TextAsset objective4Log;
	TextAsset objective5Log;
	TextAsset objective6Log;


	string currentObjective;
	bool objective1;
	bool objective2;
	bool objective3;
	bool objective4;
	bool objective5;
	bool objective6;
	bool a;
	bool w;
	bool s;
	bool d;
	bool map;
	bool mapclose;

	// Use this for initialization
	void Start () {
		modalWindow = ModalWindow.Instance ();

		myconfirmAction = new UnityAction (ConfirmAction);

		startMessage = Resources.Load ("Story/Mission 1/Message1.1") as TextAsset;
		startLog = Resources.Load ("QuestLogs/StartLog") as TextAsset;
		objective1Message = Resources.Load ("Story/Mission 1/Message1.2") as TextAsset;
		objective1Log = Resources.Load ("QuestLogs/QuestLog1") as TextAsset;
		objective2Message = Resources.Load ("Story/Mission 1/Message1.3") as TextAsset;
		objective2Log = Resources.Load ("QuestLogs/QuestLog2") as TextAsset;
		objective3Message = Resources.Load ("Story/Mission 1/Message1.4") as TextAsset;
		objective3Log = Resources.Load ("QuestLogs/QuestLog3") as TextAsset;
		objective4Message = Resources.Load ("Story/Mission 1/Message1.5") as TextAsset;
		objective4Log = Resources.Load ("QuestLogs/QuestLog4") as TextAsset;
		objective5Message = Resources.Load ("Story/Mission 1/Message1.6") as TextAsset;
		objective5Log = Resources.Load ("QuestLogs/QuestLog5") as TextAsset;
		objective6Message = Resources.Load ("Story/Mission 1/Message1.7") as TextAsset;
		objective6Log = Resources.Load ("QuestLogs/QuestLog6") as TextAsset;


		modalWindow.Confirm(startMessage.text,"Mission Update: ", myconfirmAction);
		InfoManager.q = startLog;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Battery" && objective2 == false) {
			StartCoroutine(Wait(1));
			//Objective2();

		}
	}
	
	void Objective1(){
		if (objective1!=true) {
			modalWindow.Confirm (objective1Message.text, "Mission Update: ", myconfirmAction);
			InfoManager.q = objective1Log;
		}
	}

	void Objective2(){
		modalWindow.Confirm (objective2Message.text, "Mission Update: ", myconfirmAction);
		InfoManager.q = objective2Log;
		objective2 = true;
	}

	void Objective3(){
		modalWindow.Confirm(objective3Message.text,"Mission Update: ", myconfirmAction);
		InfoManager.q = objective3Log;
	}

	void Objective4(){
		modalWindow.Confirm(objective4Message.text,"Mission Update: ", myconfirmAction);
		InfoManager.q = objective4Log;
		StartCoroutine (Wait (30));
		Debug.Log ("Mission 4");

	}

	void Objective5(){
		Debug.Log ("Mission 5");
		modalWindow.Confirm(objective5Message.text,"Mission Update: ", myconfirmAction);
		InfoManager.q = objective5Log;
	}

	void Objective6(){
		modalWindow = ModalWindow.Instance();
		modalWindow.Confirm(objective6Message.text,"Mission Update: ", myconfirmAction);
		InfoManager.q = objective6Log;
	}

	IEnumerator Wait(int seconds){
		yield return new WaitForSeconds (seconds);
		if (objective2 == false) {
			Objective2();
			objective2 = true;
		}else Objective5 ();
	}
	void ConfirmAction(){
	
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A)) {
			a = true;
		}
		if (Input.GetKey(KeyCode.W)) {
			w = true;
		}
		if (Input.GetKey(KeyCode.S)) {
			s = true;
		}
		if (Input.GetKey(KeyCode.D)) {
			d = true;
		}
		if (a == true && d == true && w == true && s == true && objective1 == false) {
			Objective1();
			objective1 = true;
		}
		if (CameraSwitch.firsttime == true && map == false) {
			Objective3();
			map = true;
		}
		if (Input.GetKey(KeyCode.M) && CameraSwitch.firstclose == true && mapclose == false) {
			Objective4 ();
			mapclose = true;
		}
		if (Application.loadedLevel == 3 && currentDermTracker.currentDerm == 4 && Input.GetKeyDown(KeyCode.W) && objective6 != true) {
			Objective6();
			objective6 = true;
		}
	}
}
