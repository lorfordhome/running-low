using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class Ordersheet : MonoBehaviour
{
    public List<Shapes> shapes = new List<Shapes>();
    public List<GameObject> shapeSpaces;
    public GameObject shapePrefab;
    public GameObject triangleRed, triangleGreen, triangleBlue;
    public GameObject squareRed, squareGreen, squareBlue;
    public GameObject circleRed, circleGreen, circleBlue;
    private void Awake()
    {
        int shapeNum = Random.Range(1, 4);
        for (int i = 0; i < shapeNum; i++)
        {
            Shapes newShape= new Shapes();
            shapes.Add(newShape);
            shapes[i].randomiseShape();
            RenderShapes(shapes[i].specColour, shapes[i].specType,i);
        }
    }
    private void RenderShapes(Shapes.colour col, Shapes.shapeType shape,int i)
    {
        switch (shape)
        {
            case Shapes.shapeType.triangle:
                switch (col)
                {
                    case Shapes.colour.green:
                        Instantiate(triangleGreen, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                    case Shapes.colour.blue:
                        Instantiate(triangleBlue, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                    case Shapes.colour.red:
                        Instantiate(triangleRed, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                }
                break;
            case Shapes.shapeType.circle:
                switch (col)
                {
                    case Shapes.colour.green:
                        Instantiate(circleGreen, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                    case Shapes.colour.blue:
                        Instantiate(circleBlue, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                    case Shapes.colour.red:
                        Instantiate(circleRed, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                }
                break;
            case Shapes.shapeType.square:
                switch (col)
                {
                    case Shapes.colour.green:
                        Instantiate(squareGreen, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                    case Shapes.colour.blue:
                        Instantiate(squareBlue, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                    case Shapes.colour.red:
                        Instantiate(squareRed, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                }
                break;
        }
    }
}
