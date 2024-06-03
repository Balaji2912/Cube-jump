using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
   
    [SerializeField] public TextMeshProUGUI tm;
    [SerializeField] int scoree;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void scoreUpdate()
    {
        scoree++;
        tm.text = scoree.ToString();
    }
}
