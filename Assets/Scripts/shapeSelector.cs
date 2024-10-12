using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapeSelector : MonoBehaviour
{
    public enum Shape { circle, square, triangle }

    public Shape shape;
    public stamp stamp;
    private bool isInInk = false;
    public AudioSource SFX;

    void Start()
    {
        stamp = FindObjectOfType<stamp>();
        SFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            if (isInInk)
            {
                SFX.Play();
                stamp.changeShape((stamp.shape)shape);
            }
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log("collision");
    //    if (collision.transform.tag == "stamp")
    //    {
    //        Debug.Log("stamp col");
    //        if (Input.GetMouseButtonDown(0))
    //        {
    //            Debug.Log("Change shaoe");
    //            stamp.changeShape((stamp.shape)shape);
    //        }
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInInk = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        isInInk = false;
    }
}
