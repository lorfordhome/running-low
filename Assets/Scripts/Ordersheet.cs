using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Ordersheet : MonoBehaviour
{
    public GameObject shape1, shape2, shape3;
    public Shapes shapes;
    private void Awake()
    {
        int shapeNum = Random.Range(1, 4);
        Creator(shape1);
        if (shapeNum > 1)
            Creator(shape2);
        if (shapeNum > 2)
            Creator(shape3);
    }

    private void Creator(GameObject shape)
    {
        Instantiate(shape, this.transform);
    }
}
