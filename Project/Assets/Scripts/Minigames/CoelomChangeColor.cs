using UnityEngine;
using System.Collections;

public class CoelomChangeColor : MonoBehaviour {

	public Color[] presetcolors;
	private SpriteRenderer render;

	void Start () {
		render = this.GetComponent<SpriteRenderer> ();
	}

	public void ChangeColor (Color _color) {
		render.color = _color;
	}

	public void ChangeColor (float _r, float _g, float _b, float _a) {
		Color newcolor = new Color (_r, _g, _b, _a);
		render.color = newcolor;
	}

	public void ChangeColor (int _presetcolor) {
		if (presetcolors.Length > 0 && _presetcolor >= 0 && _presetcolor < presetcolors.Length) {
			render.color = presetcolors[_presetcolor];
		}
	}
}
