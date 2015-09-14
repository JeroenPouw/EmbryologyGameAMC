// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour {
	
	GUISkin levelInfoSkin;
	private Vector2 InfoButtonPosition = new Vector2(460,15.5f);
	private Vector2 InfoButtonSize = new Vector2(40,40);
	Vector2 InfoTextSize = new Vector2(320, 275);
	Texture InfoIcon;
	public bool  infoClicked = false;
	Vector2 scrollPosition = Vector2.zero;
	Vector2 TextSize = new Vector2(430, 415);
	InventoryGUI inventoryguiScript;
	//inventoryguiScript = FindObjectOfType(typeof(Inventory_GUI));

	void Awake(){
		inventoryguiScript = gameObject.GetComponent<InventoryGUI>();
	}
	void  OnGUI (){
		GUI.skin = levelInfoSkin;
		if(Application.loadedLevel == 1){
			GUI.Label (new Rect (330, 20, 250, 70), "The endoderm");
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon)){
				infoClicked = true;
			}
		}
		if(Application.loadedLevel == 2){
			GUI.Label (new Rect (330, 20, 250, 70), "The mesoderm");
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon)){
				infoClicked = true;
			}
		}
		if(Application.loadedLevel == 3){
			GUI.Label (new Rect (330, 20, 250, 70), "The ectoderm");
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon)){
				infoClicked = true;
			}
		}
		if(Application.loadedLevel == 1 && infoClicked == true){
			inventoryguiScript.InventoryOn = false;
			GUILayout.BeginArea ( new Rect(310, 50, InfoTextSize.x,InfoTextSize.y)); 
			string endodermText= "The endoderm is the most ventral layer of the three germ layers of the embryonic disc after gastrulation. It faces the yolk sac and forms the epithelial lining of multiple organs and organ systems, such as the alimentary canal, the pancreatic- and bile ducts, the respiratory system, the auditory tube and tympanic cavity, and most of the urinary bladder. The epithelial components of the mouth and the most caudal part of the rectum, however, are derived from the ectoderm. The parenchymal components of the derivatives of the intestinal tract, such as the liver, the islets of the pancreas, the thymus and the thyroid gland are also of endodermal origin. Appreciate that adult organs are composed of two types of cells: parenchymal cells, which exert the organ-specific functions and stromal cells, which constitute the connective tissue component of the organ. Parenchymal cells generally develop directly from one of the germ layers, whereas the stromal cells may be derived from all three germ layers, albeit the mesoderm quantitatively contributes most to the stroma cells.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(endodermText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();   
		}
		if(Application.loadedLevel == 2 && infoClicked == true){
			inventoryguiScript.InventoryOn = false;
			GUILayout.BeginArea ( new Rect(310, 50, InfoTextSize.x,InfoTextSize.y)); 
			string mesodermText= "The intra-embryonic mesoderm, or IEM, is the middle layer of the three germ layers of the embryonic disc after gastrulation. Within the lateral mesoderm, the intra-embryonic coelom develops. The mesoderm gives rise to the cardiovascular system, most of the urogenital system, skeletomuscular system, connective tissues, and the mesothelial lining of the body cavities.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(mesodermText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();  
		}
		if(Application.loadedLevel == 3 && infoClicked == true){
			inventoryguiScript.InventoryOn = false;
			GUILayout.BeginArea ( new Rect(310, 50, InfoTextSize.x,InfoTextSize.y)); 
			string ectodermText= "The cells of the epiblast that do not ingress during gastrulation form the ectodermal layer. Upon induction by the notochord the central part differentiates into neuro-ectoderm forming the neural plate, whereas the peripheral part differentiates into epidermal ectoderm. At the interface of the neuro-ectoderm and the epidermal ectoderm, neural crest cells will be formed. This is a multipotent, migratory cell population that gives rise to a diversity of structures and cells such as melanocytes (pigment cells), the peripheral nervous system and craniofacial connective tissue, cartilage and bone (Huang and Saint-Jeannet 2004).\n\nTechnical reconstruction information:\nOwing to the cranio-caudal gradient in development the caudal part of the embryonic disk still contains gastrulating epiblastic cells, whereas the cranial part already differentiates into neural plate, neural crest and epidermal ectoderm. The sagittal plane of sectioning of the reconstructed embryo did not permit the unambiguous distinction of the different cell types. Hence they are represented in the reconstruction with a single label.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(ectodermText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();  
		}
	}
}