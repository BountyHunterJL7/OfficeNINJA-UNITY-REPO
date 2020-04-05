using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionPopup : MonoBehaviour
{
    private bool UIstart;
    public CanvasGroup PopUp;
    // Start is called before the first frame update
    void Start()
    {
        UIstart = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitAndPrint()
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);
        print("WaitAndPrint " + Time.time);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("in ui trigger");
        if (UIstart == false)
        {
            UIstart = true;
            PopUp.alpha = 1;
        }
        

    }
}
