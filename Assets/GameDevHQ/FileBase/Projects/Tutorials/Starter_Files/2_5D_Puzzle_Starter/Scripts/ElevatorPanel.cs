using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    [SerializeField]
    MeshRenderer _callButton;
    private int _requiredCoins = 8;

    private Elevator _elevator;
    private bool _elevatorCalled = false;


    private void Start()
    {
        _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();

        if (_elevator == null)
        {
            Debug.LogError("the elev is null");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E) && (other.GetComponent<Player>().CoinCount() >= _requiredCoins))
            {
                if(_elevatorCalled == true)
                {
                    _callButton.material.color = Color.red;
                    _elevatorCalled = false;
                }
                else
                {
                    _callButton.material.color = Color.green;
                    _elevatorCalled = true;
                }
                

                _elevator.callElevator();
                
            }
        }
    }


}
