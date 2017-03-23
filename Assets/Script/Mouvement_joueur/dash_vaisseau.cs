using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dash_vaisseau : MonoBehaviour {
	public float largeur = 112;

	public bool invu=false;

	public bool gauche = false, droite = false;
	public Button buttonGauche, buttonDroit;

	void Start(){

		GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
		for (int i = 0; i < buttons.Length; i++) {
			if (buttons [i].name == "DashGauche")
				buttonGauche = buttons [i].GetComponent<Button>();
			if (buttons [i].name == "DashDroit")
				buttonDroit = buttons [i].GetComponent<Button>();
		}
		StartCoroutine ("Dash"+PlayerPrefs.GetString("Play.gameObjectID", "0"));
	}


	IEnumerator Dash0() { //Might
		while (true) {
			if ((Input.GetKey ("left ctrl") || gauche) && (gameObject.GetComponent<movement_base>().wall!=2)) {
				invu = true;
				buttonDroit.interactable = false;
				buttonGauche.interactable = false;
				gameObject.GetComponent<movement_base> ().isDashed = true;
				if (gameObject.transform.position.x < -largeur/6+largeur/20)
					gameObject.transform.position = (new Vector3 (-largeur/2+largeur/20, gameObject.transform.position.y));
				else
					gameObject.transform.position = (new Vector3 (gameObject.transform.position.x - largeur/3, gameObject.transform.position.y));
				gameObject.transform.GetComponent<movement_base> ().wall = 0;
				gameObject.transform.GetComponent<Tir_Allie>().passifmight = 5;
				yield return new WaitForSeconds (0.25f);
				gameObject.GetComponent<movement_base> ().isDashed = false;
				invu = false;
				yield return new WaitForSeconds (2.75f);
				buttonDroit.interactable = true;
				buttonGauche.interactable = true;
				gauche = false;
			}

			if ((Input.GetKey ("right ctrl") || droite) && (gameObject.GetComponent<movement_base>().wall!=1)) {
				invu = true;
				buttonDroit.interactable = false;
				buttonGauche.interactable = false;
				gameObject.GetComponent<movement_base> ().isDashed = true;
				if (gameObject.transform.position.x > largeur/6-largeur/20)
					gameObject.transform.position = (new Vector3 (largeur/2-largeur/20, gameObject.transform.position.y));
				else
					gameObject.transform.position = (new Vector3 (gameObject.transform.position.x + largeur/3, gameObject.transform.position.y));
				gameObject.transform.GetComponent<Tir_Allie>().passifmight = 5;
				gameObject.transform.GetComponent<movement_base> ().wall = 0;
				yield return new WaitForSeconds (0.25f);
				gameObject.GetComponent<movement_base> ().isDashed = false;
				invu = false;
				yield return new WaitForSeconds (2.75f);
				buttonDroit.interactable = true;
				buttonGauche.interactable = true;
				droite = false;
			}
			yield return new WaitForSeconds (0.0001f);
		}
	}

	IEnumerator Dash1() { //Snipe
		while (true) {
			if ((Input.GetKey ("left ctrl") || gauche) && (gameObject.GetComponent<movement_base>().wall!=2)) {
				invu = true;
				buttonDroit.interactable = false;
				buttonGauche.interactable = false;
				gameObject.GetComponent<movement_base> ().isDashed = true;
				if (gameObject.transform.position.x < -largeur/4)
					gameObject.transform.position = (new Vector3 (-largeur/2, gameObject.transform.position.y));
				else
					gameObject.transform.position = (new Vector3 (gameObject.transform.position.x - largeur/4, gameObject.transform.position.y));
				gameObject.transform.GetComponent<movement_base> ().wall = 0;
				yield return new WaitForSeconds (0.25f);
				gameObject.GetComponent<movement_base> ().isDashed = false;
				invu = false;
				yield return new WaitForSeconds (2.75f);
				buttonDroit.interactable = true;
				buttonGauche.interactable = true;
				gauche = false;
			}

			if ((Input.GetKey ("right ctrl") || droite) && (gameObject.GetComponent<movement_base>().wall!=1)) {
				invu = true;
				buttonDroit.interactable = false;
				buttonGauche.interactable = false;
				gameObject.GetComponent<movement_base> ().isDashed = true;
				if (gameObject.transform.position.x > largeur/4)
					gameObject.transform.position = (new Vector3 (largeur/2, gameObject.transform.position.y));
				else
					gameObject.transform.position = (new Vector3 (gameObject.transform.position.x + largeur/4, gameObject.transform.position.y));
				gameObject.transform.GetComponent<movement_base> ().wall = 0;
				yield return new WaitForSeconds (0.25f);
				gameObject.GetComponent<movement_base> ().isDashed = false;
				invu = false;
				yield return new WaitForSeconds (2.75f);
				buttonDroit.interactable = true;
				buttonGauche.interactable = true;
				droite = false;
			}
			yield return new WaitForSeconds (0.0001f);
		}
	}

	IEnumerator Dash2() { //Tank
		while (true) {
			if ((Input.GetKey ("left ctrl") || gauche) && (gameObject.GetComponent<movement_base>().wall!=2)) {
				invu = true;
				buttonDroit.interactable = false;
				buttonGauche.interactable = false;
				gameObject.GetComponent<movement_base> ().isDashed = true;
				if (gameObject.transform.position.x < -largeur/4)
					gameObject.transform.position = (new Vector3 (-largeur/2, gameObject.transform.position.y));
				else
					gameObject.transform.position = (new Vector3 (gameObject.transform.position.x - largeur/4, gameObject.transform.position.y));
				gameObject.transform.GetComponent<movement_base> ().wall = 0;
				yield return new WaitForSeconds (0.25f);
				gameObject.GetComponent<movement_base> ().isDashed = false;
				invu = false;
				yield return new WaitForSeconds (2.75f);
				buttonDroit.interactable = true;
				buttonGauche.interactable = true;
				gauche = false;
			}

			if ((Input.GetKey ("right ctrl") || droite) && (gameObject.GetComponent<movement_base>().wall!=1)) {
				invu = true;
				buttonDroit.interactable = false;
				buttonGauche.interactable = false;
				gameObject.GetComponent<movement_base> ().isDashed = true;
				if (gameObject.transform.position.x > largeur/4)
					gameObject.transform.position = (new Vector3 (largeur/2, gameObject.transform.position.y));
				else
					gameObject.transform.position = (new Vector3 (gameObject.transform.position.x + largeur/4, gameObject.transform.position.y));
				gameObject.transform.GetComponent<movement_base> ().wall = 0;
				yield return new WaitForSeconds (0.25f);
				gameObject.GetComponent<movement_base> ().isDashed = false;
				invu = false;
				yield return new WaitForSeconds (2.75f);
				buttonDroit.interactable = true;
				buttonGauche.interactable = true;
				droite = false;
			}
			yield return new WaitForSeconds (0.0001f);
		}
	}

	IEnumerator Dash3() { //Pulse
		while (true) {
			if ((Input.GetKey ("left ctrl") || gauche) && (gameObject.GetComponent<movement_base>().wall!=2)) {
				invu = true;
				buttonDroit.interactable = false;
				buttonGauche.interactable = false;
				gameObject.GetComponent<movement_base> ().isDashed = true;
				if (gameObject.transform.position.x < -largeur/4)
					gameObject.transform.position = (new Vector3 (-largeur/2, gameObject.transform.position.y));
				else
					gameObject.transform.position = (new Vector3 (gameObject.transform.position.x - largeur/4, gameObject.transform.position.y));
				gameObject.transform.GetComponent<movement_base> ().wall = 0;
				yield return new WaitForSeconds (0.25f);
				gameObject.GetComponent<movement_base> ().isDashed = false;
				invu = false;
				yield return new WaitForSeconds (2.75f);
				buttonDroit.interactable = true;
				buttonGauche.interactable = true;
				gauche = false;
			}

			if ((Input.GetKey ("right ctrl") || droite) && (gameObject.GetComponent<movement_base>().wall!=1)) {
				invu = true;
				buttonDroit.interactable = false;
				buttonGauche.interactable = false;
				gameObject.GetComponent<movement_base> ().isDashed = true;
				if (gameObject.transform.position.x > largeur/4)
					gameObject.transform.position = (new Vector3 (largeur/2, gameObject.transform.position.y));
				else
					gameObject.transform.position = (new Vector3 (gameObject.transform.position.x + largeur/4, gameObject.transform.position.y));
				gameObject.transform.GetComponent<movement_base> ().wall = 0;
				yield return new WaitForSeconds (0.25f);
				gameObject.GetComponent<movement_base> ().isDashed = false;
				invu = false;
				yield return new WaitForSeconds (2.75f);
				buttonDroit.interactable = true;
				buttonGauche.interactable = true;
				droite = false;
			}
			yield return new WaitForSeconds (0.0001f);
		}
	}

}