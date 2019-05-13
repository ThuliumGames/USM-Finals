using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStuff : MonoBehaviour {
	public SwitchControl SC;
	
	void OnTriggerStay (Collider other) {
		if (other.transform == SC.Heli.transform) {
			SC.canLeave = true;
		}
		if (other.transform == SC.Person.transform) {
			SC.canReturn = true;
		}
	}
	void OnTriggerExit (Collider other) {
		SC.canLeave = false;
		SC.canReturn = false;
	}
}
