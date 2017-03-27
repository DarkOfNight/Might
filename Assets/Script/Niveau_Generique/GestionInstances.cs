using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionInstances : MonoBehaviour {

	// Liste exaustif des Ennemis
	public GameObject[] Ennemis, Boss;
	public int nbVague = 1;
	public int countVague = 0;

	// Tableaux NbVagues/Niveaux  [chapitre,niveau]
	int[,] VaguesNiveau = {{0}, {9}};    // [0,niveau] -> Tuto		[>0, niveau] -> Chapitre


	// Positionnement Possible des Ennemis à leurs créations   [x,y]
	Vector2[,] QuadrillagePosition = new Vector2[7,7]; //TODO à compléter

	/* Implémentation des vagues  [x,y,vague,a]
	 * a=0    rien->0		boss->1		ennemi->2
	 * a=1	  Nombre vaisseau
	 * a=2	  N° du vaisseau / Ennemis
	 * a=3	  Réapparait tant que les autres Ennemis ne sont pas morts (quota a1) oui->1 non->0
	 * a=5	  ID du mouvement
	 */
	Object[,,,] QuadrillageVague = null;

	void Awake () {
		//Recupération via le niveau et VaguesNiveau
		string[] infoLevel = PlayerPrefs.GetString ("Player.PlayLevel", "001.001").Split('.');   // [0]-> Chapitre   [1]-> Level       Chapitre0 -> Tuto
		nbVague = VaguesNiveau [int.Parse(infoLevel[0]), int.Parse(infoLevel[1])-1];
		QuadrillageVague = new Object[7, 7, nbVague, 5];

		//Remplissage QuadrillageVague
		RemplissageQuadrillage(int.Parse(infoLevel[0]), int.Parse(infoLevel[1]));
	}

	void RemplissageQuadrillage(int chapitre, int level) {
		//Recherche fichier texte -> Dossier /Assets/Chapitre/<<int.chapitre>>/<<int.level>>.level

		/* Composition fichier
		 * 
		 * ligne -> [x,*****]
		 * dans la ligne : 	entrechaque ';' -> [**, y, *******]
		 * 									entrechaque ',' -> [******, aX,*****] : 
		 *                					format : "a0,a1,a2,a3,a4;a0,a1,a2,a3,a4;*****;*******
		 * 
		 * 
		 * si ligne = "***" -> new vague  -> [******, vague, *****]
		 * 
		 * 
		 */

		//TODO à compléter
	}


	//TODO gérance vague actuelle, lancement insstances etc...
}
