using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObj : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Boss;
    private bool Deleting;
    void Start()
    {
        //Deleting = false;
        Object.Destroy(gameObject, 6.0f);

    }

    // Update is called once per frame
    void Update()
    {   
        /*
        Debug.Log(BossDistance());
        
        if (BossDistance() < 6f && !Deleting)
        {
            Object.Destroy(gameObject, 2.0f);
            Deleting = true;
        }
        */
    }


    private float BossDistance()
    {
        return Vector3.Distance(gameObject.transform.position, Boss.transform.position);
    }
}
