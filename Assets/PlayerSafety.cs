using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSafety : MonoBehaviour
{
    public bool isSafe;
    
    // Start is called before the first frame update
    void Start()
    {
        isSafe = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isSafe);
    }
}
