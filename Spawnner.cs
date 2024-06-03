using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public GameObject platform;
    public Vector3 prevSpawn;
    void Start()
    {
        for(int i = 0; i<=3; i++)
        {
            spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawn()
    {
        float xspawnpos;
        float x = Random.Range(0, 2);
        //Debug.Log("X "+ x);
        x = Mathf.Round(x);
        //Debug.Log("Round " + x);
        if (x == 0)
            xspawnpos = 8;
        else
            xspawnpos = 4;

        Vector3 spawnpos = new Vector3(prevSpawn.x + xspawnpos, prevSpawn.y + 3, 0);
        Instantiate(platform, spawnpos, Quaternion.identity);
        prevSpawn = spawnpos;

    }
   
}
