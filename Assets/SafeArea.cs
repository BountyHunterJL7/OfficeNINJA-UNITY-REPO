using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    //private GameObject alertSet;
    void Start()
    {

        //GameObject alertSet = GameObject.FindWithTag("alert");

    }
    /*
    private void OnTriggerEnter(Collider other) // When the player enters a "Safe" area
    {
        if (other.gameObject.tag.Equals("Boss"))
        {
            //Debug.Log("Player is in the safe area");
            
            other.GetComponent<lose>().safeArea = true;
            other.GetComponent<Animator>().SetBool("playerFound", false);
            foreach (Transform child in other.gameObject.transform)
            {
                if (child.CompareTag("alert"))
                {
                    child.GetComponent<Alert>().alert = false;
                }

            } 
            

        }

    }
    */
    /*
    private void OnTriggerStay(Collider other) // When the player stays in a "Safe" area
    {

        if (other.gameObject.tag.Equals("Boss"))
        {

            //Debug.Log("Player is in the safe area");
            other.GetComponent<lose>().safeArea = true;
            other.GetComponent<Animator>().SetBool("playerFound", false);
            foreach (Transform child in other.gameObject.transform)
            {
                if (child.CompareTag("alert"))
                {
                    child.GetComponent<Alert>().alert = false;
                }

            }

        }
    }

    /*
    private void OnTriggerExit(Collider other) // When the player exits a "Safe" area
    {
        if (other.gameObject.tag.Equals("Boss"))
        {
            
            //Debug.Log("Player is in the safe area");
            other.GetComponent<lose>().safeArea = false;
            other.GetComponent<Animator>().SetBool("playerFound", false);
            foreach (Transform child in other.gameObject.transform)
            {
                if (child.CompareTag("alert"))
                {
                    child.GetComponent<Alert>().alert = false;
                }

            }


        }
    }
    */

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
