using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Vector3 pos;

    //定义动画组件
    Animator ani;

    //定义寻路组件
    NavMeshAgent m_agent;

    //定义一个主角类的对象
    GameObject m_player;
    //角色移动速度
    public  float m_moveSpeed = 0.5f;
    //角色旋转速度
    public float m_rotSpeed = 120;
    //定义生命值
    public int m_life = 100;

    public int damage = 50; // 受到玩家伤害值

    //定义计时器
    public float m_timer = 2;
    private float timer;
    private bool isAttack;

    public float distance; //距离

    //public Image blood; //血条
    public int HP = 3;

    private AnimatorStateInfo currentState;

    private int walkID = Animator.StringToHash("Run");
    private int attackID = Animator.StringToHash("Attack");
    private int dieID = Animator.StringToHash("Die");
    private int damageID = Animator.StringToHash("Damage");

    bool isDie;
    private void Awake()
    {
        pos = transform.position;
    }
    void Start()
    {
        //初始化动画m_ani 为物体的动画组件
        ani = this.GetComponent<Animator>();

        //初始化寻路组件m_agent 为物体的寻路组件
        m_agent = GetComponent<NavMeshAgent>();

        //初始化主角
        m_player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    void Update()
    {
        if (isDie)
        {
            return;
        }
        currentState = ani.GetCurrentAnimatorStateInfo(0);
        //调用寻路函数实现寻路移动
        MoveTo();
    }


    //敌人的自动寻路函数
    void MoveTo()
    {
        //定义敌人的移动量
        float speed = m_moveSpeed * Time.deltaTime;
        distance = (transform.position - m_player.transform.position).magnitude;
        if (distance < 3 && distance >0.5f)
        {
            ani.SetBool(walkID, true);
            m_agent.isStopped = false;
            //设置敌人的寻路目标
            m_agent.SetDestination(m_player.transform.position);
            //通过寻路组件的Move()方法实现寻路移动
            m_agent.Move(transform.TransformDirection(new Vector3(0, 0, speed)));
        }
        //else if (distance < 2)
        //{
        //    ani.SetBool(walkID, false);
        //    m_agent.isStopped = true;

        //    timer += Time.deltaTime;
        //    if (timer > m_timer)
        //    {
        //        ani.SetBool(attackID, true);
        //        timer = 0;
        //    }
        //    else
        //    {
        //        ani.SetBool(attackID, false);
        //    }
        //}
        else
        {
            ani.SetBool(walkID, false);
            m_agent.SetDestination(pos);
            //通过寻路组件的Move()方法实现寻路移动
            m_agent.Move(transform.TransformDirection(new Vector3(0, 0, speed)));
        }
        //if (currentState.shortNameHash == attackID)
        //{
        //    if (!ani.IsInTransition(0))
        //    {
        //        ani.SetBool(attackID, false);
        //    }
        //}
    }

    //受到伤害
    public void TakeDamage()
    {
        HP -= 1;
        if (HP == 0)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    public void SetDie()
    {
        isDie = true;
        ani.SetBool(dieID, true);
        AudioManager.instance.PlayAudio("怪死亡");
        Destroy(gameObject,0.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
        {
            AudioManager.instance.PlayAudio("受伤");
            GameCtrl.instance.SetHP();
        }
    }
}