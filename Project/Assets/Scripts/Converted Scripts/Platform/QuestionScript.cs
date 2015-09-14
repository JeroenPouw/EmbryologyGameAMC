// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class QuestionScript : MonoBehaviour {
	
	Vector2 TextSize = new Vector2(430, 415);
	
	bool  inLevel1_room1 = false;
	bool  inLevel1_room2 = false;
	bool  inLevel1_room3 = false;
	bool  inLevel1_room4 = false;
	bool  inLevel1_room5 = false;
	
	bool  inLevel2_room1 = false;
	bool  inLevel2_room2 = false;
	bool  inLevel2_room3 = false;
	bool  inLevel2_room4 = false;
	bool  inLevel2_room5 = false;
	
	bool  inLevel3_room1 = false;
	bool  inLevel3_room2 = false;
	bool  inLevel3_room3 = false;
	bool  inLevel3_room4 = false;
	bool  inLevel3_room5 = false;
	
	GameObject Level1_room1;
	GameObject Level1_room2;
	GameObject Level1_room3;
	GameObject Level1_room4;
	GameObject Level1_room5;
	
	GameObject Level2_room1;
	GameObject Level2_room2;
	GameObject Level2_room3;
	GameObject Level2_room4;
	GameObject Level2_room5;
	
	GameObject Level3_room1;
	GameObject Level3_room2;
	GameObject Level3_room3;
	GameObject Level3_room4;
	GameObject Level3_room5;
	
	GUISkin questionSkin;
//	
	FadeInScript fade;
//	fade = FindObjectOfType(typeof(FadeIn));
	
	Scores score;
	//score = FindObjectOfType(typeof(Score));
	
	public bool  eenScore = false;	
	int answerCount = 0;
	
	Transform targetPosition_level1_room1;
	Transform targetPosition_level1_room2;
	Transform targetPosition_level1_room3;
	Transform targetPosition_level1_room4;
	Transform targetPosition_level1_room5;
	
	Transform targetPosition_level2_room1;
	Transform targetPosition_level2_room2;
	Transform targetPosition_level2_room3;
	Transform targetPosition_level2_room4;
	Transform targetPosition_level2_room5;
	
	Transform targetPosition_level3_room1;
	Transform targetPosition_level3_room2;
	Transform targetPosition_level3_room3;
	Transform targetPosition_level3_room4;
	Transform targetPosition_level3_room5;
	
	GameObject[] false_level1_room1;
	GameObject[] false_level1_room2;
	GameObject[] false_level1_room3;
	GameObject[] false_level1_room4;
	GameObject[] false_level1_room5;
	
	GameObject[] false_level2_room1;
	GameObject[] false_level2_room2;
	GameObject[] false_level2_room3;
	GameObject[] false_level2_room4;
	GameObject[] false_level2_room5;
	
	GameObject[] false_level3_room1;
	GameObject[] false_level3_room2;
	GameObject[] false_level3_room3;
	GameObject[] false_level3_room4;
	GameObject[] false_level3_room5;
	
	InventoryGUI inventory;
