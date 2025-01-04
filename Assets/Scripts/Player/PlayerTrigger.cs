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
            AudioManager.instance.PlayAudio("coin");
            GameCtrl.instance.SetCoin();
        }
        else if (other.tag == "Sea")
        {
            GameCtrl.instance.SetFail();
        }
        else if (other.tag == "Trap")
        {
            GameCtrl.instance.SetHP();
        }
        else if (other.tag == "Heart")
        {
            GameCtrl.instance.Heal(1); 
            Destroy(other.gameObject);
        }
        else if (other.tag == "Key")
        {
            GameCtrl.instance.SetKeys(1); 
            Destroy(other.gameObject);
        }
    }

}
