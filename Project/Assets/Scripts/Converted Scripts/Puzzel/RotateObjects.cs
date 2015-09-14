// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
// Do test the code! You usually need to change a few small bits.

using UnityEngine;
using System.Collections;

public class RotateObjects : MonoBehaviour {
	//How quickly to rotate the object.
	float sensitivityX = 150;
	float sensitivityY = 150;
	bool  mousePressed = false;
	//Camera that acts as a point of view to rotate the object relative to.
	Transform referenceCamera;

	public GameObject textContainerPlus;
	public GameObject textContainerMin;
	public GameObject textContainerZero;
	
	//The script in Start() is executed before Update(), so we can use it to
	//doublecheck our variables have valid values before we try to run the script in Update().
	void  Start (){
		//Ensure the referenceCamera variable has a valid value before letting this script run.
		//If the user didn't set a camera manually, try to automatically assign the scene's Main Camera.
		if (!referenceCamera) {
			if (!Camera.main) {
				Debug.LogError("No Camera with 'Main Camera' as its tag was found. Please either assign a Camera to this script, or change a Camera's tag to 'Main Camera'.");
				Destroy(this);
				return;
			}
			referenceCamera = Camera.main.transform;
		}
	}
	
	//Update() is called once every frame, and should be used to run script that
	//should be doing something constantly. In this case, we potentially want to
	//rotate the object constantly if the user is always moving the mouse.
	void  Update (){
		if(Time.timeScale != 0){
			Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray,out hit)){
				if(hit.collider.tag == "RotatePuzzel" && Input.GetMouseButton(0)){
					mousePressed = true;
				}
			}
			if(mousePressed == true){
				//Get how far the mouse has moved by using the Input.GetAxis().
				float rotationX = Input.GetAxis("Mouse X") * sensitivityX;
				float rotationY = Input.GetAxis("Mouse Y") * sensitivityY;
				
				//Rotate the object around the camera's "up" axis, and the camera's "right" axis.
				transform.Rotate( referenceCamera.up         , -Mathf.Deg2Rad * rotationX );
				transform.Rotate( referenceCamera.right      ,  Mathf.Deg2Rad * rotationY );

			}
			if(Input.GetMouseButtonUp(0)){
				mousePressed = false;
			}
		}
	} 		
		public IEnumerator  textFeedbackPlus (){
		textContainerPlus.gameObject.SetActive(true);
		yield return new WaitForSeconds(3.0f); // Wait for 3 seconds then destroy the gameObject and its children
		textContainerPlus.gameObject.SetActive(false);
	}
	public IEnumerator  textFeedbackMin (){
		textContainerMin.gameObject.SetActive(true);
		yield return new WaitForSeconds(3.0f); // Wait for 3 seconds then destroy the gameObject and its children
		textContainerMin.gameObject.SetActive(false);
	}
	public IEnumerator  textFeedbackZero (){
		textContainerZero.gameObject.SetActive(true);
		yield return new WaitForSeconds(3.0f); // Wait for 3 seconds then destroy the gameObject and its children
		textContainerZero.gameObject.SetActive(false);
	}
	
	public IEnumerator  WaitTime (){
		yield return new WaitForSeconds(3.0f); // Wait for 3 seconds then destroy the gameObject and its children
		textContainerPlus.gameObject.SetActive(false);
	}
}