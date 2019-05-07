using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStuff : MonoBehaviour {
	public SwitchControl SC;
	public Canvas a;
	
	void OnTriggerStay (Collider other) {
		if (other.transform == SC.Heli.transform) {
			SC.canLeave = true;
			a.enabled = true;
		}
		if (other.transform == SC.Person.transform) {
			SC.canReturn = true;
			a.enabled = true;
		}
	}
	void OnTriggerExit (Collider other) {
		SC.canLeave = false;
		SC.canReturn = false;
		a.enabled = false;
	}
}
