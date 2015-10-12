using UnityEngine;
using System.Collections;

public class RandomDrainEvent : MonoBehaviour {
	public GameObject[] wDrainObj = new GameObject[2796];
	WaterDrain[] wDrain = new WaterDrain[2796] ;
	float randomTimer;
	int randomNumb;
	// Use this for initialization
	void Start () {
		randomTimer = Random.Range (5f,6f);
		wDrainObj = GameObject.FindGameObjectsWithTag ("water");

		StartCoroutine (randomWait (randomTimer));
	}

	IEnumerator randomWait(float timer){
		yield return new WaitForSeconds(timer);
		float duration = 5.0f;
		randomNumb = Random.Range (1, 4); // choose a number which corresponds with either the Ectoderm, Mesoderm or Endoderm in Waterdrain.cs
		for (int i = 0; i < wDrainObj.Length; i++) {
			wDrain[i] = wDrainObj[i].GetComponent<WaterDrain>();
			wDrain[i].RandomEventStart(randomNumb);
			//wDrain[i].ClearList();
		}
		yield return new WaitForSeconds (duration);
		for (int i = 0; i < wDrainObj.Length; i++) { // Go back to normal drain speed.
			if (wDrainObj[i] != null){
				wDrain[i] = wDrainObj[i].GetComponent<WaterDrain>();
				wDrain[i].RandomEventStart(randomNumb);
			}
		}
		StartCoroutine (randomWait (randomTimer)); // let randomWait repeat itself.
	}
	// Update is called once per frame
	void Update () {

	}
}
