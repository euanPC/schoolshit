using System;
using UnityEngine;

public class helicoptercontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    [SerializeField] private float responsiveness = 500f;
    [SerializeField] private float throttleAmt = 25f;
    [SerializeField]private float throttle=0;
    public float animspeed = 1;
    public AnimationClip anime;
    public Animator animator;
    //public Animation anime2;
    private float roll;
    private float pitch;
    private float yaw;
    public Transform transform1;
    public float effheight;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator.Play("flying");
        //anime2 = GetComponent<Animation>();
        //anime2.Play("flying");
        
    }

    // Update is called once per frame
    private void Update()
    {
        HandleInputs();
        animator.SetFloat("speed", throttle*10 );
        
        
        //anime2["flying"].speed = throttle;
        
    }
    private void FixedUpdate()
    {
        /* rb.AddForce(transform.up*throttle, ForceMode.Impulse);
         rb.AddTorque(transform.right * pitch * responsiveness);
         rb.AddTorque(-transform.forward * roll * responsiveness);
         rb.AddTorque(transform.up * yaw * responsiveness);
         Quaternion rot = transform.rotation;
         Vector3 rotation =rot.eulerAngles;
         //rotation.x = Mathf.Clamp(rotation.x, -30, 30);
         //rotation.z = Mathf.Clamp(rotation.z, -30, 30);
         rot=Quaternion.Euler(rotation);
         //transform.rotation = rot;*/
        HelicopterHover();

    }

     void HelicopterHover()
    {
        float upForce = 1 - Mathf.Clamp(rb.transform.position.y/effheight,0,1);
        upForce = Mathf.Lerp(0,throttle, upForce)*rb.mass;
        rb.AddRelativeForce(Vector3.up * upForce);
    }

    private void HandleInputs()
    {
        if (Input.GetAxis("Throttle") > 0)
        {
            throttle += throttleAmt;
        }
        /* roll = Input.GetAxis("Roll");
         pitch = Input.GetAxis("Pitch");
         yaw = Input.GetAxis("yaw");*/
        /* if (Input.GetKey(KeyCode.Space))
         {
             throttle+=Time.deltaTime * throttleAmt;
         }else if (Input.GetKey(KeyCode.LeftControl))
         {
             throttle -=Time.deltaTime * throttleAmt;
         }
 throttle = Mathf.Clamp(throttle, 0, 100);

        //throttle = throttle * 100;
         print(throttle);*/

    }
}
