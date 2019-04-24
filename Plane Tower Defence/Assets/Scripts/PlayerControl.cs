using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	
	public Stats S;
	
	void Start () {
		S = GetComponentInParent<Stats>();
	}
	
	void Update () {
		
		GetComponent<Rigidbody>().velocity = (transform.forward * (new Vector2(SSInput.LVert[S.Player], SSInput.LHor[S.Player]).magnitude*10*Time.deltaTime)) + new Vector3 (0, GetComponent<Rigidbody>().velocity.y, 0);
		if (new Vector2 (GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.z).magnitude > 0.05f) {
			transform.localEulerAngles = new Vector3 (0, Camera.main.transform.eulerAngles.y + (Mathf.Atan2(SSInput.LHor[S.Player], SSInput.LVert[S.Player])*Mathf.Rad2Deg), 0);
			GetComponent<Animator>().SetBool("Moving", true);
		} else {
			GetComponent<Animator>().SetBool("Moving", false);
		}
	}
}
