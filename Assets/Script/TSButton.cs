using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TSButton : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.Play("Win");
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);        
    }

    void TaskOnClick()
    {
        AudioManager.instance.Stop("Win");
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScreen");
    }
}
