using UnityEngine;

public class laser : MonoBehaviour
{
    public GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform piss = transform;
        piss.LookAt(target.transform,transform.up);
        
        Vector3 poopoo = piss.eulerAngles;
        //poopoo.x = -90;
        poopoo.x = 0;
        poopoo.z =  0;
        transform.rotation = Quaternion.Euler(poopoo);
        lasergun lg =GetComponentInChildren<lasergun>();
        lg.transform.LookAt(target.transform);
    }
}
