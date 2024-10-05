using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float playTimer=0;
    public float gameSpeed=1;
    public GameObject paperPrefab;
    public float newOrderCountdown = 0;
    public float timeBetweenOrders = 8;
    public GameObject[] orderSpaces;
    public GameObject orderPrefab;
    void Update()
    {
        playTimer += Time.deltaTime;
        newOrderCountdown-=Time.deltaTime;
        if (newOrderCountdown <= 0)
        {
            Debug.Log("SPAWN PAPER");
            Instantiate(paperPrefab);
            newOrderCountdown = 5;
        }
        if (playTimer>=20)
            UpdateGameTime();

    }
    void UpdateGameTime()
    {
        playTimer = 0;
        gameSpeed += 0.2f;
        timeBetweenOrders/= gameSpeed;
    }
    public Ordersheet CheckOrderSpaces()
    {
        bool foundspace = false;
        int selectedspace = 0;
        for (int i = 0; i < 2; i++)
        {
            if (orderSpaces[i].transform.childCount == 0)
            {
                foundspace = true;
                selectedspace= i;
            }
        }
        if (foundspace)
        {
            GameObject order = Instantiate(orderPrefab, orderSpaces[selectedspace].transform);
            Ordersheet ordersheet = order.GetComponent<Ordersheet>();
            return ordersheet;
        }
        else
        {
            Debug.Log("NO SPACE FOUND");
            return null;
        }
    }
}
