using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviourScript : MonoBehaviour
{
    Animator NPCAnim;
    public GameObject player;
    private float countdown = 10;
    // Start is called before the first frame update
    void Start()
    {
        NPCAnim = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag.Equals("Player") == true)
        {
            NPCAnim.SetBool("IsNear", true);
            Debug.Log("something entered");

            
        }
        
    }

    
    private void OnTriggerStay(Collider collision)
    {
        
        if (collision.gameObject.tag.Equals("Player") == true)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                NPCAnim.SetBool("IsNear", false);
                countdown = 10;
                
            }
            Debug.Log(countdown);
        }

    }
    
    private void OnTriggerExit(Collider collision)
    {
        
        if (collision.gameObject.tag.Equals("Player") == true)
        {
            NPCAnim.SetBool("IsNear", false);
            Debug.Log("something left");
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
