using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public float playTimer=0;
    public float gameSpeed=1;
    public GameObject paperPrefab;
    public float newOrderCountdown = 0;
    public float startTimeBetweenOrders = 10;
    public GameObject[] orderSpaces;
    public GameObject orderPrefab;
    public AudioSource winSFX;
    public AudioSource failSFX;
    public List<GameObject> hearts = new List<GameObject>();
    public int health = 3;
    public int score = 0;
    private float timeBetweenOrders = 8;
    public GameObject Score;
    public TextMeshProUGUI scoreText;
    public GameObject startScreen;

    private void Awake()
    {
        startScreen.gameObject.SetActive(true);
        scoreText=Score.GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
        Time.timeScale = 0;
        UnityEngine.Cursor.visible = true;
    }
    public void StartGame()
    {
        startScreen.gameObject.SetActive(false);
        Time.timeScale = 1;
        timeBetweenOrders = startTimeBetweenOrders;
        UnityEngine.Cursor.visible = false;
    }
    void Update()
    {
        playTimer += Time.deltaTime;
        newOrderCountdown-=Time.deltaTime;
        if (newOrderCountdown <= 0)
        {
            Debug.Log("SPAWN PAPER");
            Instantiate(paperPrefab);
            newOrderCountdown = timeBetweenOrders;
        }
        if (playTimer>=20&&gameSpeed<2.5f)
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
        for (int i = 0; i < orderSpaces.Length; i++)
        {
            if (orderSpaces[i].transform.childCount == 0)
            {
                foundspace = true;
                selectedspace= i;
                break;
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
    public void Success()
    {
        Debug.Log("WIN");
        winSFX.Play();
        score += 1;
        scoreText.text = score.ToString();
    }
    public void Fail()
    {
        Debug.Log("FAIL");
        failSFX.Play();
        health -= 1;
        if (health > 0)
        {
            Destroy(hearts[0].gameObject);
            hearts.Remove(hearts[0]);
        }
        else
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene("GameOver");
        }
    }  
}
