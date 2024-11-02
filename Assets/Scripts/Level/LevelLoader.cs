using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))] 
public class LevelLoader : MonoBehaviour
    {
    private Button button;
    public string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }


    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch(levelStatus)
        {
             case LevelStatus.locked:
                Debug.Log("Cant play this level till you unlocked it");
                break;

            case LevelStatus.Unlocked:
                Debug.Log("Unlocked");
                break;

            case LevelStatus.Completed:
                Debug.Log("Completed");
                break;
        }




        SceneManager.LoadScene(LevelName);
    }
}