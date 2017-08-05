using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
public class GestionGrille : MonoBehaviour {


	public string[,,] cadrillage = new string[30,7,7];
	/*
	 * 0 - type			0 normal 1 infini 2 boss
	 * 1 - image		0 ... 1 ... 2 ... ...
	 * 2 - mouvement	0 ... 1 ... 2 ... ...
	 * 3 - attaque		0 ... 1 ... 2 ... ...
	 * 4 - vie			> 0
	 * 5 - Nombre		> 0
	 * 
	 *  -1 ou "---" = rien
	 */ 


	// Use this for initialization
	public int TestCadreEmpty(){
		for (int i = 0; i < 30; i++) {
			bool empty = true;
			string[,] var1 = GetVague (i);
			for (int j = 0; j < 7; j++)
				for (int k = 0; k < 7; k++)
					if (var1 [j, k].Substring(0, 3) != "---")
							empty = false;
			if (empty)
				return i;
		}
		return 30;
	}

	public string[,] GetVague(int var1){
		string[,] var2 = new string[7,7];
		for (int j = 0; j < 7; j++)
			for (int k = 0; k < 7; k++)
					var2[j, k] =  cadrillage [var1, j, k];	
		return var2;
	}

	public string GetInfo(int var1, int var2, int var3){
		return cadrillage [var1, var2, var3];
	}



	public void Open(int var1, int var2){
		string[] inputFile = System.IO.File.ReadAllLines(Application.dataPath + "/Levels/" + var1.ToString() +"-"+ var2.ToString() + ".lvlcrt");
		int v = 0;
		foreach (string line in inputFile) {
			for (int y = 0; y < 7; y++)
				for (int x = 0; x < 7; x++)
						cadrillage [v, y, x] = line.Split (',') [y].Split (';') [x];
			v++;
			if (v >= 30)
				break;
		}
	}
}
