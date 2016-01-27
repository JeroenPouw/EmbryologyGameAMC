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
	 * 3 = mapborder  block	(used for map borders)
	 * 4 = unpassable block	(used to hinder the player)
	 * 5 = enemy			(the player has to avoid these)
	 * 
	 * The below are for during the play session
	 * 6 = claimed (broken)	(which so far the player is claiming in a chain)
	 * 7 = owned (broken)	(which the player has successfully chained to become owned)
	 */
	private int[,] map = new int[,]
	{ 	{3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3}, 
		{3,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,3},
		{3,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,3},
		{3,0,0,0,0,0,2,4,1,0,0,0,0,5,0,0,3},
		{3,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,3},
		{3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3},
		{0,0,0,0,0,3,0,0,0,0,3,0,0,0,3,0,0}
	};

	private Transform[,] tilemap;
	private ArrayList enemies;

	/*
	 * count up how many 0 tiles are there.
	 * Then during gameplay count it down for those claimed
	 * when 0, game complete
	 */
	private int freetilecount = 0;

	void Start () {
		tilemap = new Transform[map.GetUpperBound (0)+1, map.GetUpperBound (1)+1];
		enemies = new ArrayList ();
		CreateMap ();
	}

	void Update () {
		TrackClaim (prefabs[1]);
		TrackClaim (prefabs[2]);
	
		foreach (Transform enemy in enemies) {
			TrackEnemy(enemy.position);
		}
	}

	void TrackEnemy (Vector3 _position) {
		int _x = Mathf.RoundToInt (_position.x/tilewidth);
		int _y = -Mathf.RoundToInt (_position.y/tileheight);
		
		if (map[_y,_x] == 6) {
			if (prefabs[1].GetComponent<NeuralTubePlayer>().path.Contains(new Vector2(_y,_x))) {
				UnClaim(prefabs[1].GetComponent<NeuralTubePlayer>());
			} else 
			if (prefabs[2].GetComponent<NeuralTubePlayer>().path.Contains(new Vector2(_y,_x))) {
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

		int count = 0;
		for (int i = map.GetLowerBound(1); i <= map.GetUpperBound(1); ++i) {
			for (int j = map.GetLowerBound(0); j <= map.GetUpperBound(0); ++j) {
				if (map [j, i] == 0) {
					count++;
				}
			}
		}
		if (count == 0) {
			Debug.Log("WIN!");
		}
	}

	/*
	 * When an enemy runs into a player's claim path, 
	 * the content of the path should be removed
	 */
	void UnClaim (NeuralTubePlayer _player) {
		foreach(Vector2 data in _player.path)
		{
			map[(int)data.x,(int)data.y] = 0;
			tilemap[(int)data.x,(int)data.y].GetComponent<NeuralTubeAreaClaim> ().Lose();
		}
		_player.path.Clear ();
		_player.tracking = false;
	}

	/*
	 * A quick check to discover the values in the grid position directly
	 * adjecunt to the given position. Hard coded to check on the values
	 * 3 and 7
	 */
	int CheckArea (int _x, int _y) {
		int count = 0;
		if (map [_x - 1, _y] == 3 || map [_x - 1, _y] == 7|| map [_x - 1, _y] == 4)
			count++;
		if (map [_x + 1, _y] == 3 || map [_x + 1, _y] == 7|| map [_x + 1, _y] == 4)
			count++;
		if (map [_x, _y - 1] == 3 || map [_x, _y - 1] == 7|| map [_x, _y - 1] == 4)
			count++;
		if (map [_x, _y + 1] == 3 || map [_x, _y + 1] == 7|| map [_x, _y + 1] == 4)
			count++;
		return count;
	}

	void CreateMap(){
		Transform tile;
		Vector3 position;
		for (int i = map.GetLowerBound(1); i <= map.GetUpperBound(1); ++i) {
			for (int j = map.GetLowerBound(0); j <= map.GetUpperBound(0); ++j) {
				position = new Vector3(i*tilewidth,-j*tileheight);
				switch (map[j,i]) {
				default:

					break;
				case 0:
					tile = (Transform)Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					tilemap[j,i] = (Transform)tile;
					freetilecount++;
					break;
				case 1:
					prefabs[1].transform.position = position;
					map[j,i] = 0;
					tile = (Transform)Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					tilemap[j,i] = tile;
					break;
				case 2:
					prefabs[2].transform.position = position;
					map[j,i] = 0;
					tile = (Transform)Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					tilemap[j,i] = tile;
					break;
				case 3:
					tile = (Transform)Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					break;
				case 4:
					tile = (Transform)Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					break;
				case 5:
					tile = (Transform)Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					enemies.Add(tile);
					tile.GetComponent<NeuralTubeEnemy> ().SetDestination(position);
					map[j,i] = 0;
					tile = (Transform)Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					tilemap[j,i] = tile;
					break;
				case 6:
					tile = (Transform)Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					tilemap[j,i] = tile;
					tile.GetComponent<NeuralTubeAreaClaim> ().Claim();
					break;
				case 7:
					tile = (Transform)Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					tilemap[j,i] = tile;
					tile.GetComponent<NeuralTubeAreaClaim> ().Own();
					break;
				}
			}
		}
		foreach (Transform enemy in enemies) {
			enemy.GetComponent<NeuralTubeEnemy> ().SetMap (AvailableCount (
			new Vector2 (-enemy.position.y / tilewidth, enemy.position.x / tilewidth), 
				Vector2.up));
			enemy.GetComponent<NeuralTubeEnemy> ().SetSizes(tilewidth, tileheight);
		}
	}

	/*
	 * 
	 * 
	 */
	public ArrayList AvailableCount (Vector2 _start, Vector2 _direction) {
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

	public int GetUpperbound(int _layer){
		return map.GetUpperBound (_layer);
	}

	public int GetLowerbound(int _layer){
		return map.GetLowerBound (_layer);
	}
}


