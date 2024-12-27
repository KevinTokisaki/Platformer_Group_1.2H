using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartCtrl : MonoBehaviour
{
    public Button btnStart;
    public Button LevelEasy;
    public Button BtnDifficulty;
    public GameObject Selection;

    void Start()
    {
        btnStart.onClick.AddListener(()=> 
        {
            SceneManager.LoadScene("Level 1(Woo)");
        });

    }
}
