using UnityEngine;
using System.Collections;

public class NeuralTubeEnemy : MonoBehaviour {

	public float speed;

	public Vector3[] patrolroute;
	private uint patrolpoint = 0;

	private Vector3 destination = Vector3.zero;

	void Start () {
		
	}

	void Update () {
		Intelligence ();

		if ((destination-this.transform.position).magnitude < speed * Time.deltaTime)
		{
			this.transform.position = destination;
		}
		else
		{
			this.transform.Translate((destination-this.transform.position).normalized * speed * Time.deltaTime);
		}
	}

	void Intelligence () {

	}

	void Patrol () {
		if (patrolroute.Length > 0) {
			if (this.transform.position == destination) {
				patrolpoint++;
				if (patrolpoint == patrolroute.Length) {
					patrolpoint = 0;
				}
				destination = patrolroute[patrolpoint];
			}
		}
	}

	void RandomDestination () {
		if (this.transform.position == destination) {
	//		destination = this.transform.position + 
		}
	}


}
