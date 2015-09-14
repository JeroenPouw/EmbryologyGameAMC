// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectObject : MonoBehaviour {

	DragObjects dragObjectScript;
	static bool  mouseDownL = false;
	static bool  mouseDownR = false;
	public int layerMask;
	int rangeOfrenders;
	Renderer rend;
	
	GameObject currentObject;
	int shaderCount = 0;
	
	GameObject[] layerObjects;
	int layerRenderCount = 0;
	bool  objectSelected = false;

	public AudioClip AudioCorrect;
	//AudioClip correctAnswerSound;
	public bool  playCorrectSound = false;

	void Awake(){
		dragObjectScript = gameObject.GetComponent<DragObjects> ();
		rend = GetComponent<Renderer> ();
	}
	
	void  Update (){
		MouseInput();
		if(playCorrectSound == true){
			GetComponent<AudioSource>().PlayOneShot(AudioCorrect);
			playCorrectSound = false;
		}
	}
	
	void  MouseInput (){
		if(Input.GetButtonDown("Fire1") && !mouseDownL && currentObject == null && Time.timeScale != 0){
			mouseDownL = true;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			layerMask = 1 << 18;
			if(Physics.Raycast(ray, out hit, 100, layerMask)){
				rangeOfrenders = hit.transform.GetComponent<Renderer>().materials.Length;
				hit.transform.gameObject.layer = 19;
				for(int i= 0; i < rangeOfrenders; i++){
					shaderCount++;
					currentObject = hit.transform.gameObject;
					hit.transform.GetComponent<Renderer>().materials[i].shader = Shader.Find("Self-Illumin/Outlined Diffuse");
				}
				objectSelected = true;

			}
			
		}
		if(Input.GetButtonDown("Fire1") && !mouseDownL && currentObject != null && Time.timeScale != 0){
			for(int d = shaderCount; d > 0; d--){
				currentObject.transform.GetComponent<Renderer>().materials[d-1].shader = Shader.Find("Diffuse");
			}
			if(currentObject.layer == 19){
				currentObject.layer = 18;
				objectSelected = false;
			}
			mouseDownL = true;
			Ray rayAgain = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitAgain;
			int layerMaskAgain= 1 << 18;
			if(Physics.Raycast(rayAgain, out hitAgain, 100, layerMaskAgain)){
				int rangeOfRendersAgain= hitAgain.transform.GetComponent<Renderer>().materials.Length;
				hitAgain.transform.gameObject.layer = 19;
				shaderCount = 0;
				for(int r= 0; r < rangeOfRendersAgain; r++){ 
					shaderCount++;
					currentObject = hitAgain.transform.gameObject;
					hitAgain.transform.GetComponent<Renderer>().materials[r].shader = Shader.Find("Self-Illumin/Outlined Diffuse");
				}
				objectSelected = true;

			}
			
		}
		if (Input.GetButtonUp("Fire1")){
			mouseDownL = false;
		}
		if (Input.GetButtonUp("Fire2")){
			mouseDownR = false;
		}
		
	}
	
	void  OnGUI (){
		if(currentObject != null && currentObject.name == "Alimentary_canal" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The alimentary canal is currently selected");
		}
		if(currentObject != null && currentObject.name == "Notochord" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The notochord is currently selected");
		}
		if(currentObject != null && currentObject.name == "Coelom" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The coelom is currently selected");
		}
		if(currentObject != null && currentObject.name == "Heart" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The heart is currently selected");
		}
		if(currentObject != null && currentObject.name == "LensPlacodeOpticVesicle" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The lens placode and optic vesicle are currently selected");
		}
		if(currentObject != null && currentObject.name == "Liver" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The liver is currently selected");
		}
		if(currentObject != null && currentObject.name == "NeuralTube" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The neuraltube is currently selected");
		}
		if(currentObject != null && currentObject.name == "OticVesicle" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The otic vesicle is currently selected");
		}
		if(currentObject != null && currentObject.name == "RathkesPouch" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The rathkes pouch is currently selected");
		}
		if(currentObject != null && currentObject.name == "RespiratoryBud" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The respiratory bud is currently selected");
		}
		if(currentObject != null && currentObject.name == "Skin" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The skin is currently selected");
		}
		if(currentObject != null && currentObject.name == "Somites" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The somites is currently selected");
		}
		if(currentObject != null && currentObject.name == "ThyroidGland" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The thyroid gland is currently selected");
		}
		if(currentObject != null && currentObject.name == "UrogenitalRidge" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The urogenital ridge is currently selected");
		}
		if(currentObject != null && currentObject.name == "Veins" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The veins are currently selected");
		}
		if(currentObject != null && currentObject.name == "VentralDorsalPancreas" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The ventral and dorsal pancreas are currently selected");
		}
		if(currentObject != null && currentObject.name == "VitellineDuct" && objectSelected == true){
			GUI.Label (new Rect (Screen.width - 300, 80, 250, 70), "The vitelline duct is currently selected");
		}
		if(GUI.Button (new Rect(Screen.width - 400, 20, 180, 50), "Transparent") && currentObject != null){
			for(int e= shaderCount; e > 0; e--){
				currentObject.transform.GetComponent<Renderer>().materials[e-1].shader = Shader.Find("Transparent/Diffuse");
				//currentObject.transform.GetComponent<Renderer>().materials[e-1].color.a = 0.5f;
			}
			currentObject.layer = 20;
			shaderCount = 0;
		}
		if(GUI.Button (new Rect(Screen.width - 200, 20, 180, 50), "Show All")){
			layerObjects = FindGameObjectsWithLayer(20);
			if(layerObjects != null){
				for(int l= 0; l < layerObjects.Length; l++){
					float mats = layerObjects[l].transform.GetComponent<Renderer>().materials.Length;
					GameObject arrayObjects = layerObjects[l];
					arrayObjects.layer = 18;
					while(layerRenderCount < mats){
						arrayObjects.transform.GetComponent<Renderer>().materials[layerRenderCount].shader = Shader.Find("Diffuse");
						layerRenderCount++;
					}
					if(layerRenderCount == mats){
						layerRenderCount = 0;
					}
				}
			}
		}
	}
	GameObject[] FindGameObjectsWithLayer ( int layer  ){
		GameObject[] goArray = FindObjectsOfType(typeof(GameObject))as GameObject[];
		List<GameObject> goList = new List<GameObject>();


		for (int i= 0; i < goArray.Length; i++) {
			if (goArray[i].layer == layer) {
				goList.Add(goArray[i]);
			}
		}
		if(goList.Count == 0) {
			return null;
		}
		return goList.ToArray();
	}
}