using UnityEngine;
using System.Collections;
/*
 * This Class handles the random drain event for the Yolk Sac Minigame. At random intervals, this class sends a message to the WaterDrain Class, to start
 * draining at a higher rate. After a certain time a new message is sent letting the WaterDrain Class know the event has ended.
 * This class then waits before restarting the drain event.
 */
public class RandomDrainEvent : MonoBehaviour {
	public GameObject[] wDrainObj = new GameObject[2796]; // An array that holds space for all the water objects in the Unity Scene.
	WaterDrain[] wDrain = new WaterDrain[2796]; // This array is used to call the functions on the water objects from WDrainObj.

	float randomTimer; // This timer represents the time inbetween random events.
	int randomNumb; // This number represents the different functions in the WaterDrain Class.

	void Start () {
		randomTimer = Random.Range (5f,6f);
		// Find all the water objects.
		wDrainObj = GameObject.FindGameObjectsWithTag ("water");
		StartCoroutine (randomWait (randomTimer));
	}
	/*
	 * This function waits before starting. It then assigns the duration of the random event and which object to affect in WaterDrain.
	 * Next wDrain collects all the water objects from wDrainObj and start the random event for the chosen randomNumb.
	 * Next this function waits for the duration of the event, before calling the RandomEventStart again, which signals to WaterDrain,
	 * to stop the event. 
	 * Finally, the function repeats itself.
	 */
	IEnumerator randomWait(float timer){
		yield return new WaitForSeconds(timer);
		float duration = 5.0f;
		randomNumb = Random.Range (1, 4); 
		for (int i = 0; i < wDrainObj.Length; i++) {
			wDrain[i] = wDrainObj[i].GetComponent<WaterDrain>();
			wDrain[i].RandomEventStart(randomNumb);

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

	void Update () {

	}
}
