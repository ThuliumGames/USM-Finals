﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour {
	
	public Transform ObjToFollow;
	float UpDown = 0;
	public float Max;
	public float Min;
	public float Back;
	public float Up;
	
	public float FollowSpeed;
	
	public LayerMask LM;
	
	float Ac;
	
	Vector3 Pre;
	
	public Stats S;
	
	void Start () {
		S = GetComponentInParent<Stats>();
	}
	
	void LateUpdate () {
		
		GameObject G = new GameObject();
		G.transform.position = Vector3.Lerp (Pre, ObjToFollow.position, FollowSpeed*Time.deltaTime);
		transform.position = G.transform.position;
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
		transform.Rotate (0, ((SSInput.RHor[S.Player]*100))*Time.deltaTime, 0);
		transform.Translate (0, Up, -Back);
		transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y, 0);
		UpDown += -SSInput.RVert[S.Player]*100*Time.deltaTime;
		UpDown = Mathf.Clamp (UpDown, Min, Max);
		transform.RotateAround (ObjToFollow.position+new Vector3 (0,1,0), transform.right, UpDown);
		RaycastHit Hit;
		if (Physics.Raycast (ObjToFollow.position+(Vector3.up*Up), -transform.forward, out Hit, Back+0.5f, LM)) {
			transform.Translate (0, 0, Back-Hit.distance+0.5f);
		}
		transform.Rotate (10, 0, 0);
		Pre = G.transform.position;
		Destroy(G);
	}
}
