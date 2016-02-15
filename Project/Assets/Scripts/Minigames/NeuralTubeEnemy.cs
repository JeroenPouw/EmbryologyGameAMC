using UnityEngine;
using System.Collections;

public class NeuralTubeEnemy : MonoBehaviour {

	public float speed;
	public Vector3[] patrolroute;
	private uint patrolpoint = 0;
	private ArrayList map;

	private Vector3 destination;
	private float tilewidth;
	private float tileheight;

	void Start () {

	}

	public void SetMap (ArrayList _map) {
		map = _map;
	}
	public void SetSizes (float _tilewidth, float _tileheight) {
		tilewidth = _tilewidth;
		tileheight = _tileheight;
	}
	public void SetDestination (Vector3 _destination) {
		destination = _destination;
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
		RandomDestination ();
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

	/*
	 * AvailableCount() can be used?
	 * use lower and upper bound to calculate the map size?
	 * use random to pick a point in the map rather a point away from current position?
	 */
	void RandomDestination () {

		if (this.transform.position == destination && map.Count > 0) {
			int randomtile = Random.Range(0, map.Count-1);
			Vector2 tile = (Vector2)map[randomtile];
			destination = new Vector3((tile.y * tileheight), -(tile.x * tilewidth),0f);
		}

	}


}
