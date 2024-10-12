using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class Ordersheet : MonoBehaviour
{
    public List<Shapes> shapes = new List<Shapes>();
    public List<GameObject> shapeSpaces;
    public GameObject triangleRed, triangleGreen, triangleBlue;
    public GameObject squareRed, squareGreen, squareBlue;
    public GameObject circleRed, circleGreen, circleBlue;
    GameObject shapeobj;
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
                        shapeobj=Instantiate(triangleGreen, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                    case Shapes.colour.blue:
                        shapeobj = Instantiate(triangleBlue, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                    case Shapes.colour.red:
                        shapeobj = Instantiate(triangleRed, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                }
                shapeobj.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
                break;
            case Shapes.shapeType.circle:
                switch (col)
                {
                    case Shapes.colour.green:
                        shapeobj = Instantiate(circleGreen, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                    case Shapes.colour.blue:
                        shapeobj = Instantiate(circleBlue, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                    case Shapes.colour.red:
                        shapeobj = Instantiate(circleRed, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                }
                shapeobj.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
                break;
            case Shapes.shapeType.square:
                switch (col)
                {
                    case Shapes.colour.green:
                        shapeobj = Instantiate(squareGreen, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                    case Shapes.colour.blue:
                        shapeobj = Instantiate(squareBlue, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                    case Shapes.colour.red:
                        shapeobj = Instantiate(squareRed, shapeSpaces[i].transform.position, Quaternion.identity, this.transform);
                        break;
                }
                shapeobj.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
        }
    }
}
