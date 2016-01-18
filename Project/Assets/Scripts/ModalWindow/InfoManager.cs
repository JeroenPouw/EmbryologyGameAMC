using UnityEngine;
using System.Collections;

public class InfoManager : MonoBehaviour {

	public TextAsset infoMessage;
	public static TextAsset s;
	public TextAsset questLog;
	public static TextAsset q;

	void Start()
	{
		q = Resources.Load ("Questlogs/Questlog1") as TextAsset;
	}
	void OnTriggerEnter(){
		s = infoMessage;
		q = questLog;
	}
}
