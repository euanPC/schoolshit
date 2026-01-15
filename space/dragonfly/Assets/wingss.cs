using UnityEngine;

public class wingss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject leftwing;
    [SerializeField] GameObject rightwing;
    public float turnspeed = 20f;
    public bool open;
    [SerializeField] float y_rotation;
    void Start()
    {
        y_rotation=rightwing.transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {  
        if (open)
        {
          if (rightwing.transform.rotation.eulerAngles.y < 90)
        {
            y_rotation += turnspeed * Time.deltaTime;
            
        }else if (rightwing.transform.rotation.eulerAngles.y > 90)
            {
                y_rotation = 90;
            }
          
        }else if (!open)
        {
            if (rightwing.transform.rotation.eulerAngles.y > 0)
            {
                y_rotation -= turnspeed * Time.deltaTime;
            }
        }
        if (y_rotation < 0)
            {
                y_rotation = 0;
            }
        Open();
    }
    void Open()
    {
        
            Vector3 rightwingrotationcurrent = rightwing.transform.rotation.eulerAngles;
            rightwingrotationcurrent.y = y_rotation;
            Vector3 leftwingrotationcurrent = leftwing.transform.rotation.eulerAngles;
            leftwingrotationcurrent.y=-y_rotation;
        rightwing.transform.rotation = Quaternion.Euler(rightwingrotationcurrent);
        leftwing.transform.rotation = Quaternion.Euler(leftwingrotationcurrent);
    }
}
