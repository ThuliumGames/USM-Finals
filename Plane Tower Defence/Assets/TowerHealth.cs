using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour {
	public float Health = 25;

	void Start () {
		
	}
	
	void Update () {
		if (Health == 0) {
			Destroy(gameObject);
		}
	}
}
