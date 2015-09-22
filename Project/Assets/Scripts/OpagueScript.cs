using UnityEngine;
using System.Collections;

public class OpagueScript : MonoBehaviour {

	// Use this for initialization
	public Vector3 center;
	public float radius;

	private Shader m_OldShader = null;
	private Color m_OldColor = Color.black;
	private float m_Transparency = 0.3f;
	private const float m_TargetTransparancy = 0.3f;
	private const float m_FallOff = 0.1f; // returns to 100% in 0.1 sec
	
	void Start(){

	}

	
//		// reset the transparency;
//		m_Transparency = m_TargetTransparancy;
//		if (m_OldShader == null)
//		{
//			// Save the current shader
//			m_OldShader = GetComponent<Renderer>().material.shader;
//			m_OldColor  = GetComponent<Renderer>().material.color;
//			GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");
//		}

	void OnTriggerStay(Collider other)
	{
		Collider[] hitcollider = Physics.OverlapSphere (center, radius);
		foreach (Collider go in hitcollider) {
			if (go.GetComponent<Renderer>().material.color.a >= 0.5f && go.GetComponent<Renderer>().material.shader != Shader.Find("Transparent/Diffuse")) {
				go.GetComponent<Renderer> ().material.shader = Shader.Find ("Transparent/Diffuse");
				go.GetComponent<Renderer> ().material.color -= new Color (0, 0, 0, 0.5f);
			}

		}
	}

	void OnTriggerExit(Collider other)
	{
		Collider[] hitcollider = Physics.OverlapSphere (center, radius);
		foreach (Collider go in hitcollider) {
			if (go.GetComponent<Renderer>().material.color.a <= 0.5f && go.GetComponent<Renderer>().material.shader != Shader.Find("Standard")) {
				go.GetComponent<Renderer> ().material.shader = Shader.Find ("Standard");
				go.GetComponent<Renderer> ().material.color += new Color (0, 0, 0, 0.5f);
			}

		}
	}
	void Update()
	{
		center = transform.position;
//		if (m_Transparency == 1.0f)
//		{
//			Color C = GetComponent<Renderer>().material.color;
//			C.a = m_Transparency;
//			GetComponent<Renderer>().material.color = C;
//		}
//		else
//		{
//			// Reset the shader
//			GetComponent<Renderer>().material.shader = m_OldShader;
//			GetComponent<Renderer>().material.color = m_OldColor;
//			// And remove this script
//			Destroy(this);
//		}
//		m_Transparency += ((1.0f-m_TargetTransparancy)*Time.deltaTime) / m_FallOff;
	}
}
