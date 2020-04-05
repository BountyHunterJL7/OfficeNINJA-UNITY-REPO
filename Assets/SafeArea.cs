using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    public GameObject boss;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other) // When the player enters a "Safe" area
    {
        if (other.gameObject.tag.Equals("Player") == true)
        {
            Debug.Log("Player is in the safe area");
            boss.GetComponent<lose>().safeArea = true;
            boss.GetComponent<Animator>().SetBool("playerFound", false);
            
        }
            
    }

    private void OnTriggerStay(Collider other) // When the player stays in a "Safe" area
    {
        if (other.gameObject.tag.Equals("Player") == true)
        {
            Debug.Log("Player is in the safe area");
            boss.GetComponent<lose>().safeArea = true;
            boss.GetComponent<Animator>().SetBool("playerFound", false);
        }
    }

    private void OnTriggerExit(Collider other) // When the player exits a "Safe" area
    {
        if (other.gameObject.tag.Equals("Player") == true)
        {
            Debug.Log("Player is not in the safe area");
            boss.GetComponent<lose>().safeArea = false;
            boss.GetComponent<Animator>().SetBool("playerFound", false);
        }
        
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
