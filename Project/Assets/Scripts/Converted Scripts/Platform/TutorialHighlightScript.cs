// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class TutorialHighlightScript : MonoBehaviour {
	
	float timing;
	void  Start (){
		timing = 0;
	}
	
	void  Update (){
		HighLight();
	}
	IEnumerator  HighLight (){
		timing+=Time.deltaTime;
		if(timing > 0.5f){
			GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
			yield return new WaitForSeconds(0.5f);
			timing = 0;
		}
		if(timing == 0){
			GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
		}
	}
}