﻿// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class ObjectSnapScript : MonoBehaviour {
	
	
	public string partnerName= "Tile";
	float closeVPDist= 0.5f;
	float moveSpeed= 40.0f;
	float rotateSpeed= 90.0f;

	
	private float dist= Mathf.Infinity;
	//private Color normalColor;
	public GameObject partnerGO;
	
	void  Start (){
		//normalColor = GameObject.;
		partnerGO = GameObject.Find(partnerName);
	}
	
	void  OnMouseDrag (){
		Vector3 partnerPos= partnerGO.transform.position;
		Vector3 myPos= transform.position;
		dist = Vector2.Distance(partnerPos, myPos);
		//renderer.material.color = (dist < closeVPDist) ? closeColor : normalColor;
	}
	
	void  OnMouseUp (){
		Debug.Log("Me:"+ transform.position);
		Debug.Log("Partner"+ partnerGO.transform.position);
		if (dist < closeVPDist) {
			transform.position = partnerGO.transform.position;
			Debug.Log("Tilezz");
			StartCoroutine( InstallPart());
		}
	}
	
	IEnumerator  InstallPart (){
		while (transform.localPosition != Vector3.zero || transform.localRotation != Quaternion.identity) {
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, Time.deltaTime * moveSpeed);
			transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.identity, Time.deltaTime * rotateSpeed);
			yield return 2;
		}
	}
}
