using UnityEngine;
using System.Collections;

public class CoelomPlayer : MonoBehaviour {

	public float timetildrop;
	public float buttondelay;
	public Transform[] blocks;

	/*
	 * 0 uninitialized
	 * (1)	 	(2)		(3)		(4)	   (5)		(6)		(7)
	 * 1	 |	1	  |	1	  |	1 4	|	1	|	  1 |	1
	 * 2 3	 |	2	  |	2	  |	2 3	|	2	|	3 2	|	2 4		(1)
	 *   4	 |	3	  |	3 4	  |		| 4 3	|	4	|	3
	 * 		 |	4	  |		  |		|		|		|
	 *~~~~~~~|~~~~~~~~|~~~~~~~|~~~~~|~~~~~~~|~~~~~~~|~~~~~~~~
	 *   2 1 |4 3 2 1 |	3 2 1 | 1 4 | 4		| 4 3	| 3 2 1
	 * 4 3	 |		  | 4	  |	2 3 | 3 2 1 |   2 1	|   4		(2)
	 *~~~~~~~|~~~~~~~~|~~~~~~~|~~~~~|~~~~~~~|~~~~~~~|~~~~~~~~
	 * 		 |	4	  | 	  |		|		|   	|
	 * 4	 |	3	  |4 3	  | 1 4 |   3 4	|   4	|	3
	 * 3 2   |	2	  |  2	  | 2 3 |   2	| 2 3	| 4 2		(3)
	 *   1   |	1	  |  1	  |		|   1	| 1		|	1
	 *~~~~~~~|~~~~~~~~|~~~~~~~|~~~~~|~~~~~~~|~~~~~~~|~~~~~~~~
	 * 1 2	 |		  |     4 | 1 4 |       | 1 2	|	4
	 *   3 4 |1 2 3 4 | 1 2 3 | 2 3 | 1 2 3 |   3 4 | 1 2 3		(4)
	 * 		 |		  |		  |		|	  4 |		|
	 * 		 |		  |		  |		|		|		|
	 */
	private int status = 0;
	private float buttondelaytracker;
	private float timetracker;
	private CoelomMap mapref;
	private Vector3 startposition;

	void Start () {
		mapref = GameObject.Find ("CoelomMap").GetComponent<CoelomMap> ();
		startposition = this.transform.position;
		ReInstantiate ();
	}

	void Update () {
		timetracker += Time.deltaTime;
		buttondelaytracker += Time.deltaTime;
		if (timetracker > timetildrop) {
			timetracker = 0f;
			MoveDown();
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			MoveRight();
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			MoveLeft();
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			MoveDown();
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			if (buttondelaytracker > buttondelay) {
				Clockwise();
				buttondelaytracker = 0f;
			}
		}
	}

	public void ReInstantiate () {
		status = Mathf.RoundToInt(Random.Range (1, 7));
		Debug.Log (status);
		switch (status) {
		default:
			Debug.Log("Failure to comply, buggy code is in order");
			break;
		case 1:
			blocks[0].transform.localPosition = (Vector3.up*mapref.tileheight);
			blocks[2].transform.localPosition = (Vector3.right*mapref.tilewidth);
			blocks[3].transform.localPosition = (-Vector3.up*mapref.tileheight + Vector3.right*mapref.tilewidth);
			break;
		case 2:
			blocks[0].transform.localPosition = Vector3.up*mapref.tileheight;
			blocks[2].transform.localPosition = -Vector3.up*mapref.tileheight;
			blocks[3].transform.localPosition = -(Vector3.up*mapref.tileheight + Vector3.up*mapref.tileheight);
			break;
		case 3:
			blocks[0].transform.localPosition = (Vector3.up*mapref.tileheight);
			blocks[2].transform.localPosition = (-Vector3.up*mapref.tileheight);
			blocks[3].transform.localPosition = (-Vector3.up*mapref.tileheight + Vector3.right*mapref.tilewidth);
			break;
		case 4:
			blocks[0].transform.localPosition = Vector3.up*mapref.tileheight;
			blocks[2].transform.localPosition = (Vector3.up*mapref.tileheight + Vector3.right*mapref.tilewidth);
			blocks[3].transform.localPosition = Vector3.right*mapref.tilewidth;
			break;
		case 5:
			blocks[0].transform.localPosition = (Vector3.up*mapref.tileheight);
			blocks[2].transform.localPosition = (-Vector3.up*mapref.tileheight);
			blocks[3].transform.localPosition = (-Vector3.up*mapref.tileheight + -Vector3.right*mapref.tilewidth);
			break;
		case 6:
			blocks[0].transform.localPosition = (Vector3.up*mapref.tileheight);
			blocks[2].transform.localPosition = (-Vector3.right*mapref.tilewidth);
			blocks[3].transform.localPosition = (-Vector3.up*mapref.tileheight + -Vector3.right*mapref.tilewidth);
			break;
		case 7:
			blocks[0].transform.localPosition = Vector3.up*mapref.tileheight;
			blocks[2].transform.localPosition = Vector3.right*mapref.tilewidth;
			blocks[3].transform.localPosition = -Vector3.up*mapref.tileheight;
			break;
		}
		this.transform.position = startposition;
	}

	void MoveDown () {
		if (CheckLocation (4)) {
			this.transform.position = mapref.MoveBlock(this.transform,4);
			timetracker = 0f;
		} else {
			foreach (Transform block in blocks) {
				mapref.PlayerToBlock(block);
			}
			ReInstantiate();
		}
	}

	void MoveLeft () {
		if (CheckLocation (2)) {
			this.transform.position = mapref.MoveBlock(this.transform,2);
		}
	}

	void MoveRight () {
		if (CheckLocation (3)) {
			this.transform.position = mapref.MoveBlock(this.transform,3);
		}
	}

	void CClockwise () {
		if (status != 4) {
			this.transform.Rotate (0f, 0f, 90f);
			if (!CheckLocation (0)) {
				this.transform.Rotate (0f, 0f, -90f);
			}
		}
	}

	void Clockwise () {
		if (status != 4) {
			this.transform.Rotate (0f, 0f, -90f);
			if (!CheckLocation (0)) {
				this.transform.Rotate (0f, 0f, 90f);
			}
		}
	}

	/* Directions
	 *   1
	 * 2 0 3
	 *   4
	 */
	bool CheckLocation (int _direction) {
		Vector2 _coord;
		foreach (Transform block in blocks) {
			_coord = mapref.FloatCoToMapCo(block.position);
			switch (_direction) {
			default:

				break;
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
			if (mapref.BlockingBlock((int)_coord.x,(int)_coord.y)) {
				return false;
			}
		}
		return true;
	}
}
