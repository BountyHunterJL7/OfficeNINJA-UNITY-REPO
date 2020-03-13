using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    public GameObject playerSafetyState;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other) // When the player enters a "Safe" area
    {
        if (other.gameObject.tag.Equals("Player") == true)
        {
            playerSafetyState.GetComponent<PlayerSafety>().isSafe = true;
            //Debug.Log("Player is in the safe area");
            
        }
            
    }

    private void OnTriggerStay(Collider other) // When the player stays in a "Safe" area
    {
        if (other.gameObject.tag.Equals("Player") == true)
        {
            //Debug.Log("Player is in the safe area");

        }
    }

    private void OnTriggerExit(Collider other) // When the player exits a "Safe" area
    {
        if (other.gameObject.tag.Equals("Player") == true)
        {
            
            playerSafetyState.GetComponent<PlayerSafety>().isSafe = false;
            //Debug.Log("Player has left the safe area");
            Debug.Log(playerSafetyState.GetComponent<PlayerSafety>().isSafe);
        }
        
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerSafetyState.GetComponent<PlayerSafety>().isSafe);
    }
}
