using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	
	public Canvas a;
	public Canvas Shop;
	public bool inMenu;
	public bool inRange;
	bool firstOption = true;
	public Image im;
	
	//Sorry for the horrible code Hal. Not enough time to make it good.
	void Update () {
		if (inRange) {
			if (SSInput.A[GetComponentInParent<Stats>().Player] == "Pressed") {
				Shop.enabled = !Shop.enabled;
				if (inMenu) {
					if (firstOption) {
						if (GetComponentInParent<Stats>().ScrapMetal >= 15) {
							GetComponentInParent<Stats>().ScrapMetal -= 15;
							GetComponentInParent<Stats>().Ammo += 100;
						}
					} else {
						if (GetComponentInParent<Stats>().ScrapMetal >= 25) {
							GetComponentInParent<Stats>().ScrapMetal -= 25;
							GetComponentInParent<Stats>().AddTower();
						}
					}
				}
				inMenu = !inMenu;
			}
			if (inMenu) {
				
				if (SSInput.DUp[GetComponentInParent<Stats>().Player] == "Pressed") {
					firstOption = true;
				}
				if (SSInput.DDown[GetComponentInParent<Stats>().Player] == "Pressed") {
					firstOption = false;
				}
				
				if (firstOption) {
					im.transform.localPosition = new Vector3 (-300, 50, 0);
				} else {
					im.transform.localPosition = new Vector3 (-300, -200, 0);
				}
			}
		}
	}
	
	void OnTriggerEnter (Collider Object) {
		if (Object.GetComponentInParent<Stats>().Player == GetComponentInParent<Stats>().Player) {
			a.enabled = true;
			inRange = true;
		}
	}
	
	void OnTriggerExit (Collider Object) {
		if (Object.GetComponentInParent<Stats>().Player == GetComponentInParent<Stats>().Player) {
			inRange = false;
			a.enabled = false;
			Shop.enabled = false;
			inMenu = false;
		}
	}
}
