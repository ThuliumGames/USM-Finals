using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public int speed;
    public Vector3 target;

    void Start()
    {
        speed = 10;
    }
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; 

        transform.position = Vector3.MoveTowards(this.transform.position, target, step);
    }
}
