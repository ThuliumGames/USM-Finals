using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	void Update () {
		
		GetComponent<Rigidbody>().velocity = (transform.forward * (new Vector2(SSInput.LVert[0], SSInput.LHor[0]).magnitude*10*Time.deltaTime)) + new Vector3 (0, GetComponent<Rigidbody>().velocity.y, 0);
		if (new Vector2 (GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.z).magnitude > 0.05f) {
			transform.localEulerAngles = new Vector3 (0, Camera.main.transform.eulerAngles.y + (Mathf.Atan2(SSInput.LHor[0], SSInput.LVert[0])*Mathf.Rad2Deg), 0);
			GetComponent<Animator>().SetBool("Moving", true);
		} else {
			GetComponent<Animator>().SetBool("Moving", false);
		}
	}
}
