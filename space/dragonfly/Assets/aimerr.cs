using UnityEngine;

public class aimerr : MonoBehaviour
{
    public GameObject gun1;
    public GameObject gun2;
    public GameObject target;
    public Transform tg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tg = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cageInLocalPos = transform.InverseTransformPoint(target.transform.position);
        cageInLocalPos.y = 0f;
        Vector3 targetposworld = transform.TransformPoint(cageInLocalPos);
        transform.LookAt(targetposworld,tg.up);
        //target.transform.position = cageInLocalPos;
        //tg = target.transform;
        /*Vector3 relativepos = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativepos);
        Vector3 rotation2 = rotation.eulerAngles;
        Vector3 rotation3 = rotation.eulerAngles;
        rotation2.x = 0;
        rotation2.z = 0;
        rotation3.z = 0;
        rotation3.y = 0;
        rotation=Quaternion.Euler(rotation2);
        //transform.Rotate(Quaternion.RotateTowards(transform.rotation, rotation, 10f).eulerAngles);
        //transform.LookAt(target.transform);
        //Quaternion rotation = transform.rotation;
        rotation.x = 0;
        rotation.z = 0;
        //transform.rotation = rotation;
        Quaternion rotation4 = Quaternion.Euler(rotation3);
        //gun1.transform.Rotate(Quaternion.RotateTowards(transform.rotation, rotation4, 100f).eulerAngles);*/
    }
}
