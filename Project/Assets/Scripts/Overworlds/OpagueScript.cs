using UnityEngine;
using System.Collections;

public class OpagueScript : MonoBehaviour {

	// Use this for initialization
	public Vector3 center;
	float radius = Mathf.Infinity;
	GameObject player;

	private Shader m_OldShader = null;
	private Color m_OldColor = Color.black;
	private float m_Transparency = 0.3f;
	private const float m_TargetTransparancy = 0.3f;
	private const float m_FallOff = 0.1f; // returns to 100% in 0.1 sec

	
	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	public void MakeTransparent(){
		Collider[] hitcollider = Physics.OverlapSphere (center, radius);
		foreach (Collider go in hitcollider) {
			if (go.gameObject.tag != ("nonTrans") && go.gameObject.tag != ("Player")) {
				if (go.GetComponent<Renderer>().material.color.a >= 0.8f && go.GetComponent<Renderer>().material.shader == Shader.Find("Standard")) {
					foreach (Material mat in go.GetComponent<Renderer>().materials) {
						mat.shader = Shader.Find ("Transparent/Diffuse");
						mat.color -= new Color (0, 0, 0, 0.8f);
					}
				}
			}
		}
	}

	public void MakeOpague(){
		Collider[] hitcollider = Physics.OverlapSphere (center, radius);
		foreach (Collider go in hitcollider) {
			if (go.gameObject.tag != ("nonTrans") && go.gameObject.tag != ("Player")){
			if (go.GetComponent<Renderer>().material.color.a <= 0.8f && go.GetComponent<Renderer>().material.shader == Shader.Find("Transparent/Diffuse")) {
				foreach (Material mat in go.GetComponent<Renderer>().materials) {
					mat.shader = Shader.Find ("Standard");
					mat.color += new Color (0, 0, 0, 0.8f);
				}
				}
			}
		}
	}

	void Update()
	{
		center = transform.position;
	}
}
