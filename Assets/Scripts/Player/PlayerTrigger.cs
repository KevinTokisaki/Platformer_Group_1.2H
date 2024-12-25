using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            AudioManager.instance.PlayAudio("���");
            GameCtrl.instance.SetCoin();
        }
        else if (other.tag == "Sea")
        {
            Destroy(gameObject);
            GameCtrl.instance.SetFail();
        }
        else if (other.tag == "Trap")
        {
            GameCtrl.instance.SetHP();
        }
        else if (other.tag == "Spring")
        {
        }
    }

}
