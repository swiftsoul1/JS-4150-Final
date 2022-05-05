using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuController : MonoBehaviour
{
    [SerializeField]
    Button loadButton1;
    [SerializeField]
    Button loadButton2;
    [SerializeField]
    Button loadButton3;
    [SerializeField]
    TMP_InputField nameField;
    private static string currKey = "currKey";
    private static string levelKey = "levelKey";
    private static string saveGame1Key = "saveGame1";
    private static string saveGame2Key = "saveGame2";
    private static string saveGame3Key = "saveGame3";
    private static string saveLevel1Key = "saveLevel1";
    private static string saveLevel2Key = "saveLevel2";
    private static string saveLevel3Key = "saveLevel3";
    private static string saveScore1Key = "saveScore1";
    private static string saveScore2Key = "saveScore2";
    private static string saveScore3Key = "saveScore3";

    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LoadGame"))
        {
            LoadPlayerPrefs();
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
    public void NameScreen(string key)
    {
        PlayerPrefs.SetString(currKey, key);
        SceneManager.LoadScene("NameMenu");
    }
    public void NewGame() 
    {
        if (nameField.text != "")
        {
            //selected save
            string saveKey = PlayerPrefs.GetString(currKey);

            //clear old prefs
            PlayerPrefs.DeleteKey(GetLevelKey(saveKey));
            PlayerPrefs.DeleteKey(GetScoreKey(saveKey));
            PlayerPrefs.DeleteKey(saveKey);

            string name = nameField.text;
            
            string lvl = GetLevelKey(saveKey);
            PlayerPrefs.SetInt(GetLevelKey(saveKey), 0); ;
            PlayerPrefs.SetString(saveKey, name);
            PlayerPrefs.SetInt(lvl, 1);
            PlayerPrefs.SetString(currKey, saveKey);
            SceneManager.LoadScene("Level1");

        }
    }
    public void LoadSave(string saveKey) 
    {
        string lvlKey = GetLevelKey(saveKey);
        int Level = PlayerPrefs.GetInt(lvlKey);
        PlayerPrefs.SetString(currKey, saveKey);
        SceneManager.LoadScene("Level"+Level.ToString());
    }
    public void NewScreen()
    {
        SceneManager.LoadScene("NewGame");
    }
    public void LoadScreen()
    {
        SceneManager.LoadScene("LoadGame");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Back() 
    {
        SceneManager.LoadScene("MainMenu");
    }
    void LoadPlayerPrefs() 
    {
        if (PlayerPrefs.HasKey(saveGame1Key))
        {
            if (PlayerPrefs.HasKey(saveLevel1Key))
            {
                string name = PlayerPrefs.GetString(saveGame1Key);
                int level = PlayerPrefs.GetInt(saveLevel1Key);
                loadButton1.GetComponentInChildren<TMP_Text>().text = name + " " + level.ToString();
            }
        }
        else
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LoadGame"))
            {
                loadButton1.interactable = false;
            }
            
        }
        if (PlayerPrefs.HasKey(saveGame2Key))
        {
            if (PlayerPrefs.HasKey(saveLevel2Key))
            {
                string name = PlayerPrefs.GetString(saveGame2Key);
                int level = PlayerPrefs.GetInt(saveLevel2Key);
                loadButton1.GetComponentInChildren<TMP_Text>().text = name + " " + level.ToString(); ;
            }
        }
        else
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LoadGame"))
            {
                loadButton2.interactable = false;
            }
        }
        if (PlayerPrefs.HasKey(saveGame3Key))
        {
            if (PlayerPrefs.HasKey(saveLevel3Key))
            {
                string name = PlayerPrefs.GetString(saveGame3Key);
                int level = PlayerPrefs.GetInt(saveLevel1Key);
                loadButton1.GetComponentInChildren<TMP_Text>().text = name + " " + level.ToString();
            }
        }
        else
        {
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LoadGame"))
            {
                loadButton3.interactable = false;
            }
        }

    }
}
