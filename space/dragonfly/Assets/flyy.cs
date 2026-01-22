using UnityEngine;

public class flyy : MonoBehaviour
{
    public Animator animatorrrr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatorrrr = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        animatorrrr.Play("rotor");
    }
}
