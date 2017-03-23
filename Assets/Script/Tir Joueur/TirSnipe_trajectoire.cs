using UnityEngine;
using System.Collections;

public class TirSnipe_trajectoire : MonoBehaviour {

	void Update () {
		if(Time.timeScale == 0)return;
		gameObject.transform.Translate (new Vector3 (0, 350f) * Time.deltaTime);
	}
}
