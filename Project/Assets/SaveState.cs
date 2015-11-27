using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class SaveState : MonoBehaviour {
	
	private SaveData loaded_data;
	private System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter ();

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
		loaded_data.mistrack = "1o2o3o4o5o6o";
		loaded_data.puztrack = "1o2o3o4o5o6o7o8o9o10o11o12o13o14o15o";
		ReadFile ();
	}
	
	void WriteFile() {
		var data = loaded_data;
		using (Stream filestream = File.Open("Embsave.dat", FileMode.OpenOrCreate)) {
			formatter.Serialize(filestream, data);
		}
	}

	void ReadFile() {
		try
		{
			using (Stream filestream = File.Open("Embsave.dat", FileMode.Open)) {
				loaded_data = (SaveData) formatter.Deserialize(filestream);
			}
		}
		catch (FileNotFoundException _exc)
		{
			WriteFile();
		}
	}

	void SaveVariable()	{


	}


	[Serializable]
	struct SaveData //remember, structs can't change data
	{
		public string mistrack;
		public string puztrack;
	}
	
}


