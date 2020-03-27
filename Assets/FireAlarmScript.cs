using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAlarmScript : MonoBehaviour
{
    public Transform player;
    public float distance;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
            if (other.gameObject.tag.Equals("Player") == true)
            {
                Debug.Log("OHH shitt");
            }
        
        
    }
    private void OnTriggerStay(Collider other)
    {

        
    }



    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray cursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cursorRay, out hit, 100.0f))
        {
            distance = Vector3.Distance(player.position, transform.position);
            if (hit.transform.name == "mesh_firealarm" && Input.GetMouseButtonDown(0) && distance<2.0)
            {
                Debug.Log("You clicked");
                Debug.Log(distance);

            }
        }




    }

}
