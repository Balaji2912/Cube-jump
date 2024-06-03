using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationex : MonoBehaviour
{
    public float Targetangle;
    float r;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
        rotfun();

    }
    void rotfun()
    {

        /*float angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, Targetangle, ref r, .1f);
        transform.rotation = Quaternion.Euler(0, 0, angle);*/

        //transform.localScale = new Vector3(0, .5f, 0);



        /*if(Mathf.Round(transform.eulerAngles.z) == 180) 
        { 
            transform.Rotate(new Vector3(0, 0, -180)); 
        }*/

    }
}
