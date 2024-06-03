using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour
{
    public Jump jump;
    //public GameObject boxPref;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        jump = GetComponentInParent<Jump>();
    }
    private void Update()
    {
        if (jump.isgrounded == false)
            StartCoroutine(waitforGravity());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jump.isgrounded = true;
            Debug.Log("Trigger Enter");
            //Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            //Instantiate(boxPref, pos, Quaternion.identity);
            rb.gravityScale = 2;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jump.isgrounded = false;
            Debug.Log("Trigger Exit");
        }
    }
    IEnumerator waitforGravity()
    {
        yield return new WaitForSeconds(.5f);
        rb.gravityScale = 5;
    }
}
