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