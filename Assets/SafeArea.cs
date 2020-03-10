using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    public bool safe;
    void Start()
    {

    }

    public void OnTriggerEnter(Collider other) // When the player enters a "Safe" area
    {
        Debug.Log("Player is in the safe area");
        safe = true;
    }

    public void OnTriggerStay(Collider other) // When the player stays in a "Safe" area
    {
        Debug.Log("Player is in the safe area");
        safe = true;
    }

    public void OnTriggerExit(Collider other) // When the player exits a "Safe" area
    {
        Debug.Log("Player has left the safe area");
        safe = false;
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
