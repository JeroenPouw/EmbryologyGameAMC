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
		randomNumb = Random.Range (1, 4);
		for (int i = 0; i < wDrainObj.Length; i++) {
			wDrain[i] = wDrainObj[i].GetComponent<WaterDrain>();
			wDrain[i].RandomEventStart(randomNumb);
			//wDrain[i].ClearList();
		}
		yield return new WaitForSeconds (duration);
		for (int i = 0; i < wDrainObj.Length; i++) {
			if (wDrainObj[i] != null){
				wDrain[i] = wDrainObj[i].GetComponent<WaterDrain>();
				wDrain[i].RandomEventStart(randomNumb);
			}
		}
		StartCoroutine (randomWait (randomTimer));
	}
	// Update is called once per frame
	void Update () {

	}
}
