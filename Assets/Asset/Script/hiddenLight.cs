using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddenLight : MonoBehaviour
{
    bool turning;
    void Update()
    {
        if(Player.rend.sortingOrder == 0)
        {
            this.GetComponent<Light>().range = 10;
            this.GetComponent<Light>().intensity = 0.8f;
        } else
        {
            this.GetComponent<Light>().range = 100;
            this.GetComponent<Light>().intensity = 1;
        }
    }   
}
