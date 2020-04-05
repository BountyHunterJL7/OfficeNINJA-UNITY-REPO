using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    public bool alert;
   void Start ()
   {
       GetComponent<Renderer>().enabled = false;
       alert = false;
   }

   void Update ()
   {
        transform.rotation = Quaternion.Euler(0, -180, 0);
       if (alert)
       {
            GetComponent<Renderer>().enabled = true;
       }
       else
       {
            GetComponent<Renderer>().enabled = false;
       }
   }
}