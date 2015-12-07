using UnityEngine;
using System.Collections;

public class CanvasImageMover : MonoBehaviour {

	// Use this for initialization
	public RectTransform storyimage1;
	public RectTransform storyimage2;
	public RectTransform storyimage3;
	public bool clickspamskip = false;

	private bool movingimage = false;
	private uint stage = 1;

	void Start () {

	}

	void Update() 
	{
		if (movingimage) {
			MovingRect();
		}
	}

	public void ReverseStory()
	{
		if(!movingimage || clickspamskip)
		switch (stage) {
		default:
			Debug.Log ("something went wrong");
			break;
		case 1:

			stage--;
			break;
		case 2:

			stage--;
			break;
		case 3:

			stage--;
			break;
		}
	}

	public void ProgressStory()
	{
		Debug.Log ("Itworks!");
		if(!movingimage || clickspamskip)
		switch (stage) {
		default:
			Debug.Log ("something went wrong");
			break;
		case 1:

			stage++;
			break;
		case 2:

			stage++;
			break;
		case 3:

		//	next scene needs to be loaded
			break;
		}
	}

	void MovingRect(RectTransform _mover, Vector3 _goal)
	{
		_mover.Translate((_goal-_mover.transform.position)*0.1f*Time.deltaTime);
		if (_mover.position == _goal) {
			movingimage = false;

		}
	}
}
