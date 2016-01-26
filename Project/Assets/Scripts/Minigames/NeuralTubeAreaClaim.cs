using UnityEngine;
using System.Collections;

public class NeuralTubeAreaClaim : MonoBehaviour {

	SpriteRenderer render;

	void Start () {
		render = GetComponent<SpriteRenderer> ();
		render.color = new Color(1f,1f,1f,0f);
	}

	public void Lose () {
		render.color = new Color (1f, 1f, 1f, 0f);
	}

	public void Claim () {
		render.color = new Color (1f, 1f, 1f, 1f / 2f);
	}

	public void Own () {
		render.color = new Color (1f, 1f, 1f, 1f);
	}
}
