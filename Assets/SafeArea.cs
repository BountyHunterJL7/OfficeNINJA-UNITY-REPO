using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    public Boss bossState;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other) // When the player enters a "Safe" area
    {
        if (other.gameObject.tag.Equals("Player") == true)
        {
            Debug.Log("Player is in the safe area");
            bossState.target = null;
        }
            
    }

    private void OnTriggerStay(Collider other) // When the player stays in a "Safe" area
    {
        if (other.gameObject.tag.Equals("Player") == true)
        {
            Debug.Log("Player is in the safe area");
            bossState.target = null;
        }
    }

    private void OnTriggerExit(Collider other) // When the player exits a "Safe" area
    {
        if (other.gameObject.tag.Equals("Player") == true)
        {
            Debug.Log("Player is in the safe area");
            bossState.target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
