using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideColtouchOut : MonoBehaviour
{
    public Jump jump;
    public GameObject ps;
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        jump = player.GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name == "Player")
        {
            jump.enabled = false;
            collision.gameObject.SetActive(false);
            Vector3 inspos = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);
            Instantiate(ps, inspos, Quaternion.identity);
        }

    }
}
