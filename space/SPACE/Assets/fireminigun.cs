using UnityEngine;

public class fireminigun : MonoBehaviour
{
    public bool fire = true;
    public Vector3 rotation;
    public float spin = 100;
    public double rotationy = 0;
   
    public Vector3 poop;
    public GameObject firepos;
    public ParticleSystem firing1;
    public ParticleSystem firing2;
    public TrailRenderer bulltettrail;
    public bool clear = true;
    public Vector3 test;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotation.Set(0, spin, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //test = Quaternion.EulerAngles(transform.rotation);
        rotationy = test.y;
        
        if (fire)
        {
            print(rotationy);
            transform.Rotate(rotation * Time.deltaTime*10);
            /*if ((rotationy > 42&&rotationy<47) || rotationy == 135 || rotationy == 225 || rotationy == 315)
            {*/
            if (clear == true)
            {
                firing1.Play();
                firing2.Play();
            }
           /* }*/
        }
        
    }
}
