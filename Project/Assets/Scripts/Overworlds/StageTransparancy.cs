using UnityEngine;
using System.Collections;

public class StageTransparancy : MonoBehaviour {

	public MeshRenderer[] meshes;
	private Color[] origionalcolors;

	void Start() {
		origionalcolors = new Color[meshes.Length];
		for (int i = 0; i < meshes.GetLength(0); i++) {
			origionalcolors[i] = meshes[i].material.color;
		}
	}

	public void MakeStageOpaque () {
		for (int i = 0; i < meshes.GetLength(0); i++) {
			MakeOrganTransparant (i);
		}
	}

	public void MakeOrganOrigional (int _organ) {
		Color alphaadjust = origionalcolors [_organ];
		meshes [_organ].material.color = alphaadjust;
	}

	public void MakeOrganTransparant (int _organ) {
		Color alphaadjust = new Color(meshes[_organ].material.color.r,
		                              meshes[_organ].material.color.g,
		                              meshes[_organ].material.color.b,
		                              0f);
		meshes [_organ].material.color = alphaadjust;
	}

	public void MakeOrganOpaque (int _organ) {
		Color alphaadjust = new Color(meshes[_organ].material.color.r,
		                              meshes[_organ].material.color.g,
		                              meshes[_organ].material.color.b,
		                              1f);
		meshes [_organ].material.color = alphaadjust;
	}

	public void ToggleOpaque (int _organ) {
		int organ = _organ - 1;
		if (meshes [organ].material.color.a == 1f) {
			MakeOrganOrigional(organ);
		} else if (meshes [organ].material.color.a == 0f) {
			MakeOrganOpaque (organ);
		} else {
			MakeOrganTransparant (organ);
		}
	}
}
