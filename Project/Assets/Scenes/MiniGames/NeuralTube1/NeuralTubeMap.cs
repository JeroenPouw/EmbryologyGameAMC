using UnityEngine;
using System.Collections;

enum blocktype {Block = 0, Trigger = 1, Bonus  = 2, Player = 3};

public class NeuralTubeMap : MonoBehaviour {

	public uint mapwidth;
	public uint mapheight;

	private int[][] map;
	
	void Start () {
		CreateMap ();

	}

	void Update () {
		
	}

	void CreateMap(){
//		map = new blocktype[mapwidth][mapheight];


//		 map = new blocktype[ ][ ];
		map = new int[,][,]
		{ 	{ 0, 0, 0, 0, 0}, 
			{ 0, 0, 0, 0, 0},
			{ 0, 0, 0, 0, 0},
			{ 0, 0, 0, 0, 0},
			{ 0, 0, 0, 0, 0}	};

	}

}


