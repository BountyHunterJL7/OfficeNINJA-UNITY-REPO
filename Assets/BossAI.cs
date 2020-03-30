using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;
    public GameObject[] balls;

    public GameObject GetPlayer()
    {
        return player;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        balls = GameObject.FindGameObjectsWithTag("DistractionPoint");
        if (balls.Length > 0)
        {
            anim.SetFloat("distractionDistance", Vector3.Distance(transform.position, balls[0].transform.position));
        }
        else
        {
            anim.SetFloat("distractionDistance", 100f);
        }
        anim.SetFloat("distance", Vector3.Distance(transform.position,player.transform.position));
        
    }
}
