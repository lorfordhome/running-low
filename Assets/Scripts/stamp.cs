using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class stamp : MonoBehaviour
{
    //[Header("Ink Objects")]
    //public GameObject redInk;
    //public GameObject blueInk;
    //public GameObject greenInk;

    //[Header("Shape Objects")]
    //public GameObject triangle;
    //public GameObject square;
    //public GameObject circle;

    public enum colour
    {
        red,green, blue, none
    }
    public enum shape
    {
        circle,square,triangle
    }

    public colour stampColour;
    public shape stampShape;
    public Rigidbody2D body;
    [Header("Shape Sprites")]
    public Sprite triangle;
    public Sprite square;
    public Sprite circle;

    public void changeColour(colour col)
    {
        stampColour = col;
        switch (col)
        {
            case colour.red:
                this.GetComponent<SpriteRenderer>().color = Color.red; break;
            case colour.green:
                this.GetComponent<SpriteRenderer>().color = Color.green; break;
            case colour.blue:
                this.GetComponent<SpriteRenderer>().color = Color.blue; break;
        }
    }
    public void changeShape(shape shape)
    {
        stampShape = shape;
        switch (shape)
        {
            case shape.circle:
                this.GetComponent<SpriteRenderer>().sprite = circle; break;
            case shape.triangle:
                this.GetComponent<SpriteRenderer>().sprite = triangle; break;
            case shape.square:
                this.GetComponent<SpriteRenderer>().sprite = square; break;
        }
    }

    void printInk()
    {

    }

    void checkClick()
    {
        //maybe the ink/shape will call the change functions instead?
        //or not?
    }

    void Start()
    {
        body=this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        body.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        if (Input.GetMouseButtonDown(0))
        {
            checkClick();
        }

    }
}
