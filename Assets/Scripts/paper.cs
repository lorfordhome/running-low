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

    public GameObject triangleRed, triangleGreen, triangleBlue;
    public GameObject squareRed, squareGreen, squareBlue;
    public GameObject circleRed, circleGreen, circleBlue;
    public float startSpeed=0.5f;
    public int currentSpeed;

    void PrintShape(stamp.colour col,stamp.shape shape)
    {
        switch (shape)
        {
            case stamp.shape.triangle:
                switch (col)
                {
                    case stamp.colour.green:
                        Instantiate(triangleGreen, Stamp.body.position,Quaternion.identity,this.transform);
                        break;
                    case stamp.colour.blue:
                        Instantiate(triangleBlue, Stamp.body.position, Quaternion.identity, this.transform);
                        break;
                    case stamp.colour.red:
                        Instantiate(triangleRed, Stamp.body.position, Quaternion.identity, this.transform);
                        break;
                }
                break;
            case stamp.shape.circle:
                switch (col)
                {
                    case stamp.colour.green:
                        Instantiate(circleGreen, Stamp.body.position, Quaternion.identity, this.transform);
                        break;
                    case stamp.colour.blue:
                        Instantiate(circleBlue, Stamp.body.position, Quaternion.identity, this.transform);
                        break;
                    case stamp.colour.red:
                        Instantiate(circleRed, Stamp.body.position, Quaternion.identity, this.transform);
                        break;
                }
                break;
            case stamp.shape.square:
                switch (col)
                {
                    case stamp.colour.green:
                        Instantiate(squareGreen, Stamp.body.position, Quaternion.identity, this.transform);
                        break;
                    case stamp.colour.blue:
                        Instantiate(squareBlue, Stamp.body.position, Quaternion.identity, this.transform);
                        break;
                    case stamp.colour.red:
                        Instantiate(squareRed, Stamp.body.position, Quaternion.identity, this.transform);
                        break;
                }
                break;
        }
    }

    private void OnMouseDown()
    {
        if (Stamp.stampColour != stamp.colour.none)
        {
            PrintShape(Stamp.stampColour, Stamp.stampShape);
        }
    }

    private void Awake()
    {
        
    }
    void Update()
    {
        Vector2 tempvector=transform.position;
        tempvector.x += startSpeed * Time.deltaTime;
        transform.position = tempvector;

    }
}
