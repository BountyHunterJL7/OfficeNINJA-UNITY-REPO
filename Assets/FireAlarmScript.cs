using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAlarmScript : MonoBehaviour
{
    public Transform player;
    public Transform boss;
    public AudioSource alarmSound;
    private float bossDistance;
    private float playerDistance;
    Animator animOther;
    private LayerMask layerMask;


    // Start is called before the first frame update
    void Start()
    {
        animOther = boss.GetComponent<Animator>();
        layerMask = LayerMask.GetMask("Default");
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
        if (Physics.SphereCast(cursorRay, 0.6f, out hit, Mathf.Infinity, layerMask))
        {
            //Debug.LogError("Ray");
            playerDistance = Vector3.Distance(player.position, transform.position);
            if (hit.transform.tag == "FireAlarm" && Input.GetMouseButtonDown(0) && playerDistance<3.0)
            {
                Debug.Log("You clicked");
                animOther.SetBool("alarmRinging", true);
                alarmSound.Play();

            }

            bossDistance = Vector3.Distance(boss.position, transform.position);
            if(bossDistance < 4.0)
            {
                animOther.SetBool("alarmRinging", false);

            }



        }




    }

}
