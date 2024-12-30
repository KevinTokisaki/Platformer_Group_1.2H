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


    public int HP;
    public Image imaHP;
    public int maxHP = 3;
    public int numCoin;
    [SerializeField] private int maxCoint;
    public Text txtCoin;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        btnReplay.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        btnExit.onClick.AddListener(() =>
        {
            //Time.timeScale = 1; // 确保时间缩放恢复正常
            //Cursor.visible = false; // 隐藏鼠标
            //Cursor.lockState = CursorLockMode.Locked; // 锁定鼠标
            SceneManager.LoadSceneAsync(0).completed += (op) =>
            {
                // 场景加载完成后的回调
                //Time.timeScale = 1;
                //Cursor.visible = false;
                //Cursor.lockState = CursorLockMode.Locked;
            };
        });
    }

    float lastTime;
    public void SetHP()
    {
        if (Time.time - lastTime > 1)
        {
            lastTime = Time.time;
            AudioManager.instance.PlayAudio("hurt");

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

    public void Heal(int healAmount)
    {
 
        HP = Mathf.Min(HP + healAmount, maxHP);
        imaHP.fillAmount = (float)HP / maxHP;
    }

    public void SetCoin()
    {
        numCoin++;
        txtCoin.text = "Get Coin：" + numCoin.ToString();
        if (numCoin == maxCoint)
        {
            SetWin();
        }
    }



    public void SetFail()
    {
        objEnd.SetActive(true);
        txtEnd.text = "You Lose";
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
    private void SetWin()
    {
        objEnd.SetActive(true);
        txtEnd.text = "Victore!!!";
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

}
