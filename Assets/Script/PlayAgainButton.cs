using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgainButton : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.Play("GameOver");
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);        
    }

    void TaskOnClick()
    {
        AudioManager.instance.Stop("GameOver");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}