using UnityEngine;
using System.Collections;

public class RadiusCheck : MonoBehaviour {
	public int score = 0;
	float time;
	// Use this for initialization
	void Start () {
		StartCoroutine (ScoreCheck ());
	}

	public IEnumerator ScoreCheck(){
		//Debug.Log ("hello");
		yield return new WaitForSeconds (1.0f);
		Collider[] Ectocollider = Physics.OverlapSphere(gameObject.transform.position,30.0f, 1<<24);
		Debug.Log (Ectocollider.Length);
		if (Ectocollider.Length >= 300) {
			score += 10;
		}else if (Ectocollider.Length < 300 || Ectocollider.Length > 450) {
			score -= 10;
		}

		yield return new WaitForSeconds (4.0f);
		StartCoroutine(ScoreCheck());
	}
	void OnGUI(){
		if (GUI.Button (new Rect (10, 10, 150, 100), "score:" + score + "\t" + time))
			;
	}
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
	}
}
