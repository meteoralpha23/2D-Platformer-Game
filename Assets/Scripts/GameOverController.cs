using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    [SerializeField] Button buttonrestart;

    private void Awake()
    {
        buttonrestart.onClick.AddListener(ReloadScene);
    }
    public void PlayerDied()
    {
        
        gameObject.SetActive(true);


    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  
    }
}
