using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 5;
    [SerializeField] private float explosionForce = 500;

    // Start is called before the first frame update
    void Start()
    {
        var SurroundingObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var obj in SurroundingObjects)
        {
            var rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
