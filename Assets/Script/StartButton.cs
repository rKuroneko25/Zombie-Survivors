using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.Play("Title");
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);        
    }

    void TaskOnClick()
    {
        AudioManager.instance.Stop("Title");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
