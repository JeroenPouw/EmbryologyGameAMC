// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class FadeInScript : MonoBehaviour {
	public Texture2D fadeOutTexture;
	public float fadeSpeed= 0.3f; 
	int drawDepth= -1000;
	public bool  boolfadeIn = false;
	public float alpha= 1.0f; 
	private float fadeDir= -1;
	
	public void  fadeIn (){
		fadeDir = -1;	
	}
	public void  fadeOut (){
		fadeDir = 1;
	}
	
	void  OnGUI (){
		GUI.depth = 1;
		if(boolfadeIn == true){
			alpha += fadeDir * fadeSpeed * Time.deltaTime;	
			alpha = Mathf.Clamp01(alpha);	
			GUI.color = new Color() { a = alpha};
			GUI.depth = drawDepth;
			GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
		}
	}
}