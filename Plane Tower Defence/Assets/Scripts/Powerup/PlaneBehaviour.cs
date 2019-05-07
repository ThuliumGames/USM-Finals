using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBehaviour : MonoBehaviour
{

    private Transform transform_;

    private Rigidbody rig;

    public float defaultSpeed = 7;

    public float speed = 7;

    private void Awake()
    {
        transform_ = transform;
        rig = GetComponent<Rigidbody>();
    }
 
}
