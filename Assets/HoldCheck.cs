using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsHolding;
    public Camera cam;
    public 

    void Start()
    {
        IsHolding = false;
    }

    private void FixedUpdate()
    {
        if (IsHolding)
        {
            
        }
    }

}
