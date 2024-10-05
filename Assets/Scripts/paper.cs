using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class paper : MonoBehaviour
{
    public stamp Stamp;
    void Start()
    {
        Stamp=FindObjectOfType<stamp>();
    }
    public List<Shapes> printedShapes = new List<Shapes>();
    public GameObject triangleRed, triangleGreen, triangleBlue;
    public GameObject squareRed, squareGreen, squareBlue;
    public GameObject circleRed, circleGreen, circleBlue;
    public float startSpeed=2f;
    public int currentSpeed;
    public GameObject orderPrefab;
    public GameObject[] orderSpaces;
    public GameManager gameManager;
    Ordersheet ordersheet;

    void PrintShape(stamp.colour col,stamp.shape shape)
    {
        Shapes newshape = new Shapes();
        switch (shape)
        {
            case stamp.shape.triangle:
                switch (col)
                {
                    case stamp.colour.green:
                        Instantiate(triangleGreen, Stamp.body.position,Quaternion.identity,this.transform);
                        newshape.specColour = Shapes.colour.green;
                        newshape.specType = Shapes.shapeType.triangle;
                        break;
                    case stamp.colour.blue:
                        Instantiate(triangleBlue, Stamp.body.position, Quaternion.identity, this.transform);
                        newshape.specColour = Shapes.colour.blue;
                        newshape.specType = Shapes.shapeType.triangle;
                        break;
                    case stamp.colour.red:
                        Instantiate(triangleRed, Stamp.body.position, Quaternion.identity, this.transform);
                        newshape.specColour = Shapes.colour.red;
                        newshape.specType = Shapes.shapeType.triangle;
                        break;
                }
                break;
            case stamp.shape.circle:
                switch (col)
                {
                    case stamp.colour.green:
                        Instantiate(circleGreen, Stamp.body.position, Quaternion.identity, this.transform);
                        newshape.specColour = Shapes.colour.green;
                        newshape.specType = Shapes.shapeType.circle;
                        break;
                    case stamp.colour.blue:
                        Instantiate(circleBlue, Stamp.body.position, Quaternion.identity, this.transform);
                        newshape.specColour = Shapes.colour.blue;
                        newshape.specType = Shapes.shapeType.circle;
                        break;
                    case stamp.colour.red:
                        Instantiate(circleRed, Stamp.body.position, Quaternion.identity, this.transform);
                        newshape.specColour = Shapes.colour.red;
                        newshape.specType = Shapes.shapeType.circle;
                        break;
                }
                break;
            case stamp.shape.square:
                switch (col)
                {
                    case stamp.colour.green:
                        Instantiate(squareGreen, Stamp.body.position, Quaternion.identity, this.transform);
                        newshape.specColour = Shapes.colour.green;
                        newshape.specType = Shapes.shapeType.square;
                        break;
                    case stamp.colour.blue:
                        Instantiate(squareBlue, Stamp.body.position, Quaternion.identity, this.transform);
                        newshape.specColour = Shapes.colour.blue;
                        newshape.specType = Shapes.shapeType.square;
                        break;
                    case stamp.colour.red:
                        Instantiate(squareRed, Stamp.body.position, Quaternion.identity, this.transform);
                        newshape.specColour = Shapes.colour.red;
                        newshape.specType = Shapes.shapeType.square;
                        break;
                }
                break;
        }
        printedShapes.Add(newshape);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "stamp")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Stamp.stampColour != stamp.colour.none)
                {
                    PrintShape(Stamp.stampColour, Stamp.stampShape);
                }
            }
        }
    }

    private void Awake()
    {
        gameManager=FindObjectOfType<GameManager>();
        ordersheet = gameManager.CheckOrderSpaces();
        if (ordersheet == null)
        {
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        Vector2 tempvector=transform.position;
        tempvector.x += startSpeed * Time.deltaTime;
        transform.position = tempvector;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Paper Collision");
        if (collision.gameObject.tag == "conveyorEND")
        {
            ValidatePrint();
            Destroy(ordersheet.gameObject);
            Destroy(this.gameObject);
        }
    }
    private void ValidatePrint()
    {
        if (ordersheet.shapes.Count != printedShapes.Count)
        {
            FailCheck();
        }
        else
        {
            int correctShapes = 0;
            for (int i = 0; i < ordersheet.shapes.Count; i++)
            {
                for (int j=0;j < printedShapes.Count; j++)
                {
                    if ((printedShapes[j].specColour == ordersheet.shapes[i].specColour) && (printedShapes[j].specType == ordersheet.shapes[i].specType))
                    { correctShapes++;
                      break;
                    }
                }
            }
            if (correctShapes == ordersheet.shapes.Count)
                WinCheck();
            else
                FailCheck();
        }
    }
    private void FailCheck()
    {
        Debug.Log("FAIL");
    }
    private void WinCheck()
    {
        Debug.Log("WIN");
    }

}
