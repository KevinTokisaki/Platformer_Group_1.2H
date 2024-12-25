using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartCtrl : MonoBehaviour
{
    public Button btnStart;
    void Start()
    {
        btnStart.onClick.AddListener(()=> 
        {
            SceneManager.LoadScene("Game");
        });
    }

}
