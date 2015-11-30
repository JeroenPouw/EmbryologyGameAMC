using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestLogScript : MonoBehaviour {
	Text questLog;
	// Use this for initialization
	void Start () {
		questLog = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		// = Resources.Load ("MyTexts/Mesoderm") as Text;
	}
}
