using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillButton : MonoBehaviour
{
    public GameObject inkPot;

    private void OnMouseDown()
    {
        inkPot.GetComponent<inkPot>().updateFill(true);
    }
}
