using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] 
    Transform[] possibleSpawnPoints;
    [SerializeField]
    TMP_Text ScoreText;
    int level = 1, score =0, newScore;
    string key = "", name = "";
    private static string currKey = "currKey";
    string levelKey = "levelKey";
    private static string saveLevel1Key = "saveLevel1";
    private static string saveLevel2Key = "saveLevel2";
    private static string saveLevel3Key = "saveLevel3";
    private static string saveScore1Key = "saveScore1";
    private static string saveScore2Key = "saveScore2";
    private static string saveScore3Key = "saveScore3";

    // Start is called before the first frame update
    void Start()
    {
        key = PlayerPrefs.GetString(currKey);
        levelKey = GetLevelKey(key);
        name = PlayerPrefs.GetString(key);
        score = PlayerPrefs.GetInt(GetScoreKey(key));
        newScore = score;
        level = PlayerPrefs.GetInt(levelKey);
        for (int i = 0; i < level * 2; i++) {
            int r = Random.Range(0, possibleSpawnPoints.Length);
            var rotationVector = transform.rotation.eulerAngles;
            GameObject bullet = Instantiate(Resources.Load("Enemy"), possibleSpawnPoints[r].transform.position, Quaternion.Euler(rotationVector)) as GameObject;
        }
    }

    string GetLevelKey(string key)
    {
        string str = "";
        switch (key)
        {
            case "saveGame1":
                str = saveLevel1Key;
                break;
            case "saveGame2":
                str = saveLevel2Key;
                break;
            case "saveGame3":
                str = saveLevel3Key;
                break;
        }
        return str;
    }
    string GetScoreKey(string key)
    {
        string str = "";
        switch (key)
        {
            case "saveGame1":
                str = saveScore1Key;
                break;
            case "saveGame2":
                str = saveScore2Key;
                break;
            case "saveGame3":
                str = saveScore3Key;
                break;
        }
        return str;
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene("Level"+level.ToString());
    }
    public void NextLevel() 
    {
        //set it to the next level
        level += 1;
        PlayerPrefs.SetInt(levelKey, level);
        PlayerPrefs.SetInt(GetScoreKey(key), newScore);
        ResetLevel();
    }
    public void Scored()
    {
        newScore += 10;
        ScoreText.text = newScore.ToString();
        FindObjectOfType<AudioController>().CheckEnemyForTransition();
    }
}
