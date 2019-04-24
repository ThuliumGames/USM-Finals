using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndParticle : MonoBehaviour {

	public float TimeToKill;
	
	void Update () {
		Invoke("Kill", TimeToKill);
	}
	void Kill() {
		Destroy(gameObject);
	}
}
