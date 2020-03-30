using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class winScript : MonoBehaviour
{
    Animator anim;

    [SerializeField] public Image customImage;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
  
        {
            customImage.enabled = true;
        }


    }
}
