using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    public Transform target;
    public float speed=20f;
    public float rotation_speed=95f;
    public int tick = 0;
    public int straight = 0;
    public GameObject explosion;
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        //transform.position = transform.forward * speed * Time.deltaTime;
        rb.linearVelocity=rb.transform.forward*speed;
        if (tick == 0)
        {
            tick = 1;
            InvokeRepeating("Tick",0 ,0.25f);
        }
        if (tick > 2&&straight==0)
        {
            Vector3 relativepos =target.position- rb.transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativepos);
            rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, rotation_speed * Time.deltaTime));
        }
        else
        {
           //transform.position = transform.forward * speed* Time.deltaTime;
        }
        if (tick > 1000)
        {
            Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
        //Debug.DrawLine(rb.transform.position,rb.transform.forward);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject,0.1f);
    }
    void Tick()
    {
        tick++;
    }
}
