using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupActions : MonoBehaviour
{
    [SerializeField]
    private PlaneBehaviour plane;
    private PlaneControl control;
    public GameObject DirtPart;
    public GameObject Light;

    public void HighSpeedStartAction()
    {
        plane.speed *= 2;
        Debug.Log("Powerup works!!!");
    }

    public void HighSpeedEndAction()
    {
        plane.speed = plane.defaultSpeed;
        Debug.Log("Powerup ends!");
    }

    public void IncreasePowerStartAction()
    {
        RaycastHit Hit;
        if (Physics.Raycast(Light.transform.position, Light.transform.forward, out Hit, 500))
        {
            Instantiate(DirtPart, Hit.point, Quaternion.Euler(Hit.normal));
        }
    }

    public void IncreasePowerEndAction()
    {
        RaycastHit Hit;
        if (Physics.Raycast(Light.transform.position, Light.transform.forward, out Hit, 100))
        {
            Instantiate(DirtPart, Hit.point, Quaternion.Euler(Hit.normal));
        }
    }

}
