// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class InventoryAddItem : MonoBehaviour {
	InventoryGUI TheInventory;
	PlayerInventory TheTextures;
	int ArrayGrid= 0;
	static int InventoryNewItemAdded= -1;
	Texture BlankIcon; 
	Texture TheNewItem;
	LoadingScreen loadingScript;
	void  Update (){
		if(Application.loadedLevel == 1 && ArrayGrid == 4){ 
			LoadingScreen.LoadingScreenOn = true;
			loadingScript.ChooseImg();
			WaitTimeLevel2();  
		}            
		if(Application.loadedLevel == 2 && ArrayGrid == 9){     
			LoadingScreen.LoadingScreenOn = true;
			loadingScript.ChooseImg();
			WaitTimeLevel3();  
		}  
		if(Application.loadedLevel == 3 && ArrayGrid == 14){  
			LoadingScreen.LoadingScreenOn = true;
			loadingScript.ChooseImg();
			WaitTimeLevel4();  
		}     
	}
	void  Start (){
		TheInventory = gameObject.GetComponent<InventoryGUI>();
		TheTextures = gameObject.GetComponent<PlayerInventory>(); 
		loadingScript = gameObject.GetComponent<LoadingScreen>();
		for(int i= 0; i <PlayerInventory.itemPlayersAmount.Length; i++) // for loop die checkt hoeveel items er in playersAmount zit. 
		{
			if (PlayerInventory.itemPlayersAmount[i] > 0) // kijken of een item uberhaupt een aantal heeft
			{ 
				TheInventory.Grids[i].image = TheTextures.itemTexture[i];  // zorgt ervoor dat de juiste image bij de correcte ID komt.
			}
			
		}
	}
	public void  newItem (){
		if (InventoryAddItem.InventoryNewItemAdded > -1) // zodra je iets opraakt wordt deze waarde in collection.js hoger als -1 gezet.
		{
			TheNewItem = TheTextures.itemTexture[InventoryAddItem.InventoryNewItemAdded]; // haalt de juiste afbeelding uit de itemTexture array uit de player_inventory script.
			if (ArrayGrid < TheInventory.Grids.Length) 
			{	 
				if (TheInventory.Grids[ArrayGrid].image == BlankIcon) // als grid gelijk is aan blankicon, dan het item toevoegen
				{
					TheInventory.Grids[ArrayGrid].image = TheNewItem;
					ArrayGrid = 0;
					InventoryAddItem.InventoryNewItemAdded = -1;
				}
				else if (TheInventory.Grids[ArrayGrid].image != BlankIcon) // als grid al vol is met een item icon dan arraygrid +1 om verder te zoeken naar een grid die leeg is.
				{
					ArrayGrid += 1;  
				}
			}
			
		}
	}
	
	IEnumerator  WaitTimeLevel2 (){
		yield return new WaitForSeconds(3);
		Application.LoadLevel(2);
	}
	
	IEnumerator  WaitTimeLevel3 (){
		yield return new WaitForSeconds(3);
		Application.LoadLevel(3);
	}
	
	IEnumerator  WaitTimeLevel4 (){
		yield return new WaitForSeconds(3);
		Application.LoadLevel(4);
	}
	
	
	
	
}