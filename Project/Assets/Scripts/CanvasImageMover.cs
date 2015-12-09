using UnityEngine;
using System.Collections;

public class CanvasImageMover : MonoBehaviour {

	// Use this for initialization

	public RectTransform[] storyimages = new RectTransform[3];
	public bool clickspamskip = false;
	public float speed;

	private Vector3[] originalposition = new Vector3[3];

	private bool movingimage = false;
	private uint stage = 1;
	private Vector3 goal; // goal of vector 0,0,0 is not taking into account the canvas coordinates

	void Start () {
		for(int i = 0; i < originalposition.Length; i++) {
			originalposition[i] = storyimages[i].position;
		}
	}

	void Update() 
	{
		if (movingimage) {
			MovingRect(storyimages[stage-1], goal);
		}
	}

	public void ReverseStory()
	{
		if(!movingimage || clickspamskip)
		switch (stage) {
		default:

			break;
		case 1:

			//going back to main menu?
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
			
			break;
		case 1:
			goal = new Vector3(0f,0f,0f);
			movingimage = true;
			stage++;
			break;
		case 2:
			goal = new Vector3(0f,0f,0f);
			movingimage = true;
			stage++;
			break;
		case 3:

		//	next scene needs to be loaded
			break;
		}
	}

	void MovingRect(RectTransform _mover, Vector3 _goal)
	{
		Debug.Log(_mover.position);
		if ((_goal-_mover.transform.position).magnitude < speed*Time.deltaTime)
		{
		//	_mover.rect.position
			_mover.transform.Translate(_goal);
			Debug.Log(_mover.position);
			Debug.Log("got to the goal");
			movingimage = false;
		}
		else
		{
			Debug.Log("moving");
			_mover.transform.Translate((_goal-_mover.transform.position).normalized * speed * Time.deltaTime);
		}
	}
}
