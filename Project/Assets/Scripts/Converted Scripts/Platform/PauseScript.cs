// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	GUISkin skin;
	
	private float gldepth= -0.5f;
	private float startTime= 0.1f;
	
	private float tris= 0;
	private float verts= 0;
	private float savedTimeScale;
	private bool pauseFilter;
	private int toolbarInt=0;
	private string[] toolbarStrings = new string[3] {"Audio","Graphics","System"};
	private int[] intString = new int[15] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
	PlayerInventory TheTextures;
	GameObject start;
	
	
	public Color statColor = Color.yellow;
	
	enum Page {
		None,Main,Options,Menu
	}
	
	private Page currentPage;
	private int[] fpsarray;
	private float fps;
	
	void  Start (){
		fpsarray = new int[Screen.width];
		TheTextures = gameObject.GetComponent<PlayerInventory>();
	}
	
	static bool IsDashboard (){
		return Application.platform == RuntimePlatform.OSXDashboardPlayer;
	}
	
	static bool  IsBrowser (){
		return (Application.platform == RuntimePlatform.WindowsWebPlayer ||
		        Application.platform == RuntimePlatform.OSXWebPlayer);
	}
	
	void  LateUpdate (){
		if (Input.GetKeyDown("escape")) {
			switch (currentPage) 
			{
				
			case Page.None: 
				PauseGame(); 
				break;
				
			case Page.Main: 
				if (!IsBeginning()) 
					UnPauseGame(); 
				break;
				
			default: 
				currentPage = Page.Main;
				break;

			}
		}
	}
	
	void  OnGUI (){
		GUIStyle labelStyle = GUI.skin.label;
		GUI.skin.label.fontSize = 14;
		if (skin != null) {
			GUI.skin = skin;
		}
		if (IsGamePaused()) {
			GUI.color = statColor;
			switch (currentPage) {
			case Page.Main: PauseMenu(); break;
			case Page.Options: ShowToolbar(); break;
			case Page.Menu: ShowMenu(); break;
			}
		}	
	}

	
	void  ShowToolbar (){
		BeginPage(300,300);
		toolbarInt = GUILayout.Toolbar (toolbarInt, toolbarStrings);
		switch (toolbarInt) {
		case 0: VolumeControl(); break;
		case 2: ShowDevice(); break;
		case 1: Qualities(); QualityControl(); break;
		}
		EndPage();
	}
	
	void  ShowMenu (){
		UnPauseGame();
		PlayerInventory.itemPlayersAmount = intString;
		Application.LoadLevel(0);
	}
	
	void  ShowBackButton (){
		if (GUI.Button( new Rect(20,Screen.height-50,50,20),"Back")) {
			currentPage = Page.Main;
		}
	}
	
	
	void  ShowDevice (){
		GUILayout.Label ("Unity player version "+Application.unityVersion);
		GUILayout.Label("Graphics: "+SystemInfo.graphicsDeviceName+" "+
		                SystemInfo.graphicsMemorySize+"MB\n"+
		                SystemInfo.graphicsDeviceVersion+"\n"+
		                SystemInfo.graphicsDeviceVendor);
		GUILayout.Label("Shadows: "+SystemInfo.supportsShadows);
		GUILayout.Label("Image Effects: "+SystemInfo.supportsImageEffects);
		GUILayout.Label("Render Textures: "+SystemInfo.supportsRenderTextures);
	}
	
	void  Qualities (){
		GUILayout.Label(QualitySettings.names[QualitySettings.GetQualityLevel()]);
	}
	
	void  QualityControl (){
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Decrease")) {
			QualitySettings.DecreaseLevel();
		}
		if (GUILayout.Button("Increase")) {
			QualitySettings.IncreaseLevel();
		}
		GUILayout.EndHorizontal();
	}
	
	void  VolumeControl (){
		GUILayout.Label("Volume");
		AudioListener.volume = GUILayout.HorizontalSlider(AudioListener.volume,0.0f,1.0f);
	}
	
	void  BeginPage (int width,int height){
		GUILayout.BeginArea( new Rect((Screen.width-width)/2,(Screen.height-height)/2,width,height));
	}
	
	void  EndPage (){
		GUILayout.EndArea();
		if (currentPage != Page.Main) {
			ShowBackButton();
		}
	}
	
	bool  IsBeginning (){
		return Time.time < startTime;
	}
	
	
	void  PauseMenu (){
		BeginPage(200,200);
		if (GUILayout.Button (IsBeginning() ? "Play" : "Continue")) {
			UnPauseGame();
			
		}
		if (GUILayout.Button ("Options")) {
			currentPage = Page.Options;
		}
		if (GUILayout.Button ("Back to menu")) {
			currentPage = Page.Menu;
		}
		
		EndPage();
	}
	
	void  GetObjectStats (){
		verts = 0;
		tris = 0;
		GameObject[] ob = FindObjectsOfType(typeof(GameObject)) as GameObject[];
		foreach(GameObject obj in ob) {
			GetObjectStats(obj);
		}
	}
	
	void  GetObjectStats (GameObject gobj){
		Component[] filters;
		filters = gobj.GetComponentsInChildren<MeshFilter>();
		foreach( MeshFilter f in filters )
		{
			tris += f.sharedMesh.triangles.Length/3;
			verts += f.sharedMesh.vertexCount;
		}
	}
	
	void  PauseGame (){
		savedTimeScale = Time.timeScale;
		Time.timeScale = 0;
		AudioListener.pause = true;
		// if (pauseFilter) 
		//     pauseFilter.enabled = true;
		currentPage = Page.Main;
	}
	
	void  UnPauseGame (){
		Time.timeScale = savedTimeScale;
		AudioListener.pause = false;
		// if (pauseFilter) 
		// pauseFilter.enabled = false;
		
		currentPage = Page.None;
		
		if (IsBeginning() && start != null) {
			start.active = true;
		}
	}
	
	bool  IsGamePaused (){
		return Time.timeScale==0;
	}
	
	void  OnApplicationPause ( bool pause  ){
		if (IsGamePaused()) {
			AudioListener.pause = true;
		}
	}
}