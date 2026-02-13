using UnityEngine;

public class wingopen : MonoBehaviour
{
    [SerializeField] wingss op;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("dragonfly"))
        {
            op.open = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("dragonfly"))
        {
            op.open = false;
        }
    }
}
