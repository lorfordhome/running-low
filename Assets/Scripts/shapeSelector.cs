using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shapeSelector : MonoBehaviour
{
    public enum Shape { circle, square, triangle }

    public Shape shape;
    public stamp stamp;

    void Start()
    {
        stamp = FindObjectOfType<stamp>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        stamp.changeShape((stamp.shape)shape);
    }
}
