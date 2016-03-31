using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

	public Transform playerref;
	private Vector3 spawnpoint;
	private int currentpoint;
	private int loadedpoint;
	private string title;
	private string message;

	void Start () {
		loadedpoint = GameObject.Find("SaveState").GetComponent<SaveState>().loaded_data.lvl;
		foreach (QuestUpdate update in GetComponentsInChildren<QuestUpdate> ()) {
			if (update.orderlocation <= loadedpoint) {
				if (update.spawnpoint && update.orderlocation > currentpoint) {
					spawnpoint = update.transform.position;
					currentpoint = update.orderlocation;
					if (update.isstage8) {
						playerref.GetComponent<PlayerAttributeAdjustment> ().ChangeStage (8);
					} else {
						playerref.GetComponent<PlayerAttributeAdjustment> ().ChangeStage (10);
					}
				}
				update.gameObject.SetActive(false);
				this.title = update.title;
				this.message = update.message;
			}
		}
		if (spawnpoint != Vector3.zero) {
			playerref.position = spawnpoint;
		}
		GameObject.Find ("MissionDescription").GetComponent<Text> ().text = message;
		GameObject.Find ("MissionTitle").GetComponent<Text> ().text = title;
	}
}
