using UnityEngine;

public class shotttt : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 200;
    public int tick = 0;
    public int range = 1000;
    public GameObject explosion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = rb.transform.forward * speed;
        if (tick == 0)
        {
            tick = 1;
            InvokeRepeating("Tick", 0, 1);
        }
        if (tick > range)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    void Tick()
    {
        tick++;
    }
}
