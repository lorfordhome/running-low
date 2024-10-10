using System;
using UnityEngine;

public class Shapes : IComparable
{
    public int CompareTo(Shapes shape)
    {
        if ((shape.specColour == this.specColour) && (shape.specType == this.specType))
            return 0;
        else
            return 1;
    }
    public int CompareTo(object obj)
    {
        if (obj!.GetType() != typeof(Shapes))
            return 1;
        else
            return 0;
    }
    public enum colour
    {
        red, green, blue
    }
    public enum shapeType
    {
        circle, square,triangle
    }

    public colour specColour;
    public shapeType specType;

    public void randomiseShape()
    {
        int col = UnityEngine.Random.Range(1, 4);
        int typ = UnityEngine.Random.Range(1, 4);

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
