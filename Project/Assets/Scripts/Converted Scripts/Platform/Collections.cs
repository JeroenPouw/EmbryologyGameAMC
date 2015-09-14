// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class Collections : MonoBehaviour {
	
	GUISkin questionSkin;
	Vector2 TextSize = new Vector2(500, 250);
	bool  pickUpVitellineDuct = false;
	bool  pickUpRespiratoyBud = false;
	bool  pickUpThyroid = false;
	bool  pickUpLever = false;
	bool  pickUpCoelom = false;
	bool  pickUpHeart = false;
	bool  pickUpVeins = false;
	bool  pickUpSomites = false;
	bool  pickUpMesonephros = false;
	bool  pickUpLens = false;
	bool  pickUpOtic = false;
	bool  pickUpRathesPouch = false;
	bool  pickUpSkin = false;
	bool  pickUpNeural = false;
	AudioClip pickupObject;
	GameObject foundObjectParticle;
	
	void  Update (){
		WaitTime();
	}
	
	void  OnTriggerEnter ( Collider col  ){
		if (col.gameObject.name == "Ventral&DorsalPancreas")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[0] += 1; 
			//Inventory_Add_Item.InventoryNewItemAdded = 0;
			Destroy(col.gameObject);
			
		}
		if (col.gameObject.name == "VitellineDuct")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[1] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 1;
			pickUpVitellineDuct = true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "RespiratoyBud")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[2] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 2;
			pickUpRespiratoyBud = true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "ThyroidGland")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[3] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 3;
			pickUpThyroid = true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "Lever")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[4] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 4;
			pickUpLever = true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "Coelom")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			//Player_Inventory.itemPlayersAmount[5] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 5;
			pickUpCoelom = true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "Heart")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[6] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 6;
			pickUpHeart = true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "Veins")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[7] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 7;
			pickUpVeins = true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "Somites")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[8] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 8;
			pickUpSomites = true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "MesonephrosMesonphericDuctGonodalRidge")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[9] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 9;
			pickUpMesonephros = true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "LensPlacodeOpticVesticle")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[10] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 10;
			pickUpLens = true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "OticVesicle")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[11] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 11;
			pickUpOtic = true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "RathesPouch")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[12] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 12;
			pickUpRathesPouch = true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "Skin")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[13] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 13;
			pickUpSkin = true;
			Destroy(col.gameObject);
		}
		if (col.gameObject.name == "NeuralTubeNerves")
		{
			Instantiate(foundObjectParticle, this.gameObject.transform.position, Quaternion.Euler(270, 0, 0));
			GetComponent<AudioSource>().PlayOneShot(pickupObject);
			//Player_Inventory.itemPlayersAmount[14] += 1;
			//Inventory_Add_Item.InventoryNewItemAdded = 14;
			pickUpNeural = true;
			Destroy(col.gameObject);
		}
	}
	void  OnGUI (){
		//GUI.skin = questionSkin;
		GUIStyle labelStyle=GUI.skin.label;
		GUI.skin.label.fontSize = 20;
		if(pickUpVitellineDuct == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string VitellineDuctPickUp= "The Vitelinne Duct has been added to your inventory.";
			GUILayout.Label(VitellineDuctPickUp); 
			GUILayout.EndArea();
		}
		if(pickUpRespiratoyBud == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string RespiratoryPickUp= "The Respiratory Bud has been added to your inventory.";
			GUILayout.Label(RespiratoryPickUp); 
			GUILayout.EndArea();
		}
		if(pickUpThyroid == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string ThyroidPickUp= "The Thyroid Gland has been added to your inventory.";
			GUILayout.Label(ThyroidPickUp); 
			GUILayout.EndArea();
		} 
		if(pickUpLever == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string LeverPickUp= "The Liver has been added to your inventory.";
			GUILayout.Label(LeverPickUp); 
			GUILayout.EndArea();
		} 
		if(pickUpCoelom == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string CoelomPickUp= "The Coelom has been added to your inventory.";
			GUILayout.Label(CoelomPickUp); 
			GUILayout.EndArea();
		} 
		if(pickUpHeart == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string HeartPickUp= "The Heart has been added to your inventory.";
			GUILayout.Label(HeartPickUp); 
			GUILayout.EndArea();
		} 
		if(pickUpVeins == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string VeinsPickUp= "The Arteries and Veins have been added to your inventory.";
			GUILayout.Label(VeinsPickUp); 
			GUILayout.EndArea();
		} 
		if(pickUpSomites == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string SomitesPickUp= "The Somites has been added to your inventory.";
			GUILayout.Label(SomitesPickUp); 
			GUILayout.EndArea();
		} 
		if(pickUpMesonephros == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string MesonephrosPickUp= "The Urogenital ridge has been added to your inventory.";
			GUILayout.Label(MesonephrosPickUp); 
			GUILayout.EndArea();
		} 
		if(pickUpLens == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string LensPickUp= "The Eye has been added to your inventory.";
			GUILayout.Label(LensPickUp); 
			GUILayout.EndArea();
		} 
		if(pickUpOtic == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string OticPickUp= "The Otic Vesicle has been added to your inventory.";
			GUILayout.Label(OticPickUp); 
			GUILayout.EndArea();
		} 
		if(pickUpRathesPouch == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string RathesPickUp= "The Rathe's Pouch has been added to your inventory.";
			GUILayout.Label(RathesPickUp); 
			GUILayout.EndArea();
		} 
		if(pickUpSkin == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string SkinPickUp= "The Skin has been added to your inventory.";
			GUILayout.Label(SkinPickUp); 
			GUILayout.EndArea();
		} 
		if(pickUpNeural == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string NeuralPickUp= "The Nervous system has been added to your inventory.";
			GUILayout.Label(NeuralPickUp); 
			GUILayout.EndArea();
		}  
	}  
	
	IEnumerator  WaitTime (){ 
		if(pickUpVitellineDuct == true){
			yield return new WaitForSeconds(2);
			pickUpVitellineDuct = false;
		}
		if(pickUpRespiratoyBud == true){
			yield return new WaitForSeconds(2);
			pickUpRespiratoyBud = false;
		}
		if(pickUpThyroid == true){
			yield return new WaitForSeconds(2);
			pickUpThyroid = false;
		}
		if(pickUpLever == true){
			yield return new WaitForSeconds(2);
			pickUpLever = false;
		}
		if(pickUpCoelom == true){
			yield return new WaitForSeconds(2);
			pickUpCoelom = false;
		}
		if(pickUpHeart == true){
			yield return new WaitForSeconds(2);
			pickUpHeart = false;
		}
		if(pickUpVeins == true){
			yield return new WaitForSeconds(2);
			pickUpVeins = false;
		}
		if(pickUpSomites == true){
			yield return new WaitForSeconds(2);
			pickUpSomites = false;
		}
		if(pickUpMesonephros == true){
			yield return new WaitForSeconds(2);
			pickUpMesonephros = false;
		}
		if(pickUpLens == true){
			yield return new WaitForSeconds(2);
			pickUpLens = false;
		}
		if(pickUpOtic == true){
			yield return new WaitForSeconds(2);
			pickUpOtic = false;
		}
		if(pickUpRathesPouch == true){
			yield return new WaitForSeconds(2);
			pickUpRathesPouch = false;
		}
		if(pickUpSkin == true){
			yield return new WaitForSeconds(2);
			pickUpSkin = false;
		}
		if(pickUpNeural == true){
			yield return new WaitForSeconds(2);
			pickUpNeural = false;
		}
	}
}