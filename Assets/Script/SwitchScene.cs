using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class SwitchScene : MonoBehaviour {

	public void ToDemo()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (1);
	}
	public void ToMain()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (0);
	}
	public void ToReplay()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
}
