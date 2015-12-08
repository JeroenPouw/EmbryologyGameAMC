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

	void Start () {
		for(int i = 0; i < originalposition.Length; i++) {
			originalposition[i] = storyimages[i].position;
		}
	}

	void Update() 
	{
		if (movingimage) {
		//	MovingRect();
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
			movingimage = true;
			stage++;
			break;
		case 2:
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
		if ((_goal-_mover.transform.position).magnitude > speed*Time.deltaTime)
		{
			_mover.Translate(_goal);
			movingimage = false;
		}
		else
		{
			_mover.Translate((_goal-_mover.transform.position).normalized * speed * Time.deltaTime);
		}
	}
}
