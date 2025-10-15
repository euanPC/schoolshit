using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class firecontrol : MonoBehaviour
{
    public GameObject leftminiguntop1;
    public GameObject leftminiguntop2;
    public GameObject leftminiguntop3;
    public GameObject rightminiguntop1;
    public GameObject rightminiguntop2;
    public GameObject rightminiguntop3;
    public GameObject rightminigunbottom1;
    public GameObject rightminigunbottom2;
    public GameObject rightminigunbottom3;
    public GameObject leftminigunbottom1;
    public GameObject leftminigunbottom2;
    public GameObject leftminigunbottom3;
    public GameObject[] lefttop;
    public GameObject[] righttop;
    public GameObject[] leftbottom;
    public GameObject[] rightbottom;
    public List<GameObject> pissing;
    public GameObject target;
    public Vector3 targposdif;
    public bool up = false;
    public bool leftside = false;
    public bool salvo = false;
    public GameObject ship;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lefttop = new GameObject[3];
        lefttop[0] = leftminiguntop1;
        lefttop[1] = leftminiguntop2;
        lefttop[2] = leftminiguntop3;
        righttop = new GameObject[3];
        righttop[0] = rightminiguntop1;
        righttop[1] = rightminiguntop2;
        righttop[2] = rightminiguntop3;
        rightbottom = new GameObject[3];
        rightbottom[0] = rightminigunbottom1;
        rightbottom[1] = rightminigunbottom2;
        rightbottom[2] = rightminigunbottom3;
        leftbottom = new GameObject[3];
        leftbottom[0] = leftminigunbottom1;
        leftbottom[1] = leftminigunbottom2;
        leftbottom[2] = leftminigunbottom3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject[] firing;
        if (target == null)
        {
            return;
        }
        targposdif = ship.transform.InverseTransformPoint(target.transform.position);
        if (targposdif.y < .5 && targposdif.y > -.5 && (targposdif.x>1||targposdif.x<-1))
         {
             salvo = true;
             firing = new GameObject[6];
         }
         else
         {
             salvo= false;
             firing= new GameObject[3];
         }
         if (targposdif.y < -1)
             up = false;
         else
             up = true;

         if (targposdif.x < 0)
         {
             leftside = true;
             if (!up)
             {
                 //firing = firing.AddRange(leftbottom);
                 TurnToLoc(leftbottom,3);
             }
             if (salvo||up) {
                 TurnToLoc(lefttop,1);
             }
         }
         else
         {
             leftside = false;
             if (!up)
             {
                 TurnToLoc(rightbottom,2);
             }
             if (salvo || up)
             {
                 TurnToLoc(righttop,0);
             }
         }
         //TurnToLoc(firing);
    }
    void TurnToLoc(GameObject[] gun, int restraint)
    {
        for (int i = 0; i < gun.Length; i++)
        {
            GameObject shoot = gun[i];
            Transform pos = shoot.transform;
            shoot.transform.LookAt(target.transform.position);
            pos.transform.LookAt(target.transform.position);
            Vector3 targ = target.transform.position-shoot.transform.position;
            //pos.transform.LookAt(target.transform.position);
            
            float x = pos.rotation.eulerAngles.x;
            float y = pos.rotation.eulerAngles.y;
            float z = pos.rotation.eulerAngles.z;
            x = x - 90;
            switch (restraint)
            {
                case 0:
                    // x = Mathf.Clamp(x,  -74,-278);
                    // z = Mathf.Clamp(z, -144, 8);
                    y = Mathf.Clamp(y, -4, 150);

                    break;
                case 1:
                    //y = Mathf.Clamp(y, -158, 7);
                    //x = Mathf.Clamp(x,  -182,-78);
                    break;
                case 2:
                    y = Mathf.Clamp(y, -4, 150);
                    break;
                case 3:
                    x = Mathf.Clamp(x, -78, -18);
                    break;
                    //
            }
            print(x+ y+ z);
            fireminigun shooter = shoot.GetComponentInChildren<fireminigun>();
                    shooter.fire = true;
            shoot.transform.rotation = Quaternion.Euler(x, y, z);
            pos.rotation = Quaternion.Euler(x, y, z);
            
            //shoot.transform.rotation = pos.transform.rotation;
        }
    }
}
