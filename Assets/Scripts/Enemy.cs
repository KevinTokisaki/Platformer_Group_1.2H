using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    Vector3 pos;

    // Define the animation component
    Animator ani;

    // Define the navigation agent component
    NavMeshAgent m_agent;

    // Define a player object
    GameObject m_player;
    // Character movement speed
    public float m_moveSpeed = 0.5f;
    // Character rotation speed
    public float m_rotSpeed = 120;
    // Define health value
    public int m_life = 100;

    public int damage = 50; // Damage taken from the player

    // Define the timer
    public float m_timer = 2;
    private float timer;
    private bool isAttack;

    public float distance; // Distance

    // public Image blood; // Health bar
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
        // Initialize the animation component as m_ani
        ani = this.GetComponent<Animator>();

        // Initialize the NavMeshAgent component as m_agent
        m_agent = GetComponent<NavMeshAgent>();

        // Initialize the player object
        m_player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    void Update()
    {
        if (isDie)
        {
            return;
        }
        currentState = ani.GetCurrentAnimatorStateInfo(0);
        // Call the navigation function to make the enemy move
        MoveTo();
    }

    // Enemy automatic navigation function
    void MoveTo()
    {
        // Define the enemy's movement speed
        float speed = m_moveSpeed * Time.deltaTime;
        distance = (transform.position - m_player.transform.position).magnitude;
        if (distance < 3 && distance > 0.5f)
        {
            ani.SetBool(walkID, true);
            m_agent.isStopped = false;
            // Set the destination of the enemy for the navigation agent
            m_agent.SetDestination(m_player.transform.position);
            // Use the navigation agent's Move() method for movement
            m_agent.Move(transform.TransformDirection(new Vector3(0, 0, speed)));
        }
        else
        {
            ani.SetBool(walkID, false);
            m_agent.SetDestination(pos);
            // Use the navigation agent's Move() method for movement
            m_agent.Move(transform.TransformDirection(new Vector3(0, 0, speed)));
        }
    }

    // Take damage
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
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.instance.PlayAudio("attack");
            GameCtrl.instance.SetHP();
        }
    }
}
