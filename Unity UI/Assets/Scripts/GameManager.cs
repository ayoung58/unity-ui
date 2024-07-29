using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOver;
    public List<GameObject> targets;
    public float timeBetweenTargets = 1;
    public TextMeshProUGUI scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargets());
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOver.gameObject.SetActive(true);
    }

    IEnumerator SpawnTargets() {
        while(true) {
            yield return new WaitForSeconds(timeBetweenTargets);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
        
    }
}
