// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class InventoryGUI : MonoBehaviour {
	//Private Variables
	public bool InventoryOn= false;
	private Vector2 scrollBarChopGrid = Vector2.zero;
	private int GridValue = -1;
	GUISkin mySkin;
	
	//GUI Pos/Size
	Vector2 ClosePosition = new Vector2(290,8);
	Vector2 CloseSize = new Vector2(40,40);
	Vector2 NamePosition = new Vector2(125,13);
	Vector2 NameSize = new Vector2(250,250);
	Vector2 HelpPosition = new Vector2(10,260);
	Vector2 HelpSize = new Vector2(355,250);
	Vector2 TextPosition = new Vector2(345,143);
	Vector2 TextSize = new Vector2(430, 425);
	Vector2 GridPosition = new Vector2(10,60);
	Vector2 GridSize = new Vector2(320,200);
	Vector2 WindowPosition = new Vector2(10,150);
	Vector2 WindowSize = new Vector2(340,340);
	//Textures
	Texture InventoryWindow;
	Texture CloseIcon;
	public GUIContent[] Grids;
	Vector2 scrollPosition = Vector2.zero;
	LevelInfo levelinfoScript;
	InventoryAddItem AddingNewItem;
	//levelinfoScript = FindObjectOfType(typeof(LevelInfo));

	void Awake(){
		AddingNewItem = GetComponent<InventoryAddItem>();
		levelinfoScript = gameObject.GetComponent<LevelInfo>();
	}
	void  Update (){
		//On or Off
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			if (InventoryOn == false)
			{
				InventoryOn = true;
				levelinfoScript.infoClicked = false;
			}
			else if (InventoryOn == true)
			{
				InventoryOn = false;
			}
		}
		AddingNewItem.newItem();
	}
	
	public void  OnGUI (){
		Texture GridIcon = new Texture();
		GridIcon = Resources.Load("Textures/Grid_Icon", typeof(Texture2D))as Texture2D;
		Texture VentralDorsalPancreas = new Texture ();
		VentralDorsalPancreas = Resources.Load("ObjectsIcons/00_Ventral&DorsalPancreas", typeof(Texture2D))as Texture2D;
		Texture VitellineDuct = new Texture ();
		VitellineDuct = Resources.Load("ObjectsIcons/01_VitellineDuct", typeof(Texture2D))as Texture2D;
		Texture RespiratoyBud = new Texture ();
		RespiratoyBud = Resources.Load("ObjectsIcons/02_RespiratoyBud", typeof(Texture2D))as Texture2D;
		Texture ThyroidGland = new Texture ();
		ThyroidGland = Resources.Load("ObjectsIcons/03_ThyroidGland", typeof(Texture2D))as Texture2D;
		Texture Lever = new Texture ();
		Lever = Resources.Load("ObjectsIcons/04_Lever", typeof(Texture2D))as Texture2D;
		Texture Coelom = new Texture ();
		Coelom = Resources.Load("ObjectsIcons/05_Coelom", typeof(Texture2D))as Texture2D;
		Texture Heart = new Texture ();
		Heart = Resources.Load("ObjectsIcons/06_Heart", typeof(Texture2D))as Texture2D;
		Texture Veins = new Texture ();
		Veins = Resources.Load("ObjectsIcons/07_Veins", typeof(Texture2D))as Texture2D;
		Texture Somites = new Texture ();
		Somites = Resources.Load("ObjectsIcons/08_Somites", typeof(Texture2D))as Texture2D;
		Texture MesonephrosMesonphericDuctGonodalRidge = new Texture();
		MesonephrosMesonphericDuctGonodalRidge = Resources.Load("ObjectsIcons/09_MesonephrosMesonphericDuctGonodalRidge", typeof(Texture2D))as Texture2D;
		Texture LensPlacodeOpticVesticle = new Texture();
		LensPlacodeOpticVesticle = Resources.Load("ObjectsIcons/10_LensPlacodeOpticVesticle", typeof(Texture2D))as Texture2D;
		Texture OticVesicle = new Texture();
		OticVesicle = Resources.Load("ObjectsIcons/11_OticVesicle", typeof(Texture2D))as Texture2D;
		Texture RathesPouch = new Texture();
		RathesPouch = Resources.Load("ObjectsIcons/12_RathesPouch", typeof(Texture2D))as Texture2D;
		Texture Skin = new Texture();
		Skin = Resources.Load("ObjectsIcons/13_Skin", typeof(Texture2D))as Texture2D;
		Texture NeuralTubeNerves = new Texture();
		NeuralTubeNerves = Resources.Load("ObjectsIcons/14_NeuralTubeNerves", typeof(Texture2D))as Texture2D;
		
		GUI.skin = mySkin;
		if (InventoryOn == true)
		{
			GUI.BeginGroup(new Rect(WindowPosition.x, WindowPosition.y, WindowSize.x, WindowSize.y), InventoryWindow);
			//Name
			GUI.Label( new Rect(NamePosition.x, NamePosition.y, NameSize.x, NameSize.y), "Inventory");
			GUI.Label( new Rect(HelpPosition.x, HelpPosition.y, HelpSize.x, HelpSize.y), "Click on an item for more information");
			//Close Button
			if (GUI.Button( new Rect(ClosePosition.x, ClosePosition.y, CloseSize.x, CloseSize.y), CloseIcon))
			{
				GUI.Label( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y),"");
				InventoryOn = false;    
			}
			GridValue = GUI.SelectionGrid( new Rect(GridPosition.x, GridPosition.y, GridSize.x, GridSize.y), GridValue, Grids, 5);
			GUI.EndGroup();
			
			if(GridValue >= 0 && Grids[GridValue].image == GridIcon){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string NoInfoText= "No information can be given";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(NoInfoText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == VentralDorsalPancreas){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string VentralDorsalText= "Ventral and Dorsal Pancreas\n\nThe pancreas originates from two buds, which originate during stage 13 (28-32 days) in the caudal part of the foregut that develops into the proximal part of the duodenum. They expand into the septum transversum as the ventral and dorsal pancreatic buds. The dorsal pancreatic bud directly develops from the duodenal endoderm, whereas the ventral pancreatic bud originates from the proximal part of the hepatic diverticulum. Owing to the rotation of the duodenum the ventral bud comes to lie in the dorsal mesentery and fuses with the dorsal bud. The ventral bud forms the uncinate process and part of the pancreatic head. The remainder of the pancreas is derived from the dorsal bud. The definitive pancreatic duct derives from the ventral pancreas and drains off at the major duodenal papilla, whereas the drainage duct of the dorsal pancreas anastomoses with the ventral pancreatic duct and loses its original connection between the dorsal pancreas and the duodenum. It may persist as an accessory pancreatic duct that opens at the minor duodenal papilla.\n\nClinical information (Pancreas)\nAnnular pancreas\nWhen the merging process of both pancreatic buds partly fails, an annular pancreas can arise. In this anomaly, the ventral pancreatic bud lies (in part) around the duodenum following the embryonic pathway of migration, whereas it should be completely fused with the dorsal pancreatic bud after its migration. The hedgehoc signaling pathway seems to play a major part in this anomaly (Etienne et al., 2012). The incidence is 1 in every 1000 individuals (Etienne et al., 2012). These patients can suffer from symptoms of duodenal obstruction and therefore surgical intervention with bypass procedures might be necessary.\n\nAccessory pancreatic duct\nWhen there is no complete fusion of both pancreatic ducts, the accessory pancreatic duct from the dorsal pancreatic bud can remain in contact with the duodenum. An accessory pancreatic duct occurs in 5-10 % of the western population (Kamisawa, 2004). This is of clinical importance especially when an endoscopic retrograde cholangiopancreatography (ERCP) has to be performed in patients suffering from an obstruction due to gallstones for example.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(VentralDorsalText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == VitellineDuct){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string VitelinneDuctText= "Vitelline Duct\n\nThe vitelline duct is the remaining connection between the midgut and the remnant of the yolk sac. This duct will go into regression during the embryonic period.\n\nClinical information (Vitelline duct)\nWhen the vitelline duct persists, remnants of this duct can be found as a diverticulum of the ileum, the so-called Meckel’s diverticulum. Or a vitelline cyst can be present, attached with fibrous cords (vitelline ligaments) to the umbilicus and the wall of the ileum. A vitelline fistula directly connects the lumen of the ileum with the umbilicus leaving an open connection between the lumen of the gut and ‘the outside world’.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(VitelinneDuctText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == RespiratoyBud){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string RespiratoyBudText= "Respiratoy Bud\n\nThe respiratory system, or ventilatory system, is designed for gas exchange. The complete system comprises of airways, lungs and respiratory muscles which enable us to ventilate, thereby permitting passive gas exchange of oxygen and carbon dioxide between the air in the alveoli and the blood within the capillary bed surrounding them. The respiratory bud or lung bud derives from the foregut and has therefore an endodermal origin. During the embryonic period the respiratory bud develops into the respiratory tree, surrounded by mesodermal derived lung mesenchyme. At the end of the embryonic period the lungs and their separate lobes are easily recognizable, but further maturation during the fetal period is of extreme importance to the well-functioning of the lungs. Pre-term births often lead to infants with under-developed lungs because of the lack of surfactant. Surfactant lowers the surface tension within the alveoli, hereby preventing them from collapsing and ensuring gas exchange.\n\nTechnical reconstruction information:\nIn this model we assigned two labels to the respiratory system: the respiratory bud, in later stages respiratory tree, and the lung mesenchyme. In this stage 13 (28-32 days) embryo only the respiratory bud, which is derived from the endodermal part of the foregut, is present.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(RespiratoyBudText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea(); 
			}
			if(GridValue >= 0 && Grids[GridValue].image == ThyroidGland){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string ThyroidGlandText= "Thyroid Gland\n\nThe thyroid gland is one of the largest endocrine glands in the human body. It appears as an epithelial proliferation at the basis of the tongue in the floor of the pharynx in stage 13 (28-32 days). This epithelial proliferation will subsequently descent caudally towards the neck as a bilobed diverticulum. Its migrational path lies ventral of the hyoid bone and the laryngeal cartilages. The thyroid gland reaches its final destination in front of the trachea in stage 17 (42-44 days) approximately. By then it gains its typical ‘butterfly’ shape with a median isthmus, pointing cranially, towards the path of migration, and two slim lateral lobes, but it remains connected with the tongue by a narrow canal, the thyroglossal duct. This duct regresses in stage 15 (35-38 days) and 16 (37-42 days).\n\nThyroid hormone production will reach clinical significant levels at about 18 weeks of development (Pescovitz and Eugster, Pediatric  mechanisms endocrinology ,  manifestations and management, 2004, page 493).\n\nClinical information (Thyroid gland)\nThyroglossal cysts\nThe persistent thyroglossal duct or the existence of thyroglossal cysts is the most common clinically significant anomaly of the thyroid gland. Segments of the thyroglossal duct that did not regress properly can give rise to cysts, filled with clear mucinous secretions. These cystic remnants of the thyroglossal duct follow the migrational path of the thyroid gland and can thus be found ventral of the trachea in the midline of the neck or at the base of the tongue. These benign cysts are rarely larger then 2 to 3 centimeters in diameter and can occur at any age. Cysts close to the thyroid gland are often lined by epithelium resembling the thyroidal acinar epithelium, whereas cysts that are situated closer to the basis of the tongue are more often lined with stratified squamous epithelium, just as the basis of the tongue. Approximately 1% of the cysts give rise to thyroglossal duct carcinomas (Chou et al. 2012).\n\nAberrant thyroid tissue\nPost mortem studies suggested that 7 to 10% of the adults harbor asymptomatic aberrant thyroid tissue along the migratory path of the thyroid gland (Sauk, 1970). This thyroid tissue can be found anywhere along the thyroglossal duct, but the lingual thyroid is the most common type, accounting for 90% of the cases (Ibrahim and Fadeyibi, 2011). The majority of patients are asymptomatic, but in rare cases patients suffer from the size and location of the ectopic gland and from clinically evident thyroid dysfunction.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(ThyroidGlandText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == Lever){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string LeverText= "Liver\n\nLiver, biliary ducts and gallbladder develop from the hepatic diverticulum. It originates from the ventral part of the caudal foregut that develops into the proximal part of the duodenum. It rapidly grows as epithelial liver cords into the mesenchyme of the septum transversum, which, in fact, is the ventral mesentery. The expanding liver soon occupies most of the peritoneal cavity. It remains connected with the ventral body wall through the falciform ligament.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(LeverText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == Coelom){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string CoelomText= "Coelom\n\nThe coelom develops in the lateral mesoderm, by the confluence of coelomic vesicles. These vesicles appear in between the two layers of the lateral mesoderm, the somatic mesodermal layer facing the body wall, and the splanchnic mesodermal layer, facing the visceral organs. In this stage 13 (28-32 days) the coelom consists of the pericardial cavity, two pericardioperitoneal canals, a peritoneal cavity and a pneumato-enteric recess. The coelomic cavities are filled with a clear fluid and are lined with a mesodermal derived serous epithelium. Organs that are formed within the coelom can freely move and are covered by a thin visceral layer (visceral peritoneum), whereas the parietal peritoneum lines the body wall.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(CoelomText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == Heart){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string HeartText= "Heart\n\nThe heart derives from a horse-shoe shaped cardiogenic region in the cranial part of the visceral mesoderm. Along with the continuous folding of the embryonic disc the heart tube forms in the third week of development and moves ventral to the foregut. Appreciate that the cardiogenic region, or forming heart tube, is part of the coelomic wall and, therefore, is not covered with epicardium, but lies so to speak “naked” in the pericardial cavity. First at later stages the myocardium becomes covered with epicardium. The initial straight heart tube grows not by proliferation, but by addition of cells at both its venous and its arterial pole, loops to the right, and atrial and ventricular chambers form by local waves of proliferation.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(HeartText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == Veins){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string VeinsText= "Arteries and Veins\n\nThe cardiovascular system comprises the heart, blood vessels and blood cells. It is the first system to function in the beginning of the fourth week of development, as the rapid growth of the embryo necessitates efficient nutrient supply and waste disposal. The development of the vascular system initiates during the second and third week of development in the wall of the yolk sac with the differentiation of blood cells and vessels, as the organs that produce blood cells in the formed body have not yet developed. Slightly later, cardiac muscle develops around the primitive vitelline veins that extend from the yolk sac to the embryo. The vitelline arteries become the superior mesenteric artery.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(VeinsText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == Somites){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string SomitesText= "Somites\n\nA somite is one of a series of paired segmental blocks of condensed paraxial mesoderm that lies at both sides of the notochord. They give rise to the vertebral column, muscles and associated connective tissues. Somites develop in cranial to caudal fashion, which implies that the most caudal somites have not even developed when the most cranial somites already are falling apart differentiating into sclerotomes (which will form the axial skeleton around the notochord) and dermomyotomes, each of which later will separate into a dermatome, forming the subcutaneous tissues and a myotome, giving origin to the skeletal muscles. Throughout the stages, the human embryo will develop a total of approximately 35 somite pairs.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(SomitesText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == MesonephrosMesonphericDuctGonodalRidge){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string MesoText= "Urogenital ridge\n\nThe intermediate mesoderm gives rise to the urogenital ridge, a solid, unsegmented mass of mesenchymal tissue, from which the excretory organs and their ducts develops. The urinary part of the urogenital ridge, known as the nephrogenic cord, differentiates progressively from the cervical to the caudal region and cleaves into nephrotomes. The most cranial segments collectively constitute the pronephros in amphibians and fish, the intermediate segments the mesonephros, and the most caudal part of the urogenital ridge constitutes the metanephros. In higher vertebrate embryos, a pronephros proper is not present.The urinary component of the urogenital ridge is called the nephrogenic cord, which gives rise to the mesonephros in stage 12 (26-30 days) and the metanephros in stage 14 (31-35 days) and their ducts, the mesonephric duct and the ureter respectively.\n\nMesonephros\nThe mesonephros is formed in all vertebrates. It serves as the adult kidney in anamniotes, but degenerates during development of the amniotes, which, in turn, develop a more complex metanephros (Wessely and Tran, 2011). The mesonephros develops during stage 12 (26-30 days) in a craniocaudal sequence. It is a functional structure in human embryos and serves as the excretory embryonic kidney. Later on it also degenerates in a craniocaudal sequence from the 5th to 12th weeks of gestational age.\n\nMesonephric duct\nThe excretory duct of the mesonephros develops in craniocaudal fashion from the cervical region towards the cloaca. In the stage 13 (28-32 days) embryo the mesonephric duct does not reach the cloaca yet. It contributes to the metanephros by forming the ureteric bud in stage 14 (31-35 days). The mesonephric duct mostly degenerates in females, but in males the ductus epididymis, ductus deferens and seminal vesicles are derived from it.\n\nGonadal ridge\nIn this stage 13 embryo (28-32 days) the gonadal ridge can morphologically be clearly discerned from the nephrogenic cord. These two ridges will proliferate and differentiate subsequent to the arrival of the primordial germ cells, which arise during gastrulation and can initially be found in the wall of the yolk sac close to the allantois, from where they migrate towards the gonadal ridges to form the primitive sexual cords. Until the 6th week of development, the gonads have the same morphological appearance in females and males.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(MesoText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == LensPlacodeOpticVesticle){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string EyeText= "Eye\n\nThe first sign of eye development can be seen in stage 11 (23-26 days) embryos, as grooves on the lateral sides of the cranial neural tube. The optic vesicle develops as lateral outpocketing from the wall of the forebrain, the prosencephalon. The wall of the optic vesicle therefore consists of neural ectoderm that surrounds the cavity of the optic vesicle, which is still part of the lumen of the neural tube. The part of the optic vesicle that lays in the direct proximity of the surface ectoderm induces this ectoderm to form the lens. This first stage of lens development is typically for a stage 13 embryo (28-32 days). In stage 14 (31-35 days), the lens placode invaginates towards the optic cup, giving the optic vesicle the shape of a cup (optic cup) and in stage 15 (35-38 days) the lens is completely loose from the surface ectoderm and after detaching it becomes almost completely embraced by the optic cup. In the final situation, the optic cup gives rise to the pigment and neural layers of the retina and the optic stalk, also commonly known as optic nerve. Before complete closure of the optic stalk and the retina, the hyaloid artery becomes enclosed in the optic cup. This artery will nourish the developing lens and will fully regress before birth.\n\nTechnical reconstruction information:\nIn human embryos the ectodermal thickening of the lens placode is not that obvious as one would expect and is therefore difficult to annotate morphologically. However, for educational purposes we have added a round lens placode to the reconstruction of stage 13 (28-32 days), since stage 14 (31-35 days) already shows an invagination of the lens. Note that the borders of these lens placodes are subject to discussion.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(EyeText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == OticVesicle){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string OticVesicleText= "Otic Vesicle\n\nThe first sign of ear development is the appearance of an otic pit in the surface ectoderm, lateral of the rhombencephalon in stage 11 (23-26 days). This otic pit invaginates from the surface ectoderm towards the neural tube and forms the otic vesicle, as can be appreciated in stage 12 (26-30 days) and in this stage 13 (28-32 days) embryo. This otic vesicle will give rise to the semicircular ducts, cochlea, utricle, saccule, endolymphatic duct and endolymphatic sac.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(OticVesicleText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView(); 
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == RathesPouch){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string RathesPouchText= "Rathke's Pouch\n\nThe Pituitary gland or hypophysis is formed from two parts: the adenohypophysis and the neurohypophysis. The adenohypophysis develops from the ectoderm of the roof of the oral cavity known as Rathke’s pouch, whereas the neurohypophysis is an outgrowth of the bottom of the ventral part of the diencephalon, the hypothalamus. Rathke’s pouch is already present in this stage, whilst the first appearance of the neurohypophysis is in stage 15 (35-38 days).";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(RathesPouchText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == Skin){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string SkinText= "Skin\n\nThe integumentary system encompasses the skin (epidermis and dermis), tooth, hairs, nails, nipples and the mammary glands. The skin consists of two layers; the superficial layer, the ectodermal epidermis and a deep layer, the mesodermal dermis. Also ectodermal neural crest-derived melanocytes contribute to the integument. On the surface of this embryo a couple of structures are already recognizable; the somites, the pharyngeal arches, the upper and lower limb buds and the curvature of the heart.\n\nClinical information (Skin): \nThe ‘harlequin fetus’ (ichthyosis congenita) is the rare and most severe case of the genetic skin disorder ichthyosis, due to excessive keratinization of the skin. These fetuses show a heavily cracked skin with fissures, which limits the child’s movement and even respiration. Also, because of the tight appearance of the skin, the eyes, ears and appendages such as the penis can be abnormally contracted. Adult patients suffering from less severe types of ichthyosis show a cracked, dry and thickened skin. \n\nTechnical reconstruction information:\nThe label ‘skin’ includes the embryonic skin, but also some extra-embryonic structures such as the umbilical cord. Note that the umbilical cord has in fact no dermal lining. We were unable to reconstruct both layers of the skin (epidermis and dermis) because distinguishing the two layers on the histological sections of this embryo was too difficult. Therefore, we display in our reconstructions the skin as one layer.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(SkinText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
			if(GridValue >= 0 && Grids[GridValue].image == NeuralTubeNerves){
				GUILayout.BeginArea ( new Rect(TextPosition.x, TextPosition.y, TextSize.x,TextSize.y));  
				string NeuralTubeNervesText= "Nervous system\n\nThe nervous system receives information through a complex network of afferent neurons, integrates this information in brain and ganglia, and acts through efferent neurons upon the outer world. The nervous system can be subdivided into the central nervous system (CNS) and the peripheral nervous system (PNS). The CNS consists of brain and spinal cord and is derived from the neural tube. The lumen of the neural tube is transformed into the ventricular system of the brain and the central canal of the spinal cord. The PNS consists of cranial, spinal and autonomic ganglia, and cranial and spinal nerves. The sensory components of the PNS are derived from the neural crest, except the sensory cells of ear and nose that are derived from ectodermal placodes at the lateral side of the body. The muscles of the body are innervated by axons directly growing from the neural tube. They form the motor component of the PNS.";
				scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(TextSize.y), GUILayout.ExpandHeight (false));
				GUILayout.Label(NeuralTubeNervesText, "textfield", GUILayout.ExpandHeight (true));
				GUILayout.EndScrollView();
				GUILayout.EndArea();
			}
		}
	}
}