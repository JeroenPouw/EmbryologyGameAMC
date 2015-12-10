using UnityEngine;
using System.Collections;

public class CanvasImageMover : MonoBehaviour {

	// Use this for initialization

	public RectTransform[] storyimages = new RectTransform[3];
	public bool clickspamskip = false;
	public float speed;

	private Vector3[] originalposition = new Vector3[3]; // this is not necessary if previous slide is not implemented

	private bool movingimage = false;
	private uint stage = 1;
	private Vector3 goal; // goal of vector 0,0,0 is not taking into account the canvas coordinates

	void Start () {
		for(int i = 0; i < originalposition.Length; i++) {
			originalposition[i] = storyimages[i].position; //delete if previous slide is not implemented
			storyimages[i].localScale = this.GetComponentInParent<RectTransform>().lossyScale;
		//	storyimages[i]
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
			goal = originalposition[stage+1];
			movingimage = true;
			stage--;
			break;
		case 3:
			goal = originalposition[stage+1];
			movingimage = true;
			stage--;
			break;
		}
	}

	public void ProgressStory()
	{
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

	/*
	 * Moves the image childs of the Canvas to a certain goal.
	 * This goal is in local position so when the images in unity
	 * are set at 0,0,0 that's where they will be. If goal is set to
	 * 0,0,0 they will move to that position. 
	 */
	void MovingRect(RectTransform _mover, Vector3 _goal)
	{
		if ((_goal-_mover.transform.localPosition).magnitude < speed * Time.deltaTime)
		{
			_mover.transform.Translate(_goal-_mover.transform.localPosition);
			movingimage = false;
		}
		else
		{
			_mover.transform.Translate((_goal-_mover.transform.localPosition).normalized * speed * Time.deltaTime);
		}
	}
}
