using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidgetAI : MonoBehaviour
{

    private Vector2 dir;
    Rigidbody2D rb;
    public Transform target;//set target from inspector instead of looking in Update
    public float force, multi;
    private float tarDis, angle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        tarDis = Vector2.Distance(target.position, transform.position);
        
            if (tarDis < .5)
            {
                rb.velocity = Vector2.zero;
                rb.Sleep();
            }
            else
            {
                rb.drag = tarDis * multi;
                dir = (target.transform.position - transform.position).normalized;
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //transform.localEulerAngles = new Vector3(0, 0, angle);
            //rb.AddForce(force * dir);
            transform.Translate(dir * force * Time.deltaTime);
            }
    }
}