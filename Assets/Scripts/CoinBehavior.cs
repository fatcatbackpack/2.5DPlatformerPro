using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{


    private void OnTriggerEnter(Collider coinCol)
    {
        if(coinCol.gameObject.tag == "Player")
        {
            PlayerController player = coinCol.GetComponent<PlayerController>();

            if (player != null)
            {
                player.AddCoin();
            }
            
            

            //destroy object
            Destroy(this.gameObject);

            //notify UI
        }
    }
    
}
