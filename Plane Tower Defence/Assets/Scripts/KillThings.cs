using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThings : MonoBehaviour {
	
	public int TowerNumber;
	public float Health = 25;
	public bool isTimed;
	
	void Update () {
		if (!isTimed) {
			if (Health <= 0) {
				Invoke ("Kill", 0);
			}
		} else {
			Invoke("Kill", Health);
		}
	}
	
	void Kill () {
		if (tag == "Tower Base") {
			foreach (Stats G in GameObject.FindObjectsOfType<Stats>()) {
				if (TowerNumber == G.Player) {
					G.Towers.Remove (gameObject);
				}
			}
		}
		Destroy(gameObject);
	}
}
