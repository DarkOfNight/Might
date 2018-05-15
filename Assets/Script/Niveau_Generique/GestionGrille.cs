using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
public class GestionGrille : MonoBehaviour {

	[Serializable]
	public class CadreInformationLevel
	{
		public string[,,] information = new string[30,7,7];
		public List<string> cadrillage_final = new List<string>();
		public DateTime creation = DateTime.UtcNow;
		public DateTime modification = DateTime.UtcNow;
		public string date_creation;
		public string date_modification;
		public int level = 0;
		public int chapitre = 0;
		public int vague = 0;

		public void FileToInfo()
		{
			this.information = new string[30,7,7];
			for (int v = 0; v < this.cadrillage_final.Capacity; v++)
			{
				int pos = 0;
				for (int i = 0; i < 7; i++)
					for (int j = 0; j < 7; j++) {
							this.information [v, i, j] = this.cadrillage_final [v].Substring (pos, 30);
							pos += 30;
						}
			}

		}

		public void FileToDate()
		{
			this.creation = DateTime.Parse(this.date_creation);
			this.modification = DateTime.Parse(this.date_modification);
		}
	}
	
	public CadreInformationLevel cadrillage = new CadreInformationLevel();
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


	// Use this for initialization
	public int TestCadreEmpty(){
		for (int i = 0; i < cadrillage.vague; i++) {
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
				var2[j, k] =  cadrillage.information [var1, j, k];	
		return var2;
	}

	public string GetInfo(int var1, int var2, int var3){
		return cadrillage.information [var1, var2, var3];
	}



	public void Open(int var1, int var2){
		string inputFile = System.IO.File.ReadAllText(Application.dataPath + "/Levels/" + var1.ToString() +"-"+ var2.ToString() + ".lvlcrt");

		cadrillage = JsonUtility.FromJson<CadreInformationLevel>(inputFile);
		cadrillage.FileToInfo ();
		cadrillage.FileToDate ();
	}
}
