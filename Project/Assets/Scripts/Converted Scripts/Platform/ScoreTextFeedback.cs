// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class ScoreTextFeedback : MonoBehaviour {
	
	
	Color textColor;
	
	private Vector3 originalScale;
	

	void  Awake (){
		
		GetComponent<Renderer>().material.color = textColor;
		textColor.a = 1.0f;

	}
	
	void  Update (){
		textColor.a -= 0.1f * Time.deltaTime * 5; // Fade away text, last number dictates how fast to fade, higher = faster
		StartCoroutine(LerpScale(2.0f)); // Time to take to Lerp to new size in seconds
	}
	
	IEnumerator  LerpScale ( float time  ){
		Vector3 targetScale = originalScale + new Vector3(0.5f, 0.5f, 0.5f); // New size to expand text to
		float originalTime = time;
		while (time > 0.0f)
		{
			time -= Time.deltaTime;
			transform.localScale = Vector3.Lerp(targetScale, originalScale, time / originalTime);
			yield return 0;
		}
	}
	
}