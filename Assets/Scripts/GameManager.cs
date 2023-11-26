using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
    public bool GAMEOVER = false;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text endScoreText;
    [SerializeField] private float timeToAddScore = .1f;
    [SerializeField] private int scoreToAddPerTick = 1;
    private float currentScore;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        Time.timeScale = 1.0f;
        StartCoroutine(AddPassiveScore());
        endPanel.SetActive(false);
    }

    public void FinishGame()
    {
        StopAllCoroutines();
        Time.timeScale = 0;
        endPanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        endScoreText.gameObject.SetActive(true);
        endScoreText.text = currentScore.ToString();
        GAMEOVER = true;
    }
    public void AddScore(int scoreToADd = 1)
    {
        currentScore += scoreToADd;
        scoreText.text = currentScore.ToString(); 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private IEnumerator AddPassiveScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToAddScore);
            AddScore(scoreToAddPerTick);
        }     
    }

}
