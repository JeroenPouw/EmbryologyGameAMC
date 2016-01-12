using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {
	GameObject targetPlayer;
	float moveSpeed = 5000f;
	bool isMoving;
	// Use this for initialization
	void Awake () {

	}

	void LookatTarget(GameObject target){
		this.gameObject.transform.LookAt (target.transform);
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, moveSpeed * Time.deltaTime);

		if (Vector3.Distance(transform.position, target.transform.position)< 300) {
			isMoving = false;
		}
	}
	// Update is called once per frame
	void Update () {
		if (targetPlayer == null) {
			targetPlayer = GameObject.Find ("Player(Clone)");
		}
		if (Input.GetKeyDown(KeyCode.F)) {
			//LookatTarget();
			if (isMoving == true) {
				isMoving = false;
			}
			else
			{
				isMoving = true;
			}
		}
		if (isMoving) {
			LookatTarget(targetPlayer);
		}
	}
}