//	inventory = FindObjectOfType(typeof(Inventory_GUI));
	
	CameraShaking shakeScript;
	//shakeScript = FindObjectOfType(typeof(CameraShake));
	
	GameObject textContainer10;
	GameObject textContainer5;
	GameObject textContainer1;
	
	GameObject VentralDorsalPancreas;
	GameObject VitellineDuct;
	GameObject RespiratoryBud;
	GameObject ThyroidGland;
	GameObject Liver;
	
	GameObject Coelom;
	GameObject Heart;
	GameObject Veins;
	GameObject Somites;
	GameObject UrogenitalRidge;
	
	GameObject LensPlacodeOpticVesticle;
	GameObject OticVesicle;
	GameObject Neuraltube;
	GameObject Skin;
	GameObject RathkesPouch;
	
	AudioClip correctAnswerSound;
	AudioClip falseAnswerSound;
	
	bool  InfoClicked = false;
	
	Texture InfoIcon;
	Vector2 InfoButtonPosition = new Vector2(382,25);
	Vector2 InfoButtonSize = new Vector2(40,40);
	Vector2 InfoTextPosition = new Vector2(345,143);
	Vector2 InfoTextSize = new Vector2(320, 275);
	Vector2 scrollPosition = Vector2.zero;
	GameObject teleportParticle;
	Camera mainCamera;
	
	void  Start (){
		inventory = gameObject.GetComponent<InventoryGUI>();
		score = gameObject.GetComponent<Scores>();
		shakeScript = gameObject.GetComponent<CameraShaking> ();
		fade = gameObject.GetComponent<FadeInScript>();
		false_level1_room1 = GameObject.FindGameObjectsWithTag("false_level1_room1"); 
		false_level1_room2 = GameObject.FindGameObjectsWithTag("false_level1_room2"); 
		false_level1_room3 = GameObject.FindGameObjectsWithTag("false_level1_room3"); 
		false_level1_room4 = GameObject.FindGameObjectsWithTag("false_level1_room4"); 
		false_level1_room5 = GameObject.FindGameObjectsWithTag("false_level1_room5"); 
		
		false_level2_room1 = GameObject.FindGameObjectsWithTag("false_level2_room1"); 
		false_level2_room2 = GameObject.FindGameObjectsWithTag("false_level2_room2"); 
		false_level2_room3 = GameObject.FindGameObjectsWithTag("false_level2_room3"); 
		false_level2_room4 = GameObject.FindGameObjectsWithTag("false_level2_room4"); 
		false_level2_room5 = GameObject.FindGameObjectsWithTag("false_level2_room5"); 
		
		false_level3_room1 = GameObject.FindGameObjectsWithTag("false_level3_room1"); 
		false_level3_room2 = GameObject.FindGameObjectsWithTag("false_level3_room2"); 
		false_level3_room3 = GameObject.FindGameObjectsWithTag("false_level3_room3"); 
		false_level3_room4 = GameObject.FindGameObjectsWithTag("false_level3_room4"); 
		false_level3_room5 = GameObject.FindGameObjectsWithTag("false_level3_room5"); 
	}
	
	void  OnGUI (){
		GUI.skin = questionSkin;
		if(eenScore == true){
			textFeedbackEen();
			eenScore = false;
		}
		if(inLevel1_room1 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 20, TextSize.x,TextSize.y));  
			string PancreasVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nThe two pancreatic buds originate from…\n\nAnswers:\nA: The foregut and the midgut\nB: The foregut and the hindgut\nC: The midgut and the hindgut\nD: Solely the foregut\nE: Solely the midgut\n\nChoose the correct hallway to answer the question.";
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(PancreasVraag);
			GUILayout.EndArea();
		}
		if(inLevel1_room2 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string VitelinneDuctVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nA persisting vitelline duct can give rise to a…\n\nAnswers:\nA: Meckel’s diverticulum\nB: Zenker’s diverticulum\nC: Killian-Jamieson diverticulum\nD: Gastric diverticulum\nE: Colonic diverticulum\n\nChoose the correct hallway to answer the question.";
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(VitelinneDuctVraag);
			GUILayout.EndArea();
		}
		if(inLevel1_room3 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string RespiratoryBudVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nThe respiratory bud develops from the…\n\nAnswers:\nA: Oral cavity\nB: Vitelline duct\nC: Duodenum\nD: Midgut\nE: Foregut\n\nChoose the correct hallway to answer the question.";
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(RespiratoryBudVraag);
			GUILayout.EndArea();
		}
		if(inLevel1_room4 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string ThyroidGlandVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nThe thyroid gland develops…\n\nAnswers:\nA: In the roof of the oral cavity\nB: In the roof of the pharynx\nC: At the basis of the tongue\nD: In the septum transversum\nE: In the roof of the rhombencephalon\n\nChoose the correct hallway to answer the question."; 
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(ThyroidGlandVraag);
			GUILayout.EndArea();
		}
		if(inLevel1_room5 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string LeverVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nThe endodermal hepatic diverticulum grows into the…\n\nAnswers:\nA: Septum transversum\nB: Pericardioperitoneal canals\nC: Dorsal mesentery\nD: Greater omentum\nE: Mediastinum\n\nChoose the correct hallway to answer the question."; 
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(LeverVraag);
			GUILayout.EndArea();
		}
		
		if(inLevel2_room1 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string CoelomVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nThe intra-embryonic coelom develops…\n\nAnswers:\nA: in the somatopleuric mesoderm\nB: in the axial mesoderm\nC: in the lateral mesoderm\nD: in the paraxial mesoderm\nE: in the intermediate mesoderm\n\nChoose the correct hallway to answer the question."; 
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(CoelomVraag);
			GUILayout.EndArea();
			
		}
		if(inLevel2_room2 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string HeartVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nThe cardiovascular system first appears during which week of embryonic development?\n\nAnswers:\nA: First\nB: Second\nC: Third\nD: Fourth\nE: Fifth\n\nChoose the correct hallway to answer the question."; 
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(HeartVraag);
			GUILayout.EndArea();
		}
		if(inLevel2_room3 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string VeinsVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nDuring development, the vitelline artery becomes the…\n\nAnswers:\nA: Superior mesenteric artery\nB: Coeliac trunk\nC: Inferior mesenteric artery\nD: 7th intersegmental artery\nE: Median sacral artery\n\nChoose the correct hallway to answer the question."; 
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(VeinsVraag);
			GUILayout.EndArea();
		}
		if(inLevel2_room4 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string SomitesVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nThroughout its development, a human embryo forms approximately  … somite pairs in total\n\nAnswers:\nA: 15\nB: 20\nC: 25\nD: 30\nE: 35\n\nChoose the correct hallway to answer the question."; 
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(SomitesVraag);
			GUILayout.EndArea();
		}
		if(inLevel2_room5 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string MesoVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nWhat will the mesonephric duct become in males?\n\nAnswers:\nA: Ductus epididymis, ductus deferens and seminal vesicles\nB: Urethra, ductus deferens and testicle\nC: Urethra, prostate and seminal vesicles\nD: Ductus deferens, seminal vesicles and prostate\nE: Ductus epidydimis, ductus deferens and testicle\n\nChoose the correct hallway to answer the question."; 
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(MesoVraag);
			GUILayout.EndArea();
		}
		
		if(inLevel3_room1 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string LensVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nThe optic cup derives from the… and the lens from the…\n\nAnswers\nA: neural ectoderm, surface ectoderm\nB: neural ectoderm, mesoderm\nC: mesoderm, surface ectoderm\nD: surface ectoderm, neural ectoderm\nE: neural ectoderm, neural ectoderm\n\nChoose the correct hallway to answer the question."; 
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(LensVraag);
			GUILayout.EndArea();
		}
		if(inLevel3_room2 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string OticVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nWhich of the following is the most complete list of the derivatives of the otic vesicle?\n\nAnswers\nA: Semicircular ducts, cochlea, utricle, saccule and endolymphatic duct\nB: Semicircular ducts, cochlea, utricle, saccule, endolymphatic duct and endolymphatic sac\nC: Semicircular ducts, cochlea, utricle and saccule\nD: Semicircular ducts, cochlea and utricle\nE: Semicircular ducts and cochlea\n\nChoose the correct hallway to answer the question."; 
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(OticVraag);
			GUILayout.EndArea();
		}
		if(inLevel3_room3 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y + 20));  
			string RathesPouchVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nThe correct order of the brain vesicles from rostral to dorsal is:\n\nAnswers\nA:Diencephalon, Metencephalon, Telencephalon, Myelencephalon  Mesencephalon\nB: Mesencephalon, Diencephalon, Myelencephalon, Telencephalon, Metencephalon\nC: Metencephalon,  Telencephalon,  Mesencephalon, Myelencephalon, Diencephalon\nD: Telencephalon, Diencephalon, Mesencephalon, Metencephalon, Myelencephalon\nE: Myelencephalon, Metencephalon, Mesencephalon, Diencephalon, Telencephalon\n\nChoose the correct hallway to answer the question."; 
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(RathesPouchVraag);
			GUILayout.EndArea();
		}
		if(inLevel3_room4 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string SkinPouchVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nThe integumentary system has contributions from different embryonic layers. The epidermis derives from the …, the melanocytes from the … and the connective tissue of the hypodermis from the …\n\nAnswers\nA: Mesoderm, Mesoderm, Ectoderm\nB: Ectoderm, Mesoderm, Ectoderm\nC: Mesoderm, Ectoderm, Mesoderm\nD: Ectoderm, Ectoderm, Ectoderm\nE: Ectoderm, Ectoderm, Mesoderm\n\nChoose the correct hallway to answer the question."; 
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(SkinPouchVraag);
			GUILayout.EndArea();
		}
		if(inLevel3_room5 == true){
			GUILayout.BeginArea ( new Rect(Screen.width * 0.4f, Screen.height - Screen.height + 50, TextSize.x,TextSize.y));  
			string NeuralTubeNervesVraag= "<i>Press the information button if you don't know the answer.</i>\n\nQuestion:\nRathke’s pouch develops from the…\n\nAnswers\nA: The ectodermal roof of the oral cavity\nB: The endodermal roof of the oral cavity\nC: The ectodermal basis of the tongue\nD: The endodermal basis of the tongue\nE: None of the above\n\nChoose the correct hallway to answer the question."; 
			if(GUI.Button( new Rect(InfoButtonPosition.x, InfoButtonPosition.y, InfoButtonSize.x, InfoButtonSize.y), InfoIcon))
			{
				if(InfoClicked == false){
					InfoClicked = true;
				}
				else if(InfoClicked == true){
					InfoClicked = false;
				}
			}
			GUILayout.Label(NeuralTubeNervesVraag);
			GUILayout.EndArea();
		}
		if(inLevel1_room1 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y)); 
			string VentralDorsalText= "Ventral and Dorsal Pancreas\n\nThe pancreas originates from two buds, which originate during stage 13 (28-32 days) in the caudal part of the foregut that develops into the proximal part of the duodenum. They expand into the septum transversum as the ventral and dorsal pancreatic buds. The dorsal pancreatic bud directly develops from the duodenal endoderm, whereas the ventral pancreatic bud originates from the proximal part of the hepatic diverticulum. Owing to the rotation of the duodenum the ventral bud comes to lie in the dorsal mesentery and fuses with the dorsal bud. The ventral bud forms the uncinate process and part of the pancreatic head. The remainder of the pancreas is derived from the dorsal bud. The definitive pancreatic duct derives from the ventral pancreas and drains off at the major duodenal papilla, whereas the drainage duct of the dorsal pancreas anastomoses with the ventral pancreatic duct and loses its original connection between the dorsal pancreas and the duodenum. It may persist as an accessory pancreatic duct that opens at the minor duodenal papilla.\n\nClinical information (Pancreas)\nAnnular pancreas\nWhen the merging process of both pancreatic buds partly fails, an annular pancreas can arise. In this anomaly, the ventral pancreatic bud lies (in part) around the duodenum following the embryonic pathway of migration, whereas it should be completely fused with the dorsal pancreatic bud after its migration. The hedgehoc signaling pathway seems to play a major part in this anomaly (Etienne et al., 2012). The incidence is 1 in every 1000 individuals (Etienne et al., 2012). These patients can suffer from symptoms of duodenal obstruction and therefore surgical intervention with bypass procedures might be necessary.\n\nAccessory pancreatic duct\nWhen there is no complete fusion of both pancreatic ducts, the accessory pancreatic duct from the dorsal pancreatic bud can remain in contact with the duodenum. An accessory pancreatic duct occurs in 5-10 % of the western population (Kamisawa, 2004). This is of clinical importance especially when an endoscopic retrograde cholangiopancreatography (ERCP) has to be performed in patients suffering from an obstruction due to gallstones for example.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(VentralDorsalText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel1_room2 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y));  
			string VitelinneDuctText= "Vitelline Duct\n\nThe vitelline duct is the remaining connection between the midgut and the remnant of the yolk sac. This duct will go into regression during the embryonic period.\n\nClinical information (Vitelline duct)\nWhen the vitelline duct persists, remnants of this duct can be found as a diverticulum of the ileum, the so-called Meckel’s diverticulum. Or a vitelline cyst can be present, attached with fibrous cords (vitelline ligaments) to the umbilicus and the wall of the ileum. A vitelline fistula directly connects the lumen of the ileum with the umbilicus leaving an open connection between the lumen of the gut and ‘the outside world’.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(VitelinneDuctText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel1_room3 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y)); 
			string RespiratoyBudText= "Respiratoy Bud\n\nThe respiratory system, or ventilatory system, is designed for gas exchange. The complete system comprises of airways, lungs and respiratory muscles which enable us to ventilate, thereby permitting passive gas exchange of oxygen and carbon dioxide between the air in the alveoli and the blood within the capillary bed surrounding them. The respiratory bud or lung bud derives from the foregut and has therefore an endodermal origin. During the embryonic period the respiratory bud develops into the respiratory tree, surrounded by mesodermal derived lung mesenchyme. At the end of the embryonic period the lungs and their separate lobes are easily recognizable, but further maturation during the fetal period is of extreme importance to the well-functioning of the lungs. Pre-term births often lead to infants with under-developed lungs because of the lack of surfactant. Surfactant lowers the surface tension within the alveoli, hereby preventing them from collapsing and ensuring gas exchange.\n\nTechnical reconstruction information:\nIn this model we assigned two labels to the respiratory system: the respiratory bud, in later stages respiratory tree, and the lung mesenchyme. In this stage 13 (28-32 days) embryo only the respiratory bud, which is derived from the endodermal part of the foregut, is present.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(RespiratoyBudText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel1_room4 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y)); 
			string ThyroidGlandText= "Thyroid Gland\n\nThe thyroid gland is one of the largest endocrine glands in the human body. It appears as an epithelial proliferation at the basis of the tongue in the floor of the pharynx in stage 13 (28-32 days). This epithelial proliferation will subsequently descent caudally towards the neck as a bilobed diverticulum. Its migrational path lies ventral of the hyoid bone and the laryngeal cartilages. The thyroid gland reaches its final destination in front of the trachea in stage 17 (42-44 days) approximately. By then it gains its typical ‘butterfly’ shape with a median isthmus, pointing cranially, towards the path of migration, and two slim lateral lobes, but it remains connected with the tongue by a narrow canal, the thyroglossal duct. This duct regresses in stage 15 (35-38 days) and 16 (37-42 days).\n\nThyroid hormone production will reach clinical significant levels at about 18 weeks of development (Pescovitz and Eugster, Pediatric  mechanisms endocrinology ,  manifestations and management, 2004, page 493).\n\nClinical information (Thyroid gland)\nThyroglossal cysts\nThe persistent thyroglossal duct or the existence of thyroglossal cysts is the most common clinically significant anomaly of the thyroid gland. Segments of the thyroglossal duct that did not regress properly can give rise to cysts, filled with clear mucinous secretions. These cystic remnants of the thyroglossal duct follow the migrational path of the thyroid gland and can thus be found ventral of the trachea in the midline of the neck or at the base of the tongue. These benign cysts are rarely larger then 2 to 3 centimeters in diameter and can occur at any age. Cysts close to the thyroid gland are often lined by epithelium resembling the thyroidal acinar epithelium, whereas cysts that are situated closer to the basis of the tongue are more often lined with stratified squamous epithelium, just as the basis of the tongue. Approximately 1% of the cysts give rise to thyroglossal duct carcinomas (Chou et al. 2012).\n\nAberrant thyroid tissue\nPost mortem studies suggested that 7 to 10% of the adults harbor asymptomatic aberrant thyroid tissue along the migratory path of the thyroid gland (Sauk, 1970). This thyroid tissue can be found anywhere along the thyroglossal duct, but the lingual thyroid is the most common type, accounting for 90% of the cases (Ibrahim and Fadeyibi, 2011). The majority of patients are asymptomatic, but in rare cases patients suffer from the size and location of the ectopic gland and from clinically evident thyroid dysfunction.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(ThyroidGlandText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel1_room5 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y));  
			string LeverText= "Liver\n\nLiver, biliary ducts and gallbladder develop from the hepatic diverticulum. It originates from the ventral part of the caudal foregut that develops into the proximal part of the duodenum. It rapidly grows as epithelial liver cords into the mesenchyme of the septum transversum, which, in fact, is the ventral mesentery. The expanding liver soon occupies most of the peritoneal cavity. It remains connected with the ventral body wall through the falciform ligament.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(LeverText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel2_room1 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y));  
			string CoelomText= "Coelom\n\nThe coelom develops in the lateral mesoderm, by the confluence of coelomic vesicles. These vesicles appear in between the two layers of the lateral mesoderm, the somatic mesodermal layer facing the body wall, and the splanchnic mesodermal layer, facing the visceral organs. In this stage 13 (28-32 days) the coelom consists of the pericardial cavity, two pericardioperitoneal canals, a peritoneal cavity and a pneumato-enteric recess. The coelomic cavities are filled with a clear fluid and are lined with a mesodermal derived serous epithelium. Organs that are formed within the coelom can freely move and are covered by a thin visceral layer (visceral peritoneum), whereas the parietal peritoneum lines the body wall.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(CoelomText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel2_room2 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y));  
			string HeartText= "Heart\n\nThe heart derives from a horse-shoe shaped cardiogenic region in the cranial part of the visceral mesoderm. Along with the continuous folding of the embryonic disc the heart tube forms in the third week of development and moves ventral to the foregut. Appreciate that the cardiogenic region, or forming heart tube, is part of the coelomic wall and, therefore, is not covered with epicardium, but lies so to speak “naked” in the pericardial cavity. First at later stages the myocardium becomes covered with epicardium. The initial straight heart tube grows not by proliferation, but by addition of cells at both its venous and its arterial pole, loops to the right, and atrial and ventricular chambers form by local waves of proliferation.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(HeartText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel2_room3 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y));  
			string VeinsText= "Arteries and Veins\n\nThe cardiovascular system comprises the heart, blood vessels and blood cells. It is the first system to function in the beginning of the fourth week of development, as the rapid growth of the embryo necessitates efficient nutrient supply and waste disposal. The development of the vascular system initiates during the second and third week of development in the wall of the yolk sac with the differentiation of blood cells and vessels, as the organs that produce blood cells in the formed body have not yet developed. Slightly later, cardiac muscle develops around the primitive vitelline veins that extend from the yolk sac to the embryo. The vitelline arteries become the superior mesenteric artery.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(VeinsText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel2_room4 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y));  
			string SomitesText= "Somites\n\nA somite is one of a series of paired segmental blocks of condensed paraxial mesoderm that lies at both sides of the notochord. They give rise to the vertebral column, muscles and associated connective tissues. Somites develop in cranial to caudal fashion, which implies that the most caudal somites have not even developed when the most cranial somites already are falling apart differentiating into sclerotomes (which will form the axial skeleton around the notochord) and dermomyotomes, each of which later will separate into a dermatome, forming the subcutaneous tissues and a myotome, giving origin to the skeletal muscles. Throughout the stages, the human embryo will develop a total of approximately 35 somite pairs.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(SomitesText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel2_room5 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y));  
			string MesoText= "Urogenital ridge\n\nThe intermediate mesoderm gives rise to the urogenital ridge, a solid, unsegmented mass of mesenchymal tissue, from which the excretory organs and their ducts develops. The urinary part of the urogenital ridge, known as the nephrogenic cord, differentiates progressively from the cervical to the caudal region and cleaves into nephrotomes. The most cranial segments collectively constitute the pronephros in amphibians and fish, the intermediate segments the mesonephros, and the most caudal part of the urogenital ridge constitutes the metanephros. In higher vertebrate embryos, a pronephros proper is not present.The urinary component of the urogenital ridge is called the nephrogenic cord, which gives rise to the mesonephros in stage 12 (26-30 days) and the metanephros in stage 14 (31-35 days) and their ducts, the mesonephric duct and the ureter respectively.\n\nMesonephros\nThe mesonephros is formed in all vertebrates. It serves as the adult kidney in anamniotes, but degenerates during development of the amniotes, which, in turn, develop a more complex metanephros (Wessely and Tran, 2011). The mesonephros develops during stage 12 (26-30 days) in a craniocaudal sequence. It is a functional structure in human embryos and serves as the excretory embryonic kidney. Later on it also degenerates in a craniocaudal sequence from the 5th to 12th weeks of gestational age.\n\nMesonephric duct\nThe excretory duct of the mesonephros develops in craniocaudal fashion from the cervical region towards the cloaca. In the stage 13 (28-32 days) embryo the mesonephric duct does not reach the cloaca yet. It contributes to the metanephros by forming the ureteric bud in stage 14 (31-35 days). The mesonephric duct mostly degenerates in females, but in males the ductus epididymis, ductus deferens and seminal vesicles are derived from it.\n\nGonadal ridge\nIn this stage 13 embryo (28-32 days) the gonadal ridge can morphologically be clearly discerned from the nephrogenic cord. These two ridges will proliferate and differentiate subsequent to the arrival of the primordial germ cells, which arise during gastrulation and can initially be found in the wall of the yolk sac close to the allantois, from where they migrate towards the gonadal ridges to form the primitive sexual cords. Until the 6th week of development, the gonads have the same morphological appearance in females and males.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(MesoText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel3_room1 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y));  
			string EyeText= "Eye\n\nThe first sign of eye development can be seen in stage 11 (23-26 days) embryos, as grooves on the lateral sides of the cranial neural tube. The optic vesicle develops as lateral outpocketing from the wall of the forebrain, the prosencephalon. The wall of the optic vesicle therefore consists of neural ectoderm that surrounds the cavity of the optic vesicle, which is still part of the lumen of the neural tube. The part of the optic vesicle that lays in the direct proximity of the surface ectoderm induces this ectoderm to form the lens. This first stage of lens development is typically for a stage 13 embryo (28-32 days). In stage 14 (31-35 days), the lens placode invaginates towards the optic cup, giving the optic vesicle the shape of a cup (optic cup) and in stage 15 (35-38 days) the lens is completely loose from the surface ectoderm and after detaching it becomes almost completely embraced by the optic cup. In the final situation, the optic cup gives rise to the pigment and neural layers of the retina and the optic stalk, also commonly known as optic nerve. Before complete closure of the optic stalk and the retina, the hyaloid artery becomes enclosed in the optic cup. This artery will nourish the developing lens and will fully regress before birth.\n\nTechnical reconstruction information:\nIn human embryos the ectodermal thickening of the lens placode is not that obvious as one would expect and is therefore difficult to annotate morphologically. However, for educational purposes we have added a round lens placode to the reconstruction of stage 13 (28-32 days), since stage 14 (31-35 days) already shows an invagination of the lens. Note that the borders of these lens placodes are subject to discussion.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(EyeText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel3_room2 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y));  
			string OticVesicleText= "Otic Vesicle\n\nThe first sign of ear development is the appearance of an otic pit in the surface ectoderm, lateral of the rhombencephalon in stage 11 (23-26 days). This otic pit invaginates from the surface ectoderm towards the neural tube and forms the otic vesicle, as can be appreciated in stage 12 (26-30 days) and in this stage 13 (28-32 days) embryo. This otic vesicle will give rise to the semicircular ducts, cochlea, utricle, saccule, endolymphatic duct and endolymphatic sac.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(OticVesicleText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel3_room3 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y));  
			string NeuralTubeNervesText= "Nervous system\n\nThe nervous system receives information through a complex network of afferent neurons, integrates this information in brain and ganglia, and acts through efferent neurons upon the outer world. The nervous system can be subdivided into the central nervous system (CNS) and the peripheral nervous system (PNS). The CNS consists of brain and spinal cord and is derived from the neural tube. The lumen of the neural tube is transformed into the ventricular system of the brain and the central canal of the spinal cord. The PNS consists of cranial, spinal and autonomic ganglia, and cranial and spinal nerves. The sensory components of the PNS are derived from the neural crest, except the sensory cells of ear and nose that are derived from ectodermal placodes at the lateral side of the body. The muscles of the body are innervated by axons directly growing from the neural tube. They form the motor component of the PNS.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(NeuralTubeNervesText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel3_room4 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y));  
			string SkinText= "Skin\n\nThe integumentary system encompasses the skin (epidermis and dermis), tooth, hairs, nails, nipples and the mammary glands. The skin consists of two layers; the superficial layer, the ectodermal epidermis and a deep layer, the mesodermal dermis. Also ectodermal neural crest-derived melanocytes contribute to the integument. On the surface of this embryo a couple of structures are already recognizable; the somites, the pharyngeal arches, the upper and lower limb buds and the curvature of the heart.\n\nClinical information (Skin): \nThe ‘harlequin fetus’ (ichthyosis congenita) is the rare and most severe case of the genetic skin disorder ichthyosis, due to excessive keratinization of the skin. These fetuses show a heavily cracked skin with fissures, which limits the child’s movement and even respiration. Also, because of the tight appearance of the skin, the eyes, ears and appendages such as the penis can be abnormally contracted. Adult patients suffering from less severe types of ichthyosis show a cracked, dry and thickened skin. \n\nTechnical reconstruction information:\nThe label ‘skin’ includes the embryonic skin, but also some extra-embryonic structures such as the umbilical cord. Note that the umbilical cord has in fact no dermal lining. We were unable to reconstruct both layers of the skin (epidermis and dermis) because distinguishing the two layers on the histological sections of this embryo was too difficult. Therefore, we display in our reconstructions the skin as one layer.";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(SkinText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
		if(inLevel3_room5 == true && InfoClicked == true){
			GUILayout.BeginArea ( new Rect(Screen.width - 330, Screen.height - Screen.height + 310, InfoTextSize.x,InfoTextSize.y));  
			string RathesPouchText= "Rathke's Pouch\n\nThe Pituitary gland or hypophysis is formed from two parts: the adenohypophysis and the neurohypophysis. The adenohypophysis develops from the ectoderm of the roof of the oral cavity known as Rathke’s pouch, whereas the neurohypophysis is an outgrowth of the bottom of the ventral part of the diencephalon, the hypothalamus. Rathke’s pouch is already present in this stage, whilst the first appearance of the neurohypophysis is in stage 15 (35-38 days).";
			scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
			GUILayout.Label(RathesPouchText, "textfield", GUILayout.ExpandHeight (false));
			GUILayout.EndScrollView();
			GUILayout.EndArea();    
		}
	}
	
	void  OnTriggerEnter ( Collider other  ){
		if(other.gameObject.tag == "Level1_room1"){
			inLevel1_room1 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level1_room1"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				VentralDorsalPancreas.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room1"));
				foreach(GameObject false_l1_r1_1 in false_level1_room1){
					Destroy(false_l1_r1_1);
				} 
				
			}
			if(answerCount == 1){
				VentralDorsalPancreas.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room1"));
				foreach(GameObject false_l1_r1_2 in false_level1_room1){
					Destroy(false_l1_r1_2);
				} 
				
			}
			else if(answerCount >= 2){
				VentralDorsalPancreas.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room1"));
				foreach(GameObject false_l1_r1_3 in false_level1_room1){
					Destroy(false_l1_r1_3);
				} 
				
			}
		}
		if(other.gameObject.tag == "false_level1_room1"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level1_room1.position.x,0,targetPosition_level1_room1.position.z) ;
			//mainCamera.transform.position.z = targetPosition_level1_room1.position.z;
			this.transform.position = targetPosition_level1_room1.position;
			GameObject teleportParlvl1r1 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0))as GameObject;
			teleportParlvl1r1.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl1r1.transform.position -= new Vector3(0,10,0);;
			shakeScript.Shake();
		}
		if(other.gameObject.tag == "Level1_room2"){
			inLevel1_room2 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level1_room2"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				VitellineDuct.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room2"));
				foreach(GameObject false_l1_r2_1 in false_level1_room2){
					Destroy(false_l1_r2_1);
					
				}
			}
			if(answerCount == 1){
				VitellineDuct.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room2"));
				foreach(GameObject false_l1_r2_2 in false_level1_room2){
					Destroy(false_l1_r2_2);
				}
			}
			else if(answerCount >= 2){
				VitellineDuct.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room2"));
				foreach(GameObject false_l1_r2_3 in false_level1_room2){
					Destroy(false_l1_r2_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level1_room2"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level1_room2.position.x,0,targetPosition_level1_room2.position.z);
			//mainCamera.transform.position.z = targetPosition_level1_room2.position.z;
			this.transform.position = targetPosition_level1_room2.position;
			GameObject teleportParlvl1r2 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0))as GameObject;
			teleportParlvl1r2.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl1r2.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
		if(other.gameObject.tag == "Level1_room3"){
			inLevel1_room3 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level1_room3"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				RespiratoryBud.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room3"));
				foreach(GameObject false_l1_r3_1 in false_level1_room3){
					Destroy(false_l1_r3_1);
				}
			}
			if(answerCount == 1){
				RespiratoryBud.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room3"));
				foreach(GameObject false_l1_r3_2 in false_level1_room3){
					Destroy(false_l1_r3_2);
				}
			}
			else if(answerCount >= 2){
				RespiratoryBud.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room3"));
				foreach(GameObject false_l1_r3_3 in false_level1_room3){
					Destroy(false_l1_r3_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level1_room3"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level1_room3.position.x,0,targetPosition_level1_room3.position.z);
		//	mainCamera.transform.position.z = targetPosition_level1_room3.position.z;
			this.transform.position = targetPosition_level1_room3.position;
			GameObject teleportParlvl1r3 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0))as GameObject;
			teleportParlvl1r3.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl1r3.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
		if(other.gameObject.tag == "Level1_room4"){
			inLevel1_room4 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level1_room4"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				ThyroidGland.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room4"));
				foreach(GameObject false_l1_r4_1 in false_level1_room4){
					Destroy(false_l1_r4_1);
				}
			}
			if(answerCount == 1){
				ThyroidGland.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room4"));
				foreach(GameObject false_l1_r4_2 in false_level1_room4){
					Destroy(false_l1_r4_2);
				}
			}
			else if(answerCount >= 2){
				ThyroidGland.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room4"));
				foreach(GameObject false_l1_r4_3 in false_level1_room4){
					Destroy(false_l1_r4_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level1_room4"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level1_room4.position.x,0,targetPosition_level1_room4.position.z);
			//mainCamera.transform.position.z = targetPosition_level1_room4.position.z;
			this.transform.position = targetPosition_level1_room4.position;
			GameObject teleportParlvl1r4 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0)) as GameObject;
			teleportParlvl1r4.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl1r4.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
		if(other.gameObject.tag == "Level1_room5"){
			inLevel1_room5 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level1_room5"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				Liver.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room5"));
				foreach(GameObject false_l1_r5_1 in false_level1_room5){
					Destroy(false_l1_r5_1);
				}
			}
			if(answerCount == 1){
				Liver.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room5"));
				foreach(GameObject false_l1_r5_2 in false_level1_room5){
					Destroy(false_l1_r5_2);
				}
			}
			else if(answerCount >= 2){
				Liver.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level1_room5"));
				foreach(GameObject false_l1_r5_3 in false_level1_room5){
					Destroy(false_l1_r5_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level1_room5"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level1_room5.position.x,0,targetPosition_level1_room5.position.z);
		//	mainCamera.transform.position.z = targetPosition_level1_room5.position.z;
			this.transform.position = targetPosition_level1_room5.position;
			GameObject teleportParlvl1r5 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0)) as GameObject;
			teleportParlvl1r5.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl1r5.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
		
		if(other.gameObject.tag == "Level2_room1"){
			inLevel2_room1 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level2_room1"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				Coelom.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room1"));
				foreach(GameObject false_l2_r1_1 in false_level2_room1){
					Destroy(false_l2_r1_1);
				}
			}
			if(answerCount == 1){
				Coelom.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room1"));
				foreach(GameObject false_l2_r1_2 in false_level2_room1){
					Destroy(false_l2_r1_2);
				}
			}
			else if(answerCount >= 2){
				Coelom.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room1"));
				foreach(GameObject false_l2_r1_3 in false_level2_room1){
					Destroy(false_l2_r1_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level2_room1"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level2_room1.position.x,0,targetPosition_level2_room1.position.z);
			//mainCamera.transform.position.z = targetPosition_level2_room1.position.z;
			this.transform.position = targetPosition_level2_room1.position;
			GameObject teleportParlvl2r1 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0))as GameObject;
			teleportParlvl2r1.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl2r1.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
		if(other.gameObject.tag == "Level2_room2"){
			inLevel2_room2 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level2_room2"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				Heart.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room2"));
				foreach(GameObject false_l2_r2_1 in false_level2_room2){
					Destroy(false_l2_r2_1);
				}
			}
			if(answerCount == 1){
				Heart.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room2"));
				foreach(GameObject false_l2_r2_2 in false_level2_room2){
					Destroy(false_l2_r2_2);
				}
			}
			else if(answerCount >= 2){
				Heart.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room2"));
				foreach(GameObject false_l2_r2_3 in false_level2_room2){
					Destroy(false_l2_r2_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level2_room2"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level2_room2.position.x,0,targetPosition_level2_room2.position.z);
			//mainCamera.transform.position.z = targetPosition_level2_room2.position.z;
			this.transform.position = targetPosition_level2_room2.position;
			GameObject teleportParlvl2r2 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0))as GameObject;
			teleportParlvl2r2.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl2r2.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
		if(other.gameObject.tag == "Level2_room3"){
			inLevel2_room3 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level2_room3"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				Veins.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room3"));
				foreach(GameObject false_l2_r3_1 in false_level2_room3){
					Destroy(false_l2_r3_1);
				}
			}
			if(answerCount == 1){
				Veins.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room3"));
				foreach(GameObject false_l2_r3_2 in false_level2_room3){
					Destroy(false_l2_r3_2);
				}
			}
			else if(answerCount >= 2){
				Veins.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room3"));
				foreach(GameObject false_l2_r3_3 in false_level2_room3){
					Destroy(false_l2_r3_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level2_room3"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level2_room3.position.x,0,targetPosition_level2_room3.position.z);
//			mainCamera.transform.position.z = targetPosition_level2_room3.position.z;
			this.transform.position = targetPosition_level2_room3.position;
			GameObject teleportParlvl2r3 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0))as GameObject;
			teleportParlvl2r3.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl2r3.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
		if(other.gameObject.tag == "Level2_room4"){
			inLevel2_room4 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level2_room4"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				Somites.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room4"));
				foreach(GameObject false_l2_r4_1 in false_level2_room4){
					Destroy(false_l2_r4_1);
				}
			}
			if(answerCount == 1){
				Somites.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room4"));
				foreach(GameObject false_l2_r4_2 in false_level2_room4){
					Destroy(false_l2_r4_2);
				}
			}
			else if(answerCount >= 2){
				Somites.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room4"));
				foreach(GameObject false_l2_r4_3 in false_level2_room4){
					Destroy(false_l2_r4_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level2_room4"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level2_room4.position.x,0,targetPosition_level2_room4.position.z);
//			mainCamera.transform.position.z = targetPosition_level2_room4.position.z;
			this.transform.position = targetPosition_level2_room4.position;
			GameObject teleportParlvl2r4 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0)) as GameObject;
			teleportParlvl2r4.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl2r4.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
		if(other.gameObject.tag == "Level2_room5"){
			inLevel2_room5 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level2_room5"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				UrogenitalRidge.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room5"));
				foreach(GameObject false_l2_r5_1 in false_level2_room5){
					Destroy(false_l2_r5_1);
				}
			}
			if(answerCount == 1){
				UrogenitalRidge.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room5"));
				foreach(GameObject false_l2_r5_2 in false_level2_room5){
					Destroy(false_l2_r5_2);
				}
			}
			else if(answerCount >= 2){
				UrogenitalRidge.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level2_room5"));
				foreach(GameObject false_l2_r5_3 in false_level2_room5){
					Destroy(false_l2_r5_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level2_room5"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level2_room5.position.x,0,targetPosition_level2_room5.position.z);
//			mainCamera.transform.position.z = targetPosition_level2_room5.position.z;
			this.transform.position = targetPosition_level2_room5.position;
			GameObject teleportParlvl2r5 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0))as GameObject;
			teleportParlvl2r5.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl2r5.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
		
		if(other.gameObject.tag == "Level3_room1"){
			inLevel3_room1 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level3_room1"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				LensPlacodeOpticVesticle.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room1"));
				foreach(GameObject false_l3_r1_1 in false_level3_room1){
					Destroy(false_l3_r1_1);
				}
			}
			if(answerCount == 1){
				LensPlacodeOpticVesticle.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room1"));
				foreach(GameObject false_l3_r1_2 in false_level3_room1){
					Destroy(false_l3_r1_2);
				}
			}
			else if(answerCount >= 2){
				LensPlacodeOpticVesticle.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room1"));
				foreach(GameObject false_l3_r1_3 in false_level3_room1){
					Destroy(false_l3_r1_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level3_room1"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level3_room1.position.x,0,targetPosition_level3_room1.position.z);
//			mainCamera.transform.position.z = targetPosition_level3_room1.position.z;
			this.transform.position = targetPosition_level3_room1.position;
			GameObject teleportParlvl3r1 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0))as GameObject;
			teleportParlvl3r1.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl3r1.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
		if(other.gameObject.tag == "Level3_room2"){
			inLevel3_room2 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level3_room2"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				OticVesicle.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room2"));
				foreach(GameObject false_l3_r2_1 in false_level3_room2){
					Destroy(false_l3_r2_1);
				}
			}
			if(answerCount == 1){
				OticVesicle.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room2"));
				foreach(GameObject false_l3_r2_2 in false_level3_room2){
					Destroy(false_l3_r2_2);
				}
			}
			else if(answerCount >= 2){
				OticVesicle.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room2"));
				foreach(GameObject false_l3_r2_3 in false_level3_room2){
					Destroy(false_l3_r2_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level3_room2"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level3_room2.position.x,0,targetPosition_level3_room2.position.z);
//			mainCamera.transform.position.z = targetPosition_level3_room2.position.z;
			this.transform.position = targetPosition_level3_room2.position;
			GameObject teleportParlvl3r2 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0))as GameObject;
			teleportParlvl3r2.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl3r2.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
		if(other.gameObject.tag == "Level3_room3"){
			inLevel3_room3 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level3_room3"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				Neuraltube.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room3"));
				foreach(GameObject false_l3_r3_1 in false_level3_room3){
					Destroy(false_l3_r3_1);
				}
			}
			if(answerCount == 1){
				Neuraltube.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room3"));
				foreach(GameObject false_l3_r3_2 in false_level3_room3){
					Destroy(false_l3_r3_2);
				}
			}
			else if(answerCount >= 2){
				Neuraltube.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room3"));
				foreach(GameObject false_l3_r3_3 in false_level3_room3){
					Destroy(false_l3_r3_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level3_room3"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level3_room3.position.x,0,targetPosition_level3_room3.position.z);
//			mainCamera.transform.position.z = targetPosition_level3_room3.position.z;
			this.transform.position = targetPosition_level3_room3.position;
			GameObject teleportParlvl3r3 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0))as GameObject;
			teleportParlvl3r3.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl3r3.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
		if(other.gameObject.tag == "Level3_room4"){
			inLevel3_room4 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level3_room4"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				Skin.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room4"));
				foreach(GameObject false_l3_r4_1 in false_level3_room4){
					Destroy(false_l3_r4_1);
				}
			}
			if(answerCount == 1){
				Skin.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room4"));
				foreach(GameObject false_l3_r4_2 in false_level3_room4){
					Destroy(false_l3_r4_2);
				}
			}
			else if(answerCount >= 2){
				Skin.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room4"));
				foreach(GameObject false_l3_r4_3 in false_level3_room4){
					Destroy(false_l3_r4_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level3_room4"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level3_room4.position.x,0,targetPosition_level3_room4.position.z);
//			mainCamera.transform.position.z = targetPosition_level3_room4.position.z;
			this.transform.position = targetPosition_level3_room4.position;
			GameObject teleportParlvl3r4 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0))as GameObject;
			teleportParlvl3r4.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl3r4.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
		if(other.gameObject.tag == "Level3_room5"){
			inLevel3_room5 = true;
			inventory.InventoryOn = false;
			InfoClicked = false;
		}
		if(other.gameObject.tag == "correct_level3_room5"){
			GetComponent<AudioSource>().PlayOneShot(correctAnswerSound);
			if(answerCount == 0){
				RathkesPouch.gameObject.SetActive(true);
				Scores.Score += 10;
				textFeedbackHoog();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room5"));
				foreach(GameObject false_l3_r5_1 in false_level3_room5){
					Destroy(false_l3_r5_1);
				}
			}
			if(answerCount == 1){
				RathkesPouch.gameObject.SetActive(true);
				Scores.Score += 5;
				textFeedbackLaag();
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room5"));
				foreach(GameObject false_l3_r5_2 in false_level3_room5){
					Destroy(false_l3_r5_2);
				}
			}
			else if(answerCount >= 2){
				RathkesPouch.gameObject.SetActive(true);
				Scores.Score += 0;
				answerCount = 0;
				Destroy(other.gameObject);
				Destroy(GameObject.FindGameObjectWithTag("Level3_room5"));
				foreach(GameObject false_l3_r5_3 in false_level3_room5){
					Destroy(false_l3_r5_3);
				}
			}
		}
		if(other.gameObject.tag == "false_level3_room5"){
			GetComponent<AudioSource>().PlayOneShot(falseAnswerSound);
			answerCount ++;
			fade.fadeIn();
			fade.boolfadeIn = true;
			fade.alpha = 1.0f;
			mainCamera.transform.position = new Vector3(targetPosition_level3_room5.position.x,0,targetPosition_level3_room5.position.z);
//			mainCamera.transform.position.z = targetPosition_level3_room5.position.z;
			this.transform.position = targetPosition_level3_room5.position;
			GameObject teleportParlvl3r5 = Instantiate(teleportParticle, this.gameObject.transform.position, Quaternion.Euler(0,0,0))as GameObject;
			teleportParlvl3r5.gameObject.transform.parent = this.gameObject.transform;
			teleportParlvl3r5.transform.position -= new Vector3(0,10,0);
			shakeScript.Shake();
		}
	}
	
	void  OnTriggerExit ( Collider other  ){
		
		if(other.gameObject.tag == "Level1_room1"){
			inLevel1_room1 = false;
		}
		
		if(other.gameObject.tag == "Level1_room2"){
			inLevel1_room2 = false;
		}
		if(other.gameObject.tag == "Level1_room3"){
			inLevel1_room3 = false;
		}
		if(other.gameObject.tag == "Level1_room4"){
			inLevel1_room4 = false;
		}
		if(other.gameObject.tag == "Level1_room5"){
			inLevel1_room5 = false;
		}
		
		if(other.gameObject.tag == "Level2_room1"){
			inLevel2_room1 = false;
		}
		if(other.gameObject.tag == "Level2_room2"){
			inLevel2_room2 = false;
		}
		if(other.gameObject.tag == "Level2_room3"){
			inLevel2_room3 = false;
		}
		if(other.gameObject.tag == "Level2_room4"){
			inLevel2_room4 = false;
		}
		if(other.gameObject.tag == "Level2_room5"){
			inLevel2_room5 = false;
		}
		
		if(other.gameObject.tag == "Level3_room1"){
			inLevel3_room1 = false;
		}
		if(other.gameObject.tag == "Level3_room2"){
			inLevel3_room2 = false;
		}
		if(other.gameObject.tag == "Level3_room3"){
			inLevel3_room3 = false;
		}
		if(other.gameObject.tag == "Level3_room4"){
			inLevel3_room4 = false;
		}
		if(other.gameObject.tag == "Level3_room5"){
			inLevel3_room5 = false;
		}
	}
	IEnumerator  textFeedbackHoog (){
		textContainer10.gameObject.SetActive(true);
		yield return new WaitForSeconds(3.0f); // Wait for 3 seconds then destroy the gameObject and its children
		textContainer10.gameObject.SetActive(false);
	}
	IEnumerator  textFeedbackLaag (){
		textContainer5.gameObject.SetActive(true);
		yield return new WaitForSeconds(3.0f); // Wait for 3 seconds then destroy the gameObject and its children
		textContainer5.gameObject.SetActive(false);
	}
	IEnumerator  textFeedbackEen (){
		textContainer1.gameObject.SetActive(true);
		yield return new WaitForSeconds(3.0f); // Wait for 3 seconds then destroy the gameObject and its children
		textContainer1.gameObject.SetActive(false);
	}
	
}