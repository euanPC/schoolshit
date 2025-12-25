using UnityEngine;
using UnityEngine.UIElements;

public class open : MonoBehaviour
{
    [SerializeField]
    bool right;
    public bool openn;
    [SerializeField] Transform trans;
    public float ztarg;
    public float xtarg;
    public float startz;
    public float startx;
    public float sidespeed;
    public float openingspeed;
    [SerializeField] Vector3 pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {   float z = trans.localPosition.z;
        float x = trans.localPosition.x;
        if (openn) {
        
            if (Mathf.Abs(z - ztarg) > .05)
            {
                if (z > ztarg)
                {
                    trans.Translate(trans.forward * sidespeed*Time.deltaTime);
                }
                else if (z < ztarg)
                {
                    trans.Translate(trans.forward *-1 * sidespeed * Time.deltaTime);
                }
            }
            else
            {
                if (Mathf.Abs(xtarg - x)>0.5) { 
                if(x > xtarg)
                    {
                        trans.Translate(trans.right * -1 * openingspeed * Time.deltaTime);
                    }
                else if (x < xtarg)
                    {
                        trans.Translate(trans.right*  openingspeed * Time.deltaTime);
                    }
                }

            }
        }
        else
        {
            if (Mathf.Abs(startx - x) > 0.5)
            {
                if (x > startx)
                {
                    trans.Translate(trans.right * -1 * openingspeed * Time.deltaTime);
                }
                else if (x < startx)
                {
                    trans.Translate(trans.right * openingspeed * Time.deltaTime);
                }
            }
            else if (Mathf.Abs(startz - z) > 0.5)
            {
                if(z> startz)
                {
                    trans.Translate(trans.forward * sidespeed * Time.deltaTime);
                }else if (z < startz)
                {
                    trans.Translate(trans.forward * -1 * sidespeed * Time.deltaTime);
                }
            }
            else { 
                //transform.localPosition= new Vector3(startx,trans.position.y,startz);
                }



        }
    }

}
