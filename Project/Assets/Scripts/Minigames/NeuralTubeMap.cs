using UnityEngine;
using System.Collections;

public class NeuralTubeMap : MonoBehaviour {

	public float tilewidth;
	public float tileheight;

	public Transform[] prefabs;

	/*
	 * The map array:
	 * 0 = empty			(area which needs to be claimed/owned to win)
	 * 1 = player1			(the non mirrored player)
	 * 2 = player2			(the mirrored player)
	 * 3 = unpassable block	(used for map borders)
	 * 4 = enemy			(the player has to avoid these)
	 * 5 = trigger			(unknown purpose)
	 * 
	 * The below are for during the play session
	 * 6 = claimed			(which so far the player is claiming in a chain)
	 * 7 = owned			(which the player has successfully chained to become owned)
	 */
	private int[,] map = new int[,]
	{ 	{ 3, 3, 3, 3, 3, 3}, 
		{ 3, 0, 0, 0, 0, 0},
		{ 3, 0, 1, 0, 0, 3},
		{ 3, 0, 0, 2, 3, 0},
		{ 3, 3, 3, 3, 0, 3}	
	};
	
	void Start () {
		CreateMap ();

	}

	void Update () {
		TrackClaim (prefabs[1].position, prefabs[1].GetComponent<NeuralTubePlayer>());
		TrackClaim (prefabs[2].position, prefabs[2].GetComponent<NeuralTubePlayer>());
	}

	void TrackEnemy (Vector3 _position) {
		int _x = Mathf.FloorToInt (_position.x/tilewidth);
		int _y = -Mathf.FloorToInt (_position.y/tileheight);

		//debug only
		if (_x > map.GetLowerBound (0) && _x < map.GetUpperBound (0)
		&& _y > map.GetLowerBound (1) && _y < map.GetUpperBound (1)) {

			if (map[_x,_y] == 6) {
				if (prefabs[1].GetComponent<NeuralTubePlayer>().path.Contains(new Vector2(_x,_y))) {
					UnClaim(prefabs[1].GetComponent<NeuralTubePlayer>());
				} else 
				if (prefabs[2].GetComponent<NeuralTubePlayer>().path.Contains(new Vector2(_x,_y))) {
					UnClaim(prefabs[2].GetComponent<NeuralTubePlayer>());
				}
			}
		}
	}

	/*
	 * Tracks where the players go to then draw a line of claimed tiles
	 * the line is being tracked by start and end position
	 * when the end is determined all claimed will be send over to Claimed()
	 */
	void TrackClaim (Vector3 _position, NeuralTubePlayer _player) {
		int _x = Mathf.FloorToInt (_position.x/tilewidth);
		int _y = -Mathf.FloorToInt (_position.y/tileheight);

		//debug only
		if (_x > map.GetLowerBound (0) && _x < map.GetUpperBound (0)
		&& 	_y > map.GetLowerBound (1) && _y < map.GetUpperBound (1)) {

			if (map[_x,_y] == 0) {
				if (_player.tracking)
				{
					map[_x,_y] = 6;
					_player.path.Add(new Vector2(_x,_y));
					if (CheckArea(_x, _y) == 1)
					{
						map[_x,_y] = 6;
						_player.path.Add(new Vector2(_x,_y));
						Claimed (_player);
						_player.tracking = false;
					}
				} else {
					if (CheckArea(_x, _y) > 1)
					{
						map[_x,_y] = 6;
						_player.path.Add(new Vector2(_x,_y));
						_player.tracking = true;
					}
				}
			}
		}
	}

	/*
	 * Make a box between the start and end position
	 * determine which side needs to be filled, if there are inconsistencies
	 * fill box by going row for row with owned tiles
	 * set tracking bool to false
	 * 
	 * 1	2	3
	 * 4		6
	 * 7	8	9
	 */
	void Claimed (NeuralTubePlayer _player) {
		Debug.Log ("claiming");
		Vector2 start;
		Vector2 end;

		foreach(Vector2 data in _player.path)
		{
			Debug.Log(data);
			map[Mathf.RoundToInt(data.x),Mathf.RoundToInt(data.y)] = 7;
		}
		_player.path.Clear ();
	}

	void UnClaim (NeuralTubePlayer _player) {
		foreach(Vector2 data in _player.path)
		{
			map[Mathf.RoundToInt(data.x),Mathf.RoundToInt(data.y)] = 0;
		}
		_player.path.Clear ();
	}

	/*
	 * A quick check to discover the values in the grid position directly
	 * adjecunt to the given position. Hard coded to check on the values
	 * 3 and 7
	 */
	int CheckArea (int _x, int _y) {
		int count = 0;
		if (map [_x - 1, _y] == 3 || map [_x - 1, _y] == 7)
			count++;
		if (map [_x + 1, _y] == 3 || map [_x + 1, _y] == 7)
			count++;
		if (map [_x, _y - 1] == 3 || map [_x, _y - 1] == 7)
			count++;
		if (map [_x, _y + 1] == 3 || map [_x, _y + 1] == 7)
			count++;
		return count;
	}

	void CreateMap(){
		Object tile;
		Vector3 position;
		for (int i = map.GetLowerBound(1); i <= map.GetUpperBound(1); ++i) {
			for (int j = map.GetLowerBound(0); j <= map.GetUpperBound(0); ++j) {
				position = new Vector3(i*tilewidth,-j*tileheight);
				switch (map[j,i]) {
				default:

					break;
				case 0:
					tile = Instantiate (prefabs[map[j,i]], position, Quaternion.identity);

					break;
				case 1:
					prefabs[1].transform.position = position;
					break;
				case 2:
					prefabs[2].transform.position = position;
					break;
				case 3:
					tile = Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					break;
				case 4:
					tile = Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					break;
				case 5:
					tile = Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					break;
				case 6:

					break;
				case 7:
					tile = Instantiate (prefabs[map[j,i]], position, Quaternion.identity);

					break;
				}
			}
		}
	}
}


