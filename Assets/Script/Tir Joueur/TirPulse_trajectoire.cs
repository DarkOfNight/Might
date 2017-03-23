using UnityEngine;
using System.Collections;

public class TirPulse_trajectoire : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Ennemi_base" || col.gameObject.tag == "hitbox_boss") {
			Destroy (gameObject);
		}
	}

	void Update () {
		if(Time.timeScale == 0)return;
		gameObject.transform.Translate (new Vector3 (0, 220f) * Time.deltaTime);
		gameObject.transform.localScale += new Vector3 (0.4f, 0);
	}
}
