using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class inkPot : MonoBehaviour
{
    int fillMax=3;
    public enum colour { red, green, blue }
    public colour inkColour;
    public stamp stamp;
    public int fillAmount;
    SpriteRenderer spriteRenderer;
    public GameObject fillMeter;
    public Sprite[] meterSprites;


   
    void Start()
    {
        stamp=FindObjectOfType<stamp>();
        fillAmount=fillMax;
        spriteRenderer= GetComponent<SpriteRenderer>();
    }
    private void reduceFill()
    {
        fillAmount--;
        Color temp=this.GetComponent<SpriteRenderer>().color;
        temp.a -= 0.25f;
        spriteRenderer.color=temp;
    }
    private void increaseFill()
    {
        fillAmount = fillMax;
        Color temp = this.GetComponent<SpriteRenderer>().color;
        temp.a = 1;
        spriteRenderer.color = temp;
    }
    public void updateFill(bool isIncrease)
    {
        if (isIncrease)
        {
            increaseFill();
        }
        else
            reduceFill();
        Debug.Log(fillAmount);
        fillMeter.GetComponent<SpriteRenderer>().sprite = meterSprites[fillAmount];
    }

    void Update()
    {

    }
    void OnMouseDown()
    {
        if (fillAmount > 0 && fillAmount!=0) 
        {
            stamp.changeColour((stamp.colour)inkColour);
            updateFill(false);
        }

    }
}
