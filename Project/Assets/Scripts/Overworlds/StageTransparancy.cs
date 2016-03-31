using UnityEngine;
using System.Collections;

public class StageTransparancy : MonoBehaviour {

	public MeshRenderer[] meshes;

	public void MakeStageOpaque () {
		for (int i = 0; i < meshes.GetLength(0); i++) {
			MakeOrganOpaque(i);
		}
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
		if (meshes [_organ-1].material.color.a == 1f) {
			MakeOrganTransparant(_organ-1);
		} else {
			MakeOrganOpaque (_organ-1);
		}
	}
}
