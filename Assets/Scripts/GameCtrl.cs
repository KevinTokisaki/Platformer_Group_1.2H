using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameCtrl : MonoBehaviour
{
    public static GameCtrl instance;
    public GameObject objEnd;
    public Text txtEnd;
    public Button btnReplay, btnExit;

    public StartPoint startPoint;

    public int HP;
    public Image imaHP;
    public int numCoin;
    public Text txtCoin;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

        btnReplay.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            startPoint.RespawnPlayer();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        btnExit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    float lastTime;
    public void SetHP()
    {
        if (Time.time - lastTime > 1)
        {
            lastTime = Time.time;
            AudioManager.instance.PlayAudio("����");

            if (HP > 0)
            {
                HP--;
                imaHP.fillAmount = (float)HP / 3;
            }
            if (HP == 0)
            {
                SetFail();
            }
        }

    }

    public void SetCoin()
    {
        numCoin++;
        txtCoin.text = "Get Coin：" + numCoin.ToString();
        if (numCoin == 4)
        {
            SetWin();
        }
    }



    public void SetFail()
    {
        objEnd.SetActive(true);
        txtEnd.text = "You Lose";
        Time.timeScale = 0;
        startPoint.RespawnPlayer();
    }
    private void SetWin()
    {
        objEnd.SetActive(true);
        txtEnd.text = "Victore!!!";
        Time.timeScale = 0;
        startPoint.RespawnPlayer();
    }

}
