using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuzzleInfoManager : MonoBehaviour {
	Text Info;
	TextAsset text;

	void Awake(){
		Info = gameObject.GetComponent<Text> ();
//		while (text == null) {
//
//		}

	}

	public void SpawnInfo(int piecenumber){
		Debug.Log ("this is.." + piecenumber);
		text = Resources.Load ("Story/Mission 1/Message1."+piecenumber) as TextAsset;

	}
	void Update(){
		Info.text = "" + text;
	}
}
