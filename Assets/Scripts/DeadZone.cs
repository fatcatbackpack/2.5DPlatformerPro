using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawnPoint;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if(player != null)
            {
                player.Damage();
            }

            CharacterController cc = other.GetComponent<CharacterController>();
            if(cc != null)
            {
                cc.enabled = false;
            }
            other.transform.position = _respawnPoint.transform.position;

            StartCoroutine(CCEnableRoutine(cc));
        }
    }
    IEnumerator CCEnableRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(.5f);
        controller.enabled = true;
    }

}
