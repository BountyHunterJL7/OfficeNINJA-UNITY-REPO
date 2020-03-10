using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    float vertical;
    float horizontal;

    float verticalRaw;
    float horizontalRaw;

    Vector3 targetRotation;

    float rotationSpeed = 10f;
    float moveSpeed = 200f;

    Animator anim;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Directional Rotation
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        horizontalRaw = Input.GetAxisRaw("Horizontal");
        verticalRaw = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(horizontal, 0, vertical);
        Vector3 inputRaw = new Vector3(horizontalRaw, 0, verticalRaw);
        
        if(input.sqrMagnitude>1f)
        {
            input.Normalize();
        }
        
        if(inputRaw.sqrMagnitude>1f)
        {
            inputRaw.Normalize();
        }

        if(inputRaw != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input).eulerAngles;
        }

        rb.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(targetRotation.x,Mathf.Round(targetRotation.y / 45)*45,targetRotation.z), Time.deltaTime * rotationSpeed);

        //Movement Command
        Vector3 moveVel = input * moveSpeed * Time.deltaTime;
        rb.velocity = moveVel;
        if(moveVel.x>0 || moveVel.z>0 || moveVel.x<0 || moveVel.z < 0)
        {
            anim.SetBool("walking", true);
        }
        else if(moveVel.x==0 && moveVel.z == 0)
        {
            anim.SetBool("walking",false);
        }
    }
}
