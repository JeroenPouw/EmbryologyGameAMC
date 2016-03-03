using UnityEngine;
using System.Collections;

public class CoelomMap : MonoBehaviour {

	public float tilewidth;
	public float tileheight;

	public Transform[] prefabs;
	public bool won = false;

	/*
	 * 0 = open space?
	 * 1 = player (only 1 spot on second row from above)
	 * 				(it will serve as the respawn point)
	 * 2 = goal spot
	 * 3 = blocking block
	 * 4 = completed player block
	 */
	private int[,] map = new int[,]
	{ 	{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
		{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
		{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
		{3,0,0,0,0,0,0,1,0,0,0,0,0,0,0,3},
		{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
		{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
		{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
		{3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
		{3,0,0,0,0,0,2,0,0,0,0,0,0,0,0,3},
		{3,0,0,0,0,2,2,2,0,0,0,0,0,0,0,3},
		{3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3}
	};

	private int goalblocks = 0;

	void Start () {
		CreateMap ();
	}

	void Update () {
		
	}

	void CreateMap(){
		Transform tile;
		Vector3 position;
		for (int i = map.GetLowerBound(1); i <= map.GetUpperBound(1); ++i) {
			for (int j = map.GetLowerBound(0); j <= map.GetUpperBound(0); ++j) {
				position = new Vector3 (i * tilewidth, -j * tileheight);
				switch (map [j, i]) {
				default:
					
					break;
				case 0:
					
					break;
				case 1:
					Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					break;
				case 2:
					Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					goalblocks++;
					break;
				case 3:
					Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					break;
				case 4:
					Instantiate (prefabs[map[j,i]], position, Quaternion.identity);
					break;
				}
			}
		}
	}

	public int CheckArea (int _x, int _y, int[] checks) {
		int count = 0;
		foreach (int check in checks) {
			if (map [_x - 1, _y] == check)
				count++;
			if (map [_x + 1, _y] == check)
				count++;
			if (map [_x, _y - 1] == check)
				count++;
			if (map [_x, _y + 1] == check)
				count++;
		}
		return count;
	}

	/* Directions
	 *  1
	 * 2x3
	 *  4
	 */

	public Vector3 MoveBlock (Transform block, int _direction) {
		Vector2 _coord = FloatCoToMapCo(block.position);
		switch (_direction) {
		case 1:
			_coord -= Vector2.up;
			break;
		case 2:
			_coord -= Vector2.right;
			break;
		case 3:
			_coord += Vector2.right;
			break;
		case 4:
			_coord += Vector2.up;
			break;
		}
		return MapCoToFloatCo ((int)_coord.x,(int)_coord.y);
	}

	public Vector3 MoveBlock (int _x, int _y)
	{
		return MapCoToFloatCo (_x, _y);
	}

	/*
	 * 
	 * 
	 * Win condition required here
	 * Lose condition required here
	 * 
	 * 
	 */
	public void PlayerToBlock (Transform _coordinates) {
		Vector2 _coord = FloatCoToMapCo (_coordinates.position);
		if (map[(int)_coord.y,(int)_coord.x] <= 2) {
			if (map[(int)_coord.y,(int)_coord.x] == 2) {
				goalblocks--;
				Instantiate (prefabs[4], MapCoToFloatCo((int)_coord.x,(int)_coord.y), Quaternion.identity);
				if (goalblocks <= 0) {
					Debug.Log("MISSION IS A SUCCESS!!!");
					won = true;
				}
			}
			map[(int)_coord.y,(int)_coord.x] = 4;
			Instantiate (prefabs[4], MapCoToFloatCo((int)_coord.x,(int)_coord.y), Quaternion.identity);
		} else if (map[(int)_coord.y,(int)_coord.x] == 4) {
			Debug.Log("MISSION IS A FAILURE!!!");
			won = true;
		}
	}

	public bool BlockingBlock (int _x, int _y) {
		if (map [_y, _x] == 3 || map [_y, _x] == 4) {
			return true;
		} else {
			return false;
		}
	}

	public int GetValueBLock (int _x, int _y) {
		return map [_y, _x];
	}

	public Vector3 MapCoToFloatCo (int _x, int _y) {
		Vector3 position = new Vector3 (_x * tilewidth, -_y * tileheight, 0f);
		return position;
	}

	public Vector2 FloatCoToMapCo(Vector3 _position) {
		int _x = Mathf.RoundToInt (_position.x/tilewidth);
		int _y = -Mathf.RoundToInt (_position.y/tileheight);
		Vector2 position = new Vector2 (_x,_y);
		return position;
	}
}
