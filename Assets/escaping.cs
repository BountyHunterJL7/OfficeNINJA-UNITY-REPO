using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class escaping : MonoBehaviour
{

    [SerializeField] public Image customImage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            customImage.enabled = true;
        }

    }
}
