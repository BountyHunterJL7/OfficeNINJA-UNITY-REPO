using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lose : MonoBehaviour
{
    public bool safeArea;
      void OnTriggerEnter(Collider other)
 {
    if(other.gameObject.tag=="Player" && safeArea == false)
     SceneManager.LoadScene("Lose");  
 }
}
