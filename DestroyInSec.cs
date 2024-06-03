using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSec : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerable Destroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
