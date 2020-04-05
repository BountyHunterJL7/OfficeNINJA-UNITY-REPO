using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level2win : MonoBehaviour
{
     public Image black;
    public Animator anim;

     void OnTriggerEnter(Collider other)
 {
    if(other.gameObject.tag=="Player")
    StartCoroutine(Fading());
     //SceneManager.LoadScene("Level2");  
 }

 IEnumerator Fading()
 {
     anim.SetBool("fade",true);
     yield return new WaitUntil(()=>black.color.a==1);
     SceneManager.LoadScene("Level3"); 
 }
}
