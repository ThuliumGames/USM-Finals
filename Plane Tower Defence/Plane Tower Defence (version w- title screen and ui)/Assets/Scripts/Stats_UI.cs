using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats_UI : MonoBehaviour {

    public Stats stats;
    public Text ScrapMetalDisplay;
    public Text AmmoDisplay;
    public Text TowerHealthDisplay; 

    public void Update()
    {
        ScrapMetalDisplay.text = "Scrap Metal:" + stats.ScrapMetal;
        AmmoDisplay.text = "Ammo:" + stats.Ammo;
  
    }

}
