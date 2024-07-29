using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOver;
    public List<GameObject> targets;
    public Button restartButton;
    public float timeBetweenTargets = 1;
    public TextMeshProUGUI scoreText;
    public bool isGameActive;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTargets());
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOver.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    IEnumerator SpawnTargets() {
        while(isGameActive) {
            yield return new WaitForSeconds(timeBetweenTargets);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
