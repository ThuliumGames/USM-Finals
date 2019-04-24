using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThings : MonoBehaviour {
	
	public bool isTimed;
	public float Health = 25;
	
	void Update () {
		if (!isTimed) {
			if (Health <= 0) {
				Destroy(gameObject);
			}
		} else {
			Invoke("Kill", Health);
		}
	}
	
	void Kill () {
		Destroy(gameObject);
	}
}
