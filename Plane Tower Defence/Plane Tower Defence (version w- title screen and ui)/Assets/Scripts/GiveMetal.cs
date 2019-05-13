using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveMetal : MonoBehaviour {
	
	public bool isMetal;
	
	public Stats[] St;
	public bool drop;
	
	public GameObject Metal;
	
	void Start () {
		if (isMetal) {
			St = GameObject.FindObjectsOfType<Stats>();
		}
	}
	
	void Update () {
		if (!isMetal) {
			if (drop) {
				GameObject G = Instantiate (Metal, transform.position+(Vector3.up*10), Quaternion.Euler (Vector3.zero));
				G.GetComponent<Rigidbody>().AddForce (Random.Range (-1000.0f, 1000.0f), Random.Range (500.0f, 1000.0f), Random.Range (-1000.0f, 1000.0f));
				G.GetComponent<Rigidbody>().AddTorque (Random.Range (-1000.0f, 1000.0f), Random.Range (-1000.0f, 1000.0f), Random.Range (-1000.0f, 1000.0f));
				drop = false;
			}
		}
	}
	
	void OnTriggerEnter (Collider Hit) {
		if (Hit.GetComponentInParent<Stats>()) {
			if (Hit.name == "Test Human") {
				for (int i = 0; i < St.Length; i++) {
					if (Hit.GetComponentInParent<Stats>() == St[i]) {
						++St[i].ScrapMetal;
						Destroy (gameObject);
					}
				}
			}
		}
	}
}
