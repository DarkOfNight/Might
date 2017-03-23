using UnityEngine;
using System.Collections;

public class TirPulse_trajectoire : MonoBehaviour {
	private int couleur;

	void Start(){
		couleur = GameObject.Find ("Vaisseau_Pulse(Clone)").GetComponent<Tir_Allie> ().passifmight;
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Ennemi_base" || col.gameObject.tag == "hitbox_boss") {
			Destroy (gameObject);
		}
	}

	void Update () {
		if(Time.timeScale == 0)return;
		gameObject.transform.Translate (new Vector3 (0, 220f) * Time.deltaTime);
		gameObject.transform.localScale += new Vector3 (0.3f, 0);
		if (gameObject.name=="Tir_Pulse(Clone)")
			gameObject.GetComponent<SpriteRenderer>().color = new Color (0.5f+0.1f*couleur,0.25f+0.125f*couleur,0.5f+0.1f*couleur,0.75f+0.075f*couleur);
	}
}
