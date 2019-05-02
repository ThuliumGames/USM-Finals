using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {
	
	public int Player;
	
	public int Ammo;
	public int Segs;
	public int HeliHealth;
	public int ScrapMetal;
	
	public GameObject Metal;
	public bool drop;
	
	void Update () {
		if (drop) {
			GameObject G = Instantiate (Metal, transform.position+(Vector3.up*10), Quaternion.Euler (Vector3.zero));
			G.GetComponent<Rigidbody>().AddForce (Random.Range (-1000.0f, 1000.0f), Random.Range (500.0f, 1000.0f), Random.Range (-1000.0f, 1000.0f));
			G.GetComponent<Rigidbody>().AddTorque (Random.Range (-1000.0f, 1000.0f), Random.Range (-1000.0f, 1000.0f), Random.Range (-1000.0f, 1000.0f));
			drop = false;
		}
	}
}
