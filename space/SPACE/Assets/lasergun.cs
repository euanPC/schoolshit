using UnityEngine;

public class lasergun : MonoBehaviour
{
    public float range = 10000;
    public bool fire = false;
    public LineRenderer lineRenderer;
    public GameObject explosion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0,transform.position);
        RaycastHit hit;
        if (fire)
        {
            lineRenderer.enabled = true;
            if (Physics.Raycast(transform.position, transform.forward, out hit, range))
            {
                lineRenderer.SetPosition(1, hit.point);
                Instantiate(explosion, hit.point, Quaternion.identity);
            }
            else
            {
                lineRenderer.SetPosition(1, transform.position+(transform.forward*range));
            }
        }
        else
        {
            lineRenderer.enabled = false;
            lineRenderer.SetPosition(1,transform.position);
        }
        }
}
