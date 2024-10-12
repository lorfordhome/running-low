using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillButton : MonoBehaviour
{
    public GameObject inkPot;
    private bool isInInk = false;
    public AudioSource refillSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInInk = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isInInk = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isInInk)
        {
            refillSFX.Play();
            inkPot.GetComponent<inkPot>().updateFill(true);
        }
    }
}
