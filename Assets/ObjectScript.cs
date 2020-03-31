using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectScript : MonoBehaviour
{
    public GameObject PlayerHand;
    public GameObject PlayerPosition;
    public Vector3 PickPosition;
    public Vector3 PickRotation;
    public bool HoldCheck;
    public AudioSource HitSound;
    public GameObject AlertOject;
    private Rigidbody rb;
    private bool CurrentlyHeld;
    private bool Thrown;
    private LayerMask layerMask;
    public GameObject hitAnim;
    // Start is called before the first frame update
    void Start()
    {
        HoldCheck = PlayerPosition.GetComponent<HoldCheck>().IsHolding;
        rb = gameObject.GetComponent<Rigidbody>();
        Thrown = false;
        //Physics.IgnoreLayerCollision(10, 10);
        layerMask = LayerMask.GetMask("Default");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray cursorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //todo, add raycast check for objects
        HoldCheck = PlayerPosition.GetComponent<HoldCheck>().IsHolding;
        if (Physics.SphereCast(cursorRay, 0.6f, out hit, Mathf.Infinity, layerMask) || Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Debug.LogWarning(hit.collider.name);
            if (!HoldCheck && Input.GetMouseButtonDown(0) && PlayerDistance() < 3f && !Thrown && hit.collider.name == gameObject.name)
            {
                //Debug.LogWarning(hit.collider.name);
                Debug.Log("Item picked up");
                //Debug.Log(PlayerDistance());

                PlayerPosition.GetComponent<HoldCheck>().IsHolding = true;
                CurrentlyHeld = true;
                gameObject.transform.parent = PlayerHand.transform;
                gameObject.transform.localPosition = PickPosition;
                gameObject.transform.localEulerAngles = PickRotation;
                rb.detectCollisions = false;
                rb.isKinematic = true;
            }
            else if (HoldCheck && CurrentlyHeld && Input.GetMouseButtonDown(1) && !Thrown)
            {
                rb.detectCollisions = true;
                rb.isKinematic = false;
                gameObject.transform.parent = null;
                transform.position = new Vector3(transform.position.x, 2, transform.position.z);

                Vector3 vo = CalculateVelocty(hit.point, transform.position, 1f);


                Physics.IgnoreCollision(PlayerPosition.GetComponent<Collider>(), GetComponent<Collider>(), true);
                rb.velocity = vo;
                //gameObject.transform.position = hit.point;
                PlayerPosition.GetComponent<HoldCheck>().IsHolding = false;
                CurrentlyHeld = false;
                Thrown = true;

                //Debug.LogWarning(ThrowDirection);

            }
            else
            {
                //Debug.Log("??");
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        if (Thrown && collision.collider.tag != "Player")
        {
            Debug.Log(collision.collider.name);
            HitSound.Play();
            Instantiate(AlertOject, 
                new Vector3(transform.position.x, 0, transform.position.z), 
                Quaternion.identity);
            GameObject NewHit = Instantiate(hitAnim, new Vector3(transform.position.x, 0.01f, transform.position.z), Quaternion.Euler(90, 0, 0));
            Destroy(NewHit, 5f);
            Thrown = false;
            Physics.IgnoreCollision(PlayerPosition.GetComponent<Collider>(), GetComponent<Collider>(), false);
        }
        
    }

    private float PlayerDistance()
    {
        return Vector3.Distance(gameObject.transform.position, PlayerPosition.transform.position);
    }


    Vector3 CalculateVelocty(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceXz = distance;
        distanceXz.y = 0f;

        float sY = distance.y;
        float sXz = distanceXz.magnitude;

        float Vxz = sXz * time;
        float Vy = (sY / time) + (0.5f * Mathf.Abs(Physics.gravity.y) * time);

        Vector3 result = distanceXz.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;
    }
}
