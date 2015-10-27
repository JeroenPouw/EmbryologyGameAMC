﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MesoLists : MonoBehaviour {
	public static List<GameObject> Northlist = new List<GameObject>();
	public static List<GameObject> Eastlist = new List<GameObject>();
	public static List<GameObject> Westlist = new List<GameObject>();
	public static List<GameObject> Southlist = new List<GameObject>();
	public static List<GameObject> TileList = new List<GameObject> ();
	public static List<GameObject> PipeList = new List<GameObject> ();

	// -----For Debug Purposes -----
	public List<GameObject> listN = new List<GameObject>();
	public List<GameObject> listE = new List<GameObject>();
	public List<GameObject> listS = new List<GameObject>();
	public List<GameObject> listW = new List<GameObject>();

	// Use this for initialization
	void Start () {
		GameObject[] allList = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];
		for (int i = 0; i < allList.Length; i++) {
			if (allList[i].gameObject.tag.Contains("East")) {
				Eastlist.Add(allList[i]);
			}
			if (allList[i].gameObject.tag.Contains("West")) {
				Westlist.Add(allList[i]);
			}
			if (allList[i].gameObject.tag.Contains("North")) {
				Northlist.Add(allList[i]);
			}
			if (allList[i].gameObject.tag.Contains("South")) {
				Southlist.Add(allList[i]);
			}
			if (allList[i].gameObject.tag.Contains("Pipe")) {
				PipeList.Add(allList[i]);
			}
			if (allList[i].gameObject.name == "Tile") {
				TileList.Add(allList[i]);
			}
		}
		Eastlist.Add(GameObject.Find("EndPipe"));
		Southlist.Add(GameObject.Find("EndPipe"));
		Northlist.Add(GameObject.Find("EndPipe"));
		Westlist.Add(GameObject.Find("EndPipe"));
		Eastlist.Add(GameObject.Find("Organ"));
		Southlist.Add(GameObject.Find("Organ"));
		Northlist.Add(GameObject.Find("Organ"));
		Westlist.Add(GameObject.Find("Organ"));

		listN = Northlist;
		listE = Eastlist;
		listS = Southlist;
		listW = Westlist;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}