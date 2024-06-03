using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelectOnDis : MonoBehaviour
{
    public Transform refObj;
    public float stepped;
    void Start()
    {
        refObj = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance(transform.position, refObj.position);
        if(Distance >= 10 && stepped == 1)
        {
            Destroy(gameObject);
        }
    }

}
