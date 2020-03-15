using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public GameObject GameOverText;
    [HideInInspector]
    public bool IsBirdDead = false;
    [HideInInspector]
    public float ScrollingSpeed = -1.5f;

    public Text ScoreText;
    private int Score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (IsBirdDead == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // for Mobile
                }
            }
        }
    }

    public void BirdScored()
    {
        if (IsBirdDead == true)
        {
            return;
        }
        Score++;
        ScoreText.text = "Score : " + Score.ToString();
    }

    public void BirdDied()
    {
        IsBirdDead = true;
        GameOverText.SetActive(true);
    }
}
