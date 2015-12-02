using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class EncyTextReader : MonoBehaviour {

	private SaveState save;

	void Start () {
		GameObject go = GameObject.Find("SaveState");
		save = go.GetComponent<SaveState> ();

		GetSaveState ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GetSaveState () {
		Debug.Log(save.loaded_data.puztrack + " Got Save");
	}

	void ReadEncyData () {
		// Handle any problems that might arise when reading the text
		try
		{
			string line;
			// Create a new StreamReader, tell it which file to read and what encoding the file
			// was saved as
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);
			// Immediately clean up the reader after this block of code is done.
			// You generally use the "using" statement for potentially memory-intensive objects
			// instead of relying on garbage collection.
			// (Do not confuse this with the using directive for namespace at the 
			// beginning of a class!)
			using (theReader)
			{
				// While there's lines left in the text file, do this:
				do
				{
					line = theReader.ReadLine();
					
					if (line != null)
					{
						// Do whatever you need to do with the text line, it's a string now
						// In this example, I split it into arguments based on comma
						// deliniators, then send that array to DoStuff()
						string[] entries = line.Split(',');
						if (entries.Length > 0)
						{

						}
						//	DoStuff(entries);
					}
				}
				while (line != null);
				// Done reading, close the reader and return true to broadcast success    
				theReader.Close();
				return;
			}
		}
		// If anything broke in the try block, we throw an exception with information
		// on what didn't work
		catch (Exception e)
		{
			Debug.Log("{0}\n" + e.Message);
			return;
		}

		//see if docx can be read
	}

}
