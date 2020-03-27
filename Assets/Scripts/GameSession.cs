using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameSession : MonoBehaviour
{
    // config params

    [Range(0.1f, 10f)]  [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    // state variables
    [SerializeField] int currentScore = 0;
    

    private void Start()
    {
        scoreText.text = currentScore.ToString();
      //  SceneLoader mySceneLoader = GetComponent<SceneLoader>();
    }

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }


    public void AddToScore()
    {
        //currentScore = currentScore + pointsPerBlockDestroyed; - or-
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);

    }
}
