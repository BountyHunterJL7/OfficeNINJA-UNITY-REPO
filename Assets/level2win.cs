﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2win : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
 {
    if(other.gameObject.tag=="Player")
     SceneManager.LoadScene("Level2");  
 }
}
