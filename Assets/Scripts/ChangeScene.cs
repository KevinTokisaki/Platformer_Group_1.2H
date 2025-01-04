using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;



    // Start is called before the first frame update
    void Start()
    {
        Button1.onClick.AddListener(change1);
        Button2.onClick.AddListener(change2);
        Button3.onClick.AddListener(change3);
        Button4.onClick.AddListener(change4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change1()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void change2()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void change3()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void change4()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void change5()
    {
        SceneManager.LoadSceneAsync(5);
    }
}
