using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class paper : MonoBehaviour
{
    public stamp Stamp;
    public List<Shapes> printedShapes = new List<Shapes>();
    public GameObject triangleRed, triangleGreen, triangleBlue;
    public GameObject squareRed, squareGreen, squareBlue;
    public GameObject circleRed, circleGreen, circleBlue;
    public float startSpeed=2f;
    public float currentSpeed;
    public GameObject orderPrefab;
    public GameObject[] orderSpaces;
    public GameManager gameManager;
    Ordersheet ordersheet;
    List<Ordersheet> orders = new List<Ordersheet> ();
    private bool isInInk = false;
    public Vector3 printOffset= new Vector3( 0, 10f,0 );
    public AudioSource printSFX;

    void PrintShape(stamp.colour col,stamp.shape shape)
    {
        printSFX.Play();
        Shapes newshape = new Shapes();
        switch (shape)
        {
            case stamp.shape.triangle:
                switch (col)
                {
                    case stamp.colour.green:
                        Instantiate(triangleGreen, Stamp.body.position, Quaternion.identity,this.transform);
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



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "conveyorEND")
        {
            ValidatePrint();
            orders.Remove(ordersheet);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "stamp")
        { isInInk = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "stamp")
            isInInk = false;
    }

    void Start()
    {
        Stamp = FindObjectOfType<stamp>();
        gameManager = FindObjectOfType<GameManager>();
        ordersheet = gameManager.CheckOrderSpaces();
        if (ordersheet == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            orders.Add(ordersheet);
        }
        currentSpeed = startSpeed * gameManager.gameSpeed;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&isInInk)
        {
                if (Stamp.stampColour != stamp.colour.none)
                {
                    PrintShape(Stamp.stampColour, Stamp.stampShape);
                }
        }
        Vector2 tempvector=transform.position;
        tempvector.x += currentSpeed * Time.deltaTime;
        transform.position = tempvector;

    }
    private void ValidatePrint()
    {
        bool correctShapes = false;
        int associatedOrder = 0;
            for (int i = 0; i < orders.Count; i++)
            {

                if (orders[i].shapes.Count != printedShapes.Count)
                {
                    correctShapes = false;
                }
                else
                {
                    orders[i].shapes.Sort();
                    printedShapes.Sort();
                    for (int j = 0; j < printedShapes.Count; j++)
                    {
                        if (printedShapes[j].CompareTo(orders[i].shapes[j]) == 0)
                        {
                            correctShapes = true;
                            associatedOrder = i;
                            break;
                        }
                    if (correctShapes)
                        break;
                    }
                }
            }
        if (correctShapes)
        { 
            gameManager.Success();
            Destroy(orders[associatedOrder].gameObject);
            orders.Remove(orders[associatedOrder]);
        }
        else
            gameManager.Fail();
    }

}
