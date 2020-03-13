using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;
    bool isSafe2;
    

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
        Debug.Log(player.GetComponent<PlayerSafety>().isSafe);
        anim.SetFloat("distance", Vector3.Distance(transform.position,player.transform.position));
        anim.SetBool("isSafe", player.GetComponent<PlayerSafety>().isSafe);

    }
}
