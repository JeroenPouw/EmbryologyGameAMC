using UnityEngine;
using System.Collections;

public class CanvasImageMover : MonoBehaviour {

	// Use this for initialization

	public RectTransform[] storyimages = new RectTransform[3];
	public bool clickspamskip = false;
	public float speed;

	private Vector3[] originalposition = new Vector3[3]; // this is not necessary if previous slide is not implemented
	private RectTransform moveable;
	private bool movingimage = false;
	private uint stage = 1;
	private Vector3 goal; // goal of vector 0,0,0 is not taking into account the canvas coordinates

	/*
	 * Adjusts every child of the canvas to the resolution set.
	 */
	void Start () {
		RectTransform parent = this.GetComponentInParent<RectTransform> ();
	}

	/*
	 * When the things need to move, they need to move every frame.
	 * Hence a single check in Update() and the call of the MovingRect
	 * function.
	 */
	void Update() 
	{
		if (movingimage) {
			MovingRect(moveable, goal);
		}
	}

	/*
	 * Makes the scene reverse in story telling. 
	 * A single call is enough to reverse.
	 */
	public void ReverseStory()
	{
		if (!movingimage) {
			switch (stage) {
			default:
				moveable = storyimages [stage - 1];
				goal = originalposition [stage - 1];
				movingimage = true;
				stage--;
				break;
			case 1:

			//going back to main menu?
				break;
			}
		} else if (clickspamskip) {
			TeleportRect(moveable, goal);
		}
	}

	/*
	 * Makes the scene progress. A single call is enough to move on.
	 */
	public void ProgressStory()
	{
		if (!movingimage) {
			Application.LoadLevel(2);
		}
		else if (clickspamskip) {
			TeleportRect(moveable, goal);
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
			_mover.transform.localPosition = _goal;
			movingimage = false;
		}
		else
		{
			_mover.transform.Translate((_goal-_mover.transform.localPosition).normalized * speed * Time.deltaTime);
		}
	}

	void TeleportRect(RectTransform _mover, Vector3 _goal)
	{
		_mover.transform.localPosition = _goal; //(_goal-_mover.transform.localPosition);
		movingimage = false;
	}
}
