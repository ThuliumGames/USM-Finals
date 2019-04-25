using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gremlincontroller : MonoBehaviour
{
    public Vector3 ppos;
    public Vector3 epos;
    public Vector3 floorppos;
    public Transform ptrans;
    public float dist;
    public int Speed;
    public float shoottime;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        ptrans = GameObject.Find("Heli").transform;
        ppos = new Vector3(ptrans.position.x, ptrans.position.y, ptrans.position.z);
        floorppos = new Vector3(ptrans.position.x, this.transform.position.y, ptrans.position.z);
        epos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.SqrMagnitude(this.transform.position - floorppos);
        shoottime = shoottime - Time.deltaTime;

        float step = Speed * Time.deltaTime;
        floorppos = new Vector3(ptrans.position.x, this.transform.position.y, ptrans.position.z);

        if (dist >= 95)
        {
            transform.position = Vector3.MoveTowards(transform.position, floorppos, step);
        }

        if (dist <= 800 && shoottime <= 0)
        {
            shoottime = 5;
            Object.Instantiate(bullet, this.transform.position, this.transform.rotation);
            BulletMovement myBullet = bullet.GetComponent<BulletMovement>();
            myBullet.target = ppos;

        }
    }

}
