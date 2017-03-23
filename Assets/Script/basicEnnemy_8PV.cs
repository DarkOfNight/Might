using UnityEngine;
using System.Collections;

public class basicEnnemy_8PV : MonoBehaviour {

	int PV=8;

	void OnTriggerEnter2D(Collider2D col){
		switch (col.gameObject.tag) {
		case "TirJoueur1PV":
			PV -= 1;
			break;
		case "TirJoueur2PV":
			PV -= 2;
			break;
		case "TirJoueur3PV":
			PV -= 3;
			break;
		case "TirJoueur4PV":
			PV -= 4;
			break;
		case "TirJoueur5PV":
			PV -= 5;
			break;
		case "TirJoueur6PV":
			PV -= 6;
			break;
		case "TirJoueur7PV":
			PV -= 7;
			break;
		case "TirJoueur8PV":
			PV -= 8;
			break;
		}
	}

	void Update(){
		if(Time.timeScale == 0)return;
		if (PV <= 0)
			Destroy (gameObject);
	
	}
}
