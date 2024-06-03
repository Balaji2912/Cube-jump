using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesKiller : MonoBehaviour
{
    public GameObject platformDestroy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Jump jump = collision.GetComponent<Jump>();
            jump.PlayerDie();
        }
        else if (collision.CompareTag("Platform"))
        {
            Destroy(collision.gameObject);
            Vector3 pos = new Vector3(collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);
            Instantiate(platformDestroy, pos, Quaternion.identity);
        }
    }
}
