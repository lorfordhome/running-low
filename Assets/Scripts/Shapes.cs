using UnityEngine;

public class Shapes : MonoBehaviour
{
    public enum colour
    {
        red, green, blue
    }
    public enum shapeType
    {
        circle, triangle, square
    }

    public colour specColour;
    public shapeType specType;

    private void Awake()
    {
        int col = Random.Range(1, 4);
        int typ = Random.Range(1, 4);

        setColour(col);
        setType(typ);
    }
    private void setColour(int rand)
    {
        switch (rand)
        {
            case 1:
                specColour = colour.red;
                break;
            case 2:
                specColour = colour.green;
                break;
            case 3:
                specColour = colour.blue;
                break;
        }
    }
    private void setType(int rand)
    {
        switch (rand)
        {
            case 1:
                specType = shapeType.circle;
                break;
            case 2:
                specType = shapeType.triangle;
                break;
            case 3:
                specType = shapeType.square;
                break;
        }
    }
}
