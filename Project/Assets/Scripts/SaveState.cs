﻿using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SaveState : MonoBehaviour {

	public SaveData loaded_data;
	private System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

	void Start () {
		DontDestroyOnLoad(transform.gameObject);
		ReadFile ();
	}

	public void WriteFile() {
		var data = loaded_data;
		using (Stream filestream = File.Open("Embsave.dat", FileMode.OpenOrCreate)) {
			formatter.Serialize(filestream, data);
		}
	}

	public void ReadFile() {
		try
		{
			using (Stream filestream = File.Open("Embsave.dat", FileMode.Open)) {
				loaded_data = (SaveData) formatter.Deserialize(filestream);
			}
		}
		catch (FileNotFoundException _exc)
		{
			loaded_data = new SaveData{
				lvl = 0,
				puztrack = "1o2o3o4o5o6o7o8o9o10o11o12o13o14o15o",
				storytrigger = "0"
			};
			WriteFile();
		}
	}

	public void SaveVariable(int _missiontracker, int _puzzletracker, string _storytrigger)	{
		int _x = loaded_data.lvl;
		string _y = loaded_data.puztrack;
		string _s = loaded_data.storytrigger;
		if (_missiontracker != 0) {
			if (loaded_data.lvl < _missiontracker) _x = _missiontracker;
		} else //this prevents a double save for the reduction of 2 calcuations. Worth it?
		if (_puzzletracker != 0 && _puzzletracker <= 15) {
			if (loaded_data.puztrack.Contains (_puzzletracker.ToString () + "o")) {
				_y = loaded_data.puztrack.Replace (_puzzletracker.ToString () + "o", _puzzletracker.ToString () + "x");
			}
		} else
		if (_storytrigger != "") {
			_s = _storytrigger;
		}

		loaded_data = new SaveData{
			lvl = _x,
			puztrack = _y,
			storytrigger = _s
		};
		WriteFile (); //maybe decide to not put this here.
	}

	public void ResetFile () {
		loaded_data = new SaveData{
			lvl = 0,
			puztrack = "1o2o3o4o5o6o7o8o9o10o11o12o13o14o15o",
			storytrigger = "0"
		};
		WriteFile();
	}

	public void PuzzlePiecePlaced (int _piecenumber) {
		loaded_data = new SaveData{
			lvl = loaded_data.lvl,
			puztrack = loaded_data.puztrack.Replace (_piecenumber.ToString () + "x", _piecenumber.ToString () + "p"),
			storytrigger = loaded_data.storytrigger
		};
		WriteFile ();
	}

	public string GetPuzzleStatus(int _piecenumber) {
		int startindex = loaded_data.puztrack.IndexOf (_piecenumber.ToString ());
		if (loaded_data.puztrack.Substring(startindex,3).Contains("o")) return "o";
		if (loaded_data.puztrack.Substring(startindex,3).Contains("x")) return "x";
		if (loaded_data.puztrack.Substring(startindex,3).Contains("p")) return "p";
		return "nodata";
	}

	[Serializable]
	public struct SaveData //remember, structs can't change data, a change only copies the struct
	{
		public int lvl;
		public string puztrack;
		public string storytrigger;
	}
}

