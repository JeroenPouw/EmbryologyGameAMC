// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {
	
	//public Object[] textures = new Object[15];
	//Items
	static string[] itemID = new string[] {"Ventral&DorsalPancreas", "VitellineDuct", "RespiratoyBud", 
	                          "ThyroidGland", "Lever", "Coelom", "Heart", 
	                          "Veins", "Somites", "MesonephrosMesonphericDuctGonodalRidge", 
	                          "LensPlacodeOpticVesticle", "OticVesicle", 
		"RathesPouch", "Skin", "NeuralTubeNerves"};  // item id van elk object
	public static int[] itemPlayersAmount = new int[]  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; // aantal van elk object
	public Texture[] itemTexture = new Texture[PlayerInventory.itemID.Length];
	
	void  Start (){
		//textures = (Texture2D[]) Resources.LoadAll("ObjectIcons") as Texture2D[];// laad alle textures en stop ze in de var textures
		Texture2D[] textures = System.Array.ConvertAll(Resources.LoadAll("ObjectsInfo", typeof(Texture2D)),o=>(Texture2D)o);

		Debug.Log (textures.Length);
		for (int i = 0; i < textures.Length; i++)
		{
			itemTexture[i] =  textures[i];
		}
	}
	
}