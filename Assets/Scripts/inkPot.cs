using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class inkPot : MonoBehaviour
{
    public enum colour { red, green, blue }

    public colour inkColour;
    public stamp stamp;
   
    void Start()
    {
        stamp=FindObjectOfType<stamp>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        stamp.changeColour((stamp.colour)inkColour);
    }
}
