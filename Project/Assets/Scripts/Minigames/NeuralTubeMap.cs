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
	{ 	{ 3, 3, 3, 3, 3, 3,3,3,3,3,3,3,3,3,3,3,3}, 
		{ 3, 0, 0, 0, 0, 0,0,3,0,0,0,0,0,0,0,0,3},
		{ 3, 0, 0, 0, 0, 0,0,3,0,0,0,0,0,0,0,0,3},
		{ 3, 0, 0, 0, 0, 0,2,3,1,0,0,0,0,0,0,0,3},
		{ 3, 0, 0, 0, 0, 0,0,3,0,0,0,0,0,0,0,0,3},
		{ 3, 3, 3, 3, 3, 3,3,3,3,3,3,3,3,3,3,3,3}
	};

	private Transform[,] tilemap;

	void Start () {
		tilemap = new Transform[map.GetUpperBound (0)+1, map.GetUpperBound (1)+1];
		CreateMap ();
	}

	void Update () {
		TrackClaim (prefabs[1]);
		TrackClaim (prefabs[2]);
	}

	void TrackEnemy (Vector3 _position) {
		int _x = Mathf.FloorToInt (_position.x/tilewidth);
		int _y = -Mathf.FloorToInt (_position.y/tileheight);
		
		if (map[_x,_y] == 6) {
			if (prefabs[1].GetComponent<NeuralTubePlayer>().path.Contains(new Vector2(_x,_y))) {
				UnClaim(prefabs[1].GetComponent<NeuralTubePlayer>());
			} else 
			if (prefabs[2].GetComponent<NeuralTubePlayer>().path.Contains(new Vector2(_x,_y))) {
				UnClaim(prefabs[2].GetComponent<NeuralTubePlayer>());
			}
		}
	}

	/*
	 * Tracks where the players go to then draw a line of claimed tiles
	 * the line is being tracked by start and end position
	 * when the end is determined all claimed will be send over to Claimed()
	 */
	void TrackClaim (Transform _player) {
		int _x = Mathf.RoundToInt (_player.position.x/tilewidth);
		int _y = -Mathf.RoundToInt (_player.position.y/tileheight);
	
		NeuralTubePlayer player = _player.GetComponent<NeuralTubePlayer> ();
		if (map[_y,_x] == 0) {
			if (player.tracking)
			{
				map[_y,_x] = 6;
				player.path.Add(new Vector2(_y,_x));
				tilemap[_y,_x].GetComponent<NeuralTubeAreaClaim> ().Claim();
				if (CheckArea(_y,_x) > 0)
				{
					Claimed (player);
					player.tracking = false;
				}
			} else {
				if (CheckArea(_y,_x) > 0)
				{
					map[_y,_x] = 6;
					player.path.Add(new Vector2(_y,_x));
					tilemap[_y,_x].GetComponent<NeuralTubeAreaClaim> ().Claim();
					player.tracking = true;
				}
			}
		}
	}

	/*
	 *  
	 * 
	 * 1	2	3
	 * 4		6
	 * 7	8	9
	 */
	void Claimed (NeuralTubePlayer _player) {
		Vector2 start = (Vector2)_player.path [0];
		Vector2 end = (Vector2)_player.path [_player.path.Count-1];

		if (map [(int)start.x, (int)start.y-1] == 0 && map [(int)start.x, (int)start.y+1] == 0) {
			ArrayList down = AvailableCount(new Vector2(start.x, start.y-1), new Vector2(0,-1));
			ArrayList top = AvailableCount(new Vector2(start.x, start.y+1), new Vector2(0,1));
			if (down.Count < top.Count) {
				foreach (Vector2 data in down) {
					map[(int)data.x,(int)data.y] = 7;
					tilemap[(int)data.x, (int)data.y].GetComponent<NeuralTubeAreaClaim> ().Own();
				}
			}
			else {
				foreach (Vector2 data in top) {
					map[(int)data.x,(int)data.y] = 7;
					tilemap[(int)data.x, (int)data.y].GetComponent<NeuralTubeAreaClaim> ().Own();
				}
			}
		} else
		if (map [(int)start.x-1, (int)start.y] == 0 && map [(int)start.x+1, (int)start.y] == 0) {
			ArrayList left = AvailableCount(new Vector2(start.x-1, start.y), new Vector2(-1,0));
			ArrayList right = AvailableCount(new Vector2(start.x+1, start.y), new Vector2(1,0));
			if (right.Count < left.Count) {
				foreach (Vector2 data in right) {
					map[(int)data.x,(int)data.y] = 7;
					tilemap[(int)data.x, (int)data.y].GetComponent<NeuralTubeAreaClaim> ().Own();
				}
			}
			else {
				foreach (Vector2 data in left) {
					map[(int)data.x,(int)data.y] = 7;
					tilemap[(int)data.x, (int)data.y].GetComponent<NeuralTubeAreaClaim> ().Own();
				}
			}
		}

		foreach(Vector2 data in _player.path)
		{
			map[(int)data.x,(int)data.y] = 7;
			tilemap[(int)data.x, (int)data.y].GetComponent<NeuralTubeAreaClaim> ().Own();
		}
		_player.path.Clear ();
	}

	/*
	 * When an enemy runs into a player's claim path, 
	 * the content of the path should be removed
	 */
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
					tilemap[j,i] = (Transform)tile;
					break;
				case 1:
					prefabs[1].transform.position = position;
					map[j,i] = 0;
					tile = Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					tilemap[j,i] = (Transform)tile;
					break;
				case 2:
					prefabs[2].transform.position = position;
					map[j,i] = 0;
					tile = Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					tilemap[j,i] = (Transform)tile;
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
					tilemap[j,i] = (Transform)tile;
					break;
				}
			}
		}
	}

	/*
	 * 
	 * 
	 */
	private ArrayList AvailableCount (Vector2 _start, Vector2 _direction) {
		ArrayList toclaim = new ArrayList ();
		ArrayList jumppoint = new ArrayList ();
		Vector2[] cardir = new Vector2[4];
		cardir [0] = Vector2.up;
		cardir [1] = -Vector2.up;
		cardir [2] = Vector2.right;
		cardir [3] = -Vector2.right;
		Vector2 currentpoint = _start;
		Vector2 checkpoint;

		while (true) {
			toclaim.Add (currentpoint);

			for (int i = 0; i < cardir.Length; i++) {
				if (_direction != cardir[i]) {
				    if (map [(int)(currentpoint.x + cardir[i].x), (int)(currentpoint.y + cardir[i].y)] == 0) {
						checkpoint = (currentpoint + cardir[i]);
						if (!toclaim.Contains(checkpoint) && !jumppoint.Contains(checkpoint)) {
							jumppoint.Add(checkpoint);
						}
					}
				}
			}

			if (map [(int)(currentpoint.x + _direction.x), (int)(currentpoint.y + _direction.y)] != 0) {
				if (jumppoint.Count > 0) {
					currentpoint = (Vector2)jumppoint [0];
					jumppoint.RemoveAt (0);
				} else {
					return toclaim;
				}
			} else {
				currentpoint += _direction;
			}
		}

		return toclaim;
	}
}


