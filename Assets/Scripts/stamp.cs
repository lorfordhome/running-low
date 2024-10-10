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
    public Sprite redSprite, greenSprite, blueSprite, blankSprite;
    public Sprite redTri, greenTri, blueTri;
    public Sprite redCircle, greenCircle, blueCircle;

    public void changeColour(colour col)
    {
        stampColour = col;
        switch (col)
        {
            case colour.red:
                switch (stampShape)
                {
                    case shape.circle:
                        this.GetComponent<SpriteRenderer>().sprite = redCircle; break;
                    case shape.triangle:
                        this.GetComponent<SpriteRenderer>().sprite = redTri; break;
                    case shape.square:
                        this.GetComponent<SpriteRenderer>().sprite = redSprite; break;
                }
                break;
            case colour.green:
                switch (stampShape)
                {
                    case shape.circle:
                        this.GetComponent<SpriteRenderer>().sprite = greenCircle; break;
                    case shape.triangle:
                        this.GetComponent<SpriteRenderer>().sprite = greenTri; break;
                    case shape.square:
                        this.GetComponent<SpriteRenderer>().sprite = greenSprite; break;
                }
                break;
            case colour.blue:
                switch (stampShape)
                {
                    case shape.circle:
                        this.GetComponent<SpriteRenderer>().sprite = blueCircle; break;
                    case shape.triangle:
                        this.GetComponent<SpriteRenderer>().sprite = blueTri; break;
                    case shape.square:
                        this.GetComponent<SpriteRenderer>().sprite = blueSprite; break;
                }
                break;
        }
    }
    public void changeShape(shape shape)
    {
        stampShape = shape;
        stampColour = colour.none;
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
        body = this.GetComponent<Rigidbody2D>();
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
