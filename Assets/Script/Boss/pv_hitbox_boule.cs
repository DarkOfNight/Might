using UnityEngine;
using System.Collections;

public class pv_hitbox_boule : MonoBehaviour {

	int PV=15;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col){
		switch (col.gameObject.tag) {
			case "TirJoueur1PV":
				PV -= 1;
				StartCoroutine (flash ());
				break;
			case "TirJoueur2PV":
				PV -= 2;
			StartCoroutine (flash ());
			break;
			case "TirJoueur3PV":
				PV -= 3;
			StartCoroutine (flash ());
			break;
			case "TirJoueur4PV":
				PV -= 4;
			StartCoroutine (flash ());
			break;
			case "TirJoueur5PV":
				PV -= 5;
			StartCoroutine (flash ());
			break;
			case "TirJoueur6PV":
				PV -= 6;
			StartCoroutine (flash ());
			break;
			case "TirJoueur7PV":
				PV -= 7;
			StartCoroutine (flash ());
			break;
			case "TirJoueur8PV":
				PV -= 8;
			StartCoroutine (flash ());
			break;
		}
	}

	void Update(){
		if (PV <= 0) {
			gameObject.GetComponentInParent<pv_papatte> ().PV_papatte -= 1;
			Destroy (gameObject);
		}
	}

	IEnumerator flash() {
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0.5f, 0.5f, 1f);
		yield return new WaitForSeconds(0.1f);
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
	}

}
