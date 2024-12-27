using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject objSet;
    public Button btnReplay, btnExit;
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

        btnReplay.onClick.AddListener(()=> 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            objSet.SetActive(false);
        });
        btnExit.onClick.AddListener(()=> 
        {
            Application.Quit();
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            objSet.SetActive(true);
            
        }
    }

}
