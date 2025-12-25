using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class heli : MonoBehaviour
{
    public float EnginePower;
    public float EngineLift=0.0075f;
    public Rigidbody helicopterRigid;
    public float effheight;
    public Animator anime;
    public Vector2 movment = Vector2.zero;
    public float ForwardForce;
    public float BackwardForce;
    public float distanceToGround;
    public bool IsGrounded=true;
    public LayerMask ground;
    public float TurnForce;
    public float TurnForceHelper=1.5f;
    public float turning = 0f;
    public Vector2 tilting = Vector2.zero;
    public float ForwTilt;
    public float TurnTilt;
    public GameObject minigunbarrel1;
    public GameObject minigunbarrel2;
    public GameObject firing1;
    public GameObject firing2;
    public float spin = 100;
    public Vector3 test;
    public Vector3 rotation;
    public GameObject bullet;
    public ParticleSystem fire4;
    public ParticleSystem fire3;
    public ParticleSystem fire1;
    public ParticleSystem fire2;
    public int shots = 0;
    public GameObject m1;
    public GameObject m2;
    public GameObject m3;
    public GameObject m4;
    public GameObject m5;
    public GameObject m6;
    public GameObject m7;
    public GameObject m8;
    public GameObject rocket;
    public List<GameObject> missiles = new();
    public float heightchange = 10;
    public float missilecooldown = 0;
    private Vector2 mouse;
    public float xRotation = 0f;
    public GameObject shadow;
    public Transform transshadow;
    public float strafe = 20f;
    [SerializeField] bool MissileTracking = false;
    [SerializeField] bool MissileLocked = false;
    public GameObject target;
    public bool targseek=false;
    public bool locked = false;
    public Camera cam;
    [SerializeField] float reload = 0;
    
    float cooldown = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transshadow = shadow.transform;
        anime = GetComponent<Animator>();
        helicopterRigid = GetComponent<Rigidbody>();
        rotation.Set(0,spin, 0);
        missiles.Add(m1);
        missiles.Add(m2);
        missiles.Add(m3);
        missiles.Add(m4);
        missiles.Add(m5);
        missiles.Add(m6);
        missiles.Add(m7);
        missiles.Add(m8);
    }

    // Update is called once per frame
    void Update()
    {
        anime.SetFloat("speed", EnginePower);
        HandleGroundCheck();
        HandleInputs();
       
    }
    void FireControl()
    {
        if (targseek)
        {
            RaycastHit hit;
            Ray raycast = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(raycast,out hit, 500))
            {
                target.transform.position=hit.point;
                locked = true;
            }
           Cursor.lockState = CursorLockMode.Confined;
            Vector3 mousepos = Input.mousePosition;
            mousepos.z=90;
            Vector3 targ=cam.ScreenToWorldPoint(Input.mousePosition);
            print(targ);
            //target.transform.position = targ;
            target.gameObject.SetActive(true);
            locked=true;
            /*var possibletarg =Physics.OverlapSphere(targ, 5f);
            if (possibletarg.Length > 0) {
                var obj = possibletarg.Last();
           // if (obj != null)
           // {
               target=obj.gameObject;
                print(obj.transform.position);
            }
            else
            {
                target = null;
            }*/

        }
        else { Cursor.lockState = CursorLockMode.Locked;//locked = false; target.gameObject.SetActive(false);
               }

        if (missilecooldown > 0)
        {
            missilecooldown = missilecooldown - 1 * Time.deltaTime;
        }
        if (cooldown > 0)
        {
            cooldown = cooldown - 1 * Time.deltaTime;
        }
        if (Input.GetButton("Fire1"))
        {
            Transform gun = minigunbarrel1.transform;
            Transform gun2 = minigunbarrel2.transform;
            test = gun.rotation.eulerAngles;
            test.x = test.x + 100f;
            gun.Rotate(rotation * Time.deltaTime);
            gun2.Rotate(rotation * Time.deltaTime);
            if (cooldown < 1)
            {
                Vector3 direction = gun.rotation.eulerAngles;
                direction.y = direction.y + 90;
                GameObject shot = Instantiate(bullet, firing1.transform.position, firing1.transform.rotation);
                GameObject shot2 = Instantiate(bullet, firing2.transform.position, firing2.transform.rotation);
                cooldown = 1.05f;
                fire1.Play();
                fire2.Play();
                fire3.Play();
                fire4.Play();
            }
        }
        if (Input.GetButton("Fire2")&&missilecooldown<1)
        {
            GameObject missile = m1;
            switch (shots)
            {
                case 0:
                    missile = m1;
                    break;
                case 1:
                    missile = m2;
                    break;
                case 2:
                    missile = m3;
                    break;
                case 3:
                    missile = m4;
                    break;
                case 4:
                    missile = m5;
                    break;
                case 5:
                    missile = m6;
                    break;
                case 6:
                    missile = m7;
                    break;
                case 7:
                    missile = m8;
                    break;
            }
            if (shots > 7)
            {
                print("no ammo");
            }
            else
            {
                if (missile.active == true)
                {
                    Vector3 missilepos = missile.transform.position;
                    GameObject Missilelaunch = Instantiate(rocket, missilepos, missile.transform.rotation);
                    if (locked) {
                        Missilelaunch.GetComponent<missile>().straight = 0;
                        Missilelaunch.GetComponent<missile>().target = target.transform;
                    }

                    //Missilelaunch.GetComponent<missile>().straight = 1;
                    Missilelaunch.transform.Rotate(new Vector3(-90, 0, 0));
                    missile.SetActive(false);
                    missilecooldown = 1.2f;
                }
            }
            shots++;
        }
    }
    
        public void ReloadMissiles()
    {
        reload = 0;
        GameObject reloading;
        for (int i=0; i <missiles.Count; i++)
        {
            reloading = missiles[i];
            reloading.SetActive(true);
            shots = 0;
        }
    }
    void HandleGroundCheck()
    {
        RaycastHit hit;
        Vector3 direction = transform.TransformDirection(Vector3.down);
        Ray ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, out hit, 3000, ground)) {
            distanceToGround = hit.distance;
            if (distanceToGround < 2)
            {
                IsGrounded = true;
                if (effheight < transform.position.y)
                {
                    effheight = transform.position.y;
                }
            }
            else { IsGrounded = false; }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("reload")){
            if (IsGrounded) { reload += 1 * Time.deltaTime; }
            if (reload > 5) { ReloadMissiles(); }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("reload"))
        {
            reload = 0;
        }
    }
    void FixedUpdate()
    {
        HelicopterHover();
        HelicopterMovements();
        HelicopterTilt();
         FireControl();
    }
    void HelicopterTilt()
    {//if (IsGrounded)
     // {
     //   return;
     // }
        if (!IsGrounded)
        {
            tilting.y = xRotation;
            tilting.x = Mathf.Lerp(tilting.x, movment.x * TurnTilt, Time.deltaTime);
            tilting.x = Mathf.Clamp(tilting.x, -29, 29);
        }
        helicopterRigid.transform.localRotation = Quaternion.Euler(tilting.y, helicopterRigid.transform.localEulerAngles.y, -tilting.x);
    }
    private void HelicopterHover()
    {
        float upForce = 1 - Mathf.Clamp(helicopterRigid.transform.position.y / effheight, 0, 1);
        upForce = Mathf.Lerp(0, EnginePower, upForce) * helicopterRigid.mass;
        helicopterRigid.AddRelativeForce(Vector3.up * upForce);
    }
    void Missilefire()
    {

    }
    void HandleInputs()
    {
        if (Input.GetKey(KeyCode.RightAlt))
        {
            locked = false;
            target.gameObject.SetActive(false);
        }
        targseek = Input.GetKey(KeyCode.Tab);
        if (EnginePower>0)
        {
            movment.x = Input.GetAxis("Horizontal");
            movment.y = Input.GetAxis("Vertical");
            mouse.x = Input.GetAxis("Mouse X")*TurnTilt*Time.deltaTime;
            mouse.y = Input.GetAxis("Mouse Y")*ForwTilt*Time.deltaTime;
            xRotation -= mouse.y;
            xRotation = Mathf.Clamp(xRotation, -11, 30);
            if (Input.GetKey(KeyCode.C))
            {
                EnginePower -= EngineLift;
                if (EnginePower < 0)
                {
                    EnginePower = 0;
                }
            }
            if (Input.GetKey(KeyCode.LeftControl)&&!IsGrounded)
            {
                effheight -= heightchange;
                if ((effheight < 0))
                {
                    effheight = 0;
                }
               
                    
                
            }
            if (Input.GetKey(KeyCode.Space))
            {
                effheight += heightchange;
            }
        }
        if (Input.GetAxis("throttle") > 0)
        {
            EnginePower += EngineLift;

        }else if (Input.GetAxis("Vertical")>0 &&!IsGrounded)
        {
           // EnginePower = Mathf.Lerp(EnginePower, 17.5f, 0.003f);
        }
        else if (Input.GetAxis("throttle") < 0.5f && !IsGrounded)
        {
            //EnginePower = Mathf.Lerp(EnginePower, 10f, 0.003f);
        }
    }
    void UpdateMissileLock(float dt)
    {
        Vector3 targetDir = Vector3.forward;
        MissileLocked = false;
        MissileTracking = false;

    }
    void HelicopterMovements()
    {
        Vector3 transsonadow = transshadow.position;
        
        if (Input.GetAxis("Vertical") > 0)
        {
            helicopterRigid.AddRelativeForce(Vector3.forward* Mathf.Max(0f,movment.y*ForwardForce*helicopterRigid.mass));

        }else if (Input.GetAxis("Vertical") < 0)
        {
            helicopterRigid.AddRelativeForce(Vector3.back * Mathf.Max(0f, -movment.y * BackwardForce * helicopterRigid.mass));
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            helicopterRigid.AddRelativeForce(Vector3.right * Mathf.Max(0f, movment.x * strafe * helicopterRigid.mass));
        }else if (Input.GetAxis("Horizontal") < 0)
        {
            helicopterRigid.AddRelativeForce(Vector3.left * Mathf.Max(0f,-movment.x*strafe*helicopterRigid.mass));
        }
            float turn = TurnForce * Mathf.Lerp(mouse.x, mouse.x * (TurnForceHelper - Mathf.Abs(movment.y)), Mathf.Max(0f, movment.y));
        turning = Mathf.Lerp(turning, turn, Time.fixedDeltaTime * TurnForce);
        helicopterRigid.AddRelativeTorque(0f, turning * helicopterRigid.mass, 0f);
    }
}
