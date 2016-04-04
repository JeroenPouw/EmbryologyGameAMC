using UnityEngine;
using System.Collections;

public class TriggerLevelLoader : MonoBehaviour {

	public int levelinteger;

	void OntriggerEnter (Collider _other) {
		if (_other.name == "Player") {
			Application.LoadLevel(levelinteger);
			System.Console.WriteLine("Collision with LevelLoader");
		}
	}
}
