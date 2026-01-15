using UnityEngine;

public class radar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 Rotation;
    [SerializeField] float spinnyspeed = 10;
    void Start()
    {
        Rotation=transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        this.transform.Rotate(0, spinnyspeed, 0);
    }
}
