using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class LevelManager : MonoBehaviour
    {

    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string[] Levels;


    public string Level1;

    private void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);  

        }
    }

    private void Start()
    {
        if (GetLevelStatus(Levels[0]) == LevelStatus.locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
     LevelStatus levelstatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);

        return levelstatus;
    }

    public void SetLevelStatus(string level,LevelStatus levelstatus) 
    {
        PlayerPrefs.SetInt(level, (int)levelstatus);
    }        

    public void MarkCurrentLevelComplete()
    {

        Scene currentscene = SceneManager.GetActiveScene();
       SetLevelStatus(currentscene.name, LevelStatus.Completed);

     // int nextSceneIndex = currentscene.buildIndex  + 1;
     // Scene  nextScene =   SceneManager.GetSceneByBuildIndex(nextSceneIndex);
      //  SetLevelStatus(nextScene.name, LevelStatus.Unlocked);

        Array.Find(Levels,level=> level == currentscene.name);
        int nextSceneIndex = currentscene.buildIndex + 1;
        if (nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }

    }
}
