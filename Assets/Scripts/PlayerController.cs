using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float HRZInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(HRZInput, 0, 0);

        _controller.Move(direction * Time.deltaTime);
    }
}
