using UnityEngine;
using System.Collections;

public class GestionVague : MonoBehaviour
{
	/*
	 * 					-50	-35	-20	0	20	35	50
	 * 				90	0	1	2	3	4	5	6
	 * 				85	1
	 * 				70	2
	 * 				55	3
	 * 				40	4
	 * 				25	5
	 * 				10	6
	 * 
	 */

	/*
	* 0 - type			0 normal 1 infini 2 boss
	* 1 - image			0 ... 1 ... 2 ... ...
	* 2 - mouvement		0 ... 1 ... 2 ... ...
	* 3 - attaque		0 ... 1 ... 2 ... ...
	* 4 - vie			> 0
	* 5 - Nombre		> 0
	* 
	*  -1 ou "---" = rien
	*/ 

	public GameObject Scripts;
	int vague = 0;

	public string[,] grille = new string[7,7];
	public int[,] type = new int[7,7], nb = new int[7,7];

	public void InitVague(int var1){
		vague = var1;
		grille = Scripts.GetComponent<GestionGrille>().GetVague(vague);
		for (int i = 0; i < 7; i++)
			for (int j = 0; j < 7; j++)
				GameObjectsVague (i, j);
		GetInfo();
		TestVagueFinish ();
	}

	public void EnnemyDestroyed(int y, int x){
		StartCoroutine (Delete (y, x));
	}

	public IEnumerator Delete (int y, int x){
		yield return null;
		if (nb[y, x] > 0)
			nb [y, x] -= 1;
		if (nb [y, x] > 0)
			GameObjectsVague (y, x);
		else
			TestVagueFinish ();
	}

	void TestVagueFinish (){
		bool finish = true;

		if (GameObject.FindGameObjectsWithTag ("Ennemi_base").Length > 0)
			finish = false;

		for (int i = 0; i < 7; i++)// ennemi simple
			for (int j = 0; j < 7; j++)
				if (nb [i, j] > 0)
					finish = false;

		if (finish)
			Scripts.GetComponent<GestionNiveau> ().FinishVague ();

	}

	// Use this for initialization
	void GameObjectsVague (int y, int x)
	{
		Scripts.GetComponent<ConstructeurObject>().Gen(y, x, DecoupageDonnee(y, x));
	}

	void GetInfo(){
		for (int i = 0; i < 7; i++)
			for (int j = 0; j < 7; j++) {
				string var1 = grille [i, j].Substring (0*3, 3), var2 = grille [i, j].Substring (5*3, 3);
				if (var1 == "---")
					type[i, j] = -1;
				else
					type[i, j] = int.Parse(var1);
				if (var2 == "---")
					nb[i, j] = -1;
				else
					nb[i, j] = int.Parse(var2);
			}
	}

	int[] DecoupageDonnee(int y, int x)
	{
		int[] result = new int[10];
		for (int i = 0; i < 10; i++) {
			string var1 = grille [y, x].Substring (i * 3, 3);
			if (var1 == "---")
				result [i] = -1;
			else
				result [i] = int.Parse (var1);
		}
		return result;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

