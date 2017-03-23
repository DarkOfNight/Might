using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class menu_selection : MonoBehaviour {

	int vaisseauID = 0, vaisseauIDMax = 1;
	public Image vaisseau;
	public Sprite[] images = new Sprite[3];

	public int[] force = new int[3], vitesse = new int[3], latence = new int[3]; //TODO : Système couplage {int, int, int} utilisable sur le GUI en public!
	public RawImage[] imageForce = new RawImage[3], imageVitesse = new RawImage[3], imageLatence = new RawImage[3]; //Display des étoiles en fonction des caractéristiques
	public Texture etoileActive, etoileDesactive;


	void Start(){

		vaisseauIDMax = force.Length;

		for (int i = 0; i < force.Length; i++) {
			// Vérification des niveaux de forces, vitesses etc...
			if (force [i] < 0)
				force [i] = 0;
			else if (force [i] > 3)
				force [i] = 3;

			if (vitesse [i] < 0)
				vitesse [i] = 0;
			else if (vitesse [i] > 3)
				vitesse [i] = 3;

			if (latence [i] < 0)
				latence [i] = 0;
			else if (latence [i] > 3)
				latence [i] = 3;


			Debug.Log (vaisseauID.ToString() + " " + vaisseauIDMax.ToString());
		}

		// Initialisation des caractéristiques du vaisseau actuel
		try { vaisseauID = int.Parse(PlayerPrefs.GetString ("Play.VaisseauID", "0"));	}
		catch (Exception e) {
			Debug.Log (e);
			vaisseauID = 0;
		}
		PlayerPrefs.SetString ("Play.VaisseauID", vaisseauID.ToString());
		PlayerPrefs.Save ();
		StartCoroutine (RenderingVaisseau ());
		StartCoroutine (RenderingStatVaisseau ());
	}

	public void SwitchVaisseau(bool suivant){

		if (suivant) { // Détermination du nouveau Vaisseau Joueur
			vaisseauID++;
			if (vaisseauID >= vaisseauIDMax)
				vaisseauID = 0;
		}
		else {
			vaisseauID--;
			if (vaisseauID < 0)
				vaisseauID = vaisseauIDMax - 1;
		}

		Debug.Log (vaisseauID);

		// Setting des caractéristiques
		PlayerPrefs.SetString ("Play.VaisseauID", vaisseauID.ToString());
		PlayerPrefs.Save ();

		StartCoroutine (RenderingVaisseau ());
		StartCoroutine (RenderingStatVaisseau ());
	}

	private IEnumerator RenderingVaisseau (){
		vaisseau.sprite = images [vaisseauID];
		yield return null;
	}

	private IEnumerator RenderingStatVaisseau(){
		DisableStatDisplay (); 
		for (int i = 0; i < force[vaisseauID]; i++)
			imageForce [i].enabled = true;
		for (int i = 0; i < vitesse[vaisseauID]; i++)
			imageVitesse [i].enabled = true;
		for (int i = 0; i < latence[vaisseauID]; i++)
			imageLatence [i].enabled = true;
		yield return null;
	}

	private void DisableStatDisplay (){
		for (int i = 0; i < 3; i++) {
			imageForce [i].enabled = false;
			imageVitesse [i].enabled = false;
			imageLatence [i].enabled = false;
		}
	}

	private Texture2D textureFromSprite(Sprite sprite)
     {
         if(sprite.rect.width != sprite.texture.width){
             Texture2D newText = new Texture2D((int)sprite.rect.width,(int)sprite.rect.height);
             Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x, 
                                                          (int)sprite.textureRect.y, 
                                                          (int)sprite.textureRect.width, 
                                                          (int)sprite.textureRect.height );
             newText.SetPixels(newColors);
             newText.Apply();
             return newText;
         } else
             return sprite.texture;
     }
}
