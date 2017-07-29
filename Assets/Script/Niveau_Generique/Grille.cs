using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
public class Grille : MonoBehaviour {

	public GameObject cam;

	public int[,,,] cadrillage = new int[255,7,7,10];
	/*
	 * 0 - type			0 normal 1 infini 2 boss
	 * 1 - image		0 ... 1 ... 2 ... ...
	 * 2 - mouvement	0 ... 1 ... 2 ... ...
	 * 3 - attaque		0 ... 1 ... 2 ... ...
	 * 4 - vie			> 0
	 * 5 - Nombre		> 0
	 * 
	 *  -1 = rien
	 */ 

	public int level = 0, chapitre = 0, vague = 0;

	public float[] positionX = new float[7],  positionY = new float[7];


	// Use this for initialization
	void Awake () {
		level = 1; //PlayerPrefs.GetInt ("Levels.CurrentLevel", -1);
		chapitre = 1; //PlayerPrefs.GetInt ("Levels.CurrentChapitre", -1);
		Debug.Log (Application.dataPath + "/Levels/" + chapitre +"-"+ level + ".lvlcrt");
		Open();
		Debug.Log (cadrillage [0, 1, 1, 0].ToString ());
	}

	public int TestCadreEmpty(){
		for (int i = 0; i < 255; i++) {
			bool empty = true;
			int[,,] var1 = GetVague (i);
			for (int j = 0; j < 7; j++)
				for (int k = 0; k < 7; k++)
						if (var1 [j, k, 0] >= 0)
							empty = false;
			if (empty)
				return i;
		}
		return 255;
	}

	public int[,,] GetVague(int var1){
		int[,,] var2 = new int[7,7,10];
		for (int j = 0; j < 7; j++)
			for (int k = 0; k < 7; k++)
				for (int l = 0; l < 10; l++)
					var2[j, k, l] =  cadrillage [var1, j, k, l];	
		return var2;
	}

	public int[] GetInfo(int var1, int var2, int var3){
		int[] var4 = new int[10];
			for (int l = 0; l < 10; l++)
				var4[l] = cadrillage [var1, var2, var3, l];
		return var4;
	}

	public int x, y;

	public void SetX(int i) {
		x = i;
	}
	public void SetY(int i) {
		y= i;
	}


	public void Open(){
		string[] inputFile = System.IO.File.ReadAllLines(Application.dataPath + "/Levels/" + chapitre +"-"+ level + ".lvlcrt");
		int v = 0;
		foreach (string line in inputFile) {
			for (int y = 0; y < 7; y++)
				for (int x = 0; x < 7; x++)
					for (int i = 0; i < 10; i++)
						cadrillage [v, y, x, i] = int.Parse( line.Split (',') [y].Split (';') [x].Split ('|') [i]);
			v++;
			if (v >= 255)
				break;
		}
	}
}
