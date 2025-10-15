using UnityEngine;

public class returne : MonoBehaviour
{
    public Quaternion dir;
    private GameObject child;
    public Vector3 poop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dir=transform.localRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //poop = transform.parent.forward - transform.position;
        //poop.x = poop.x - 90;
        //dir = Quaternion.LookRotation(poop);
        fireminigun shoot = GetComponentInChildren<fireminigun>();
        if (!shoot.fire)
        {
            transform.localRotation=Quaternion.Slerp(dir,transform.rotation,Time.deltaTime*1);
            //transform.rotation = dir;
            //print("not shooting");
        }
        //print(shoot.fire);
    }
}
