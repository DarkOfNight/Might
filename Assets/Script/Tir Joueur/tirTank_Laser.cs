using UnityEngine;
using System.Collections;

public class tirTank_Laser : MonoBehaviour {
	void Awake() {
		gameObject.GetComponent<RectTransform> ().localPosition = new Vector3 (50f, 0f, -200f);


	}
}
