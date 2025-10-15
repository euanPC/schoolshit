using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    public LayerMask mask;
    public LayerMask self;
    public Vector3 test;
    private float LastShootTime;
    public GameObject bullet;
    public float cooldown = 0;
    private Quaternion orgrotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotation.Set(0, spin, 0);
        orgrotation=transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        test = transform.localEulerAngles;
        rotationy = test.y;
        if(cooldown > 0)
        {
            cooldown = cooldown - 1 * Time.deltaTime;
        }
        if (fire)
        {
            //print(rotationy);
            transform.Rotate(rotation * Time.deltaTime*10);
            Vector3 dir = GetDirection();
            clear = !Physics.Raycast(firepos.transform.position, dir, 10000f, self);
            //print(Physics.Raycast(firepos.transform.position, dir, 10000f, self));
            /*if ((rotationy > 42&&rotationy<47) || (rotationy > 132&&rotationy<136) || (rotationy > 223 & rotationy < 226 || (rotationy >314&&rotationy<316))
            {*/
            if (clear == true)
            {
                /* TrailRenderer trail = Instantiate(bulltettrail, firepos.transform.position, Quaternion.identity);
                 if(Physics.Raycast(firepos.transform.position,dir, out RaycastHit hit,float.MaxValue,mask))
             {

                     StartCoroutine(SpawnTrail(trail, hit));
                     print(trail);

                 }
                 else
                 {
                     StartCoroutine(SpawnTrail2(trail,transform.forward*10000));
                 }*/
                if (cooldown < 1)
                {
                    Vector3 direction = transform.rotation.eulerAngles;
                    direction.y = direction.y + 90;
                    GameObject shot = Instantiate(bullet, firepos.transform.position, firepos.transform.rotation);
                    cooldown = 1.05f;
                }
                    firing1.Play();
                firing2.Play();
                fire= false;
            }
            /* }*/
        }
        else
        {
            //Quaternion.Lerp(transform.rotation, orgrotation, Time.deltaTime*10);
        }
        
    }
    private Vector3 GetDirection()
    {
        Vector3 direction = firepos.transform.forward;
        return direction;

    }
    private IEnumerator SpawnTrail(TrailRenderer trail,RaycastHit hit)
    {
        float time = 0;
        Vector3 startPos = trail.transform.position;
        while (time < 1)
        {
            trail.transform.position = Vector3.Lerp(startPos, transform.forward, time);
            time = Time.deltaTime / trail.time;
            yield return null;
        }
        trail.transform.position = hit.point;
        Destroy(trail.gameObject,trail.time);

    }
    private IEnumerator SpawnTrail2(TrailRenderer trail, Vector3 pos)
    {
        float time = 0;
        Vector3 startPos = trail.transform.position;
        while (time < 1)
        {
            trail.transform.position = Vector3.Lerp(startPos, transform.forward, time);
            time = Time.deltaTime / trail.time;
            yield return null;
        }
        trail.transform.position = pos;
        Destroy(trail.gameObject,trail.time);
    }
}
