using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] public GameObject gameOver;
    public float score;
    public int scoreCoin;

    public Text scoreText;
    public Text scoreCoinText;
    private Player player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }



    // Start is called once per frame
    void Update()
    {
        if (!player.isDead)
        {
            score += Time.deltaTime * 5f;
            scoreText.text = Mathf.Round(score).ToString() + "m";
        }
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
    public void AddCoin()
    {
        scoreCoin++;
        scoreCoinText.text = scoreCoin.ToString();
    }

    public void Restart()
    {
        gameOver.SetActive(true);
        SceneManager.LoadScene("Ocean");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}