using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestLogScript : MonoBehaviour {
	Text questLog;
	TextAsset text;
	// Use this for initialization
	void Start () {
		questLog = gameObject.GetComponent<Text> ();
		text = Resources.Load ("MyTexts/QuestLog") as TextAsset;
	}
	
	// Update is called once per frame
	void Update () {
		questLog.text = "" + text;
	}
}
