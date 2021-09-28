using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float gravity = 2.0f;
    [SerializeField]
    private float _jump = 50.0f;

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
        Vector3 velocity = direction * speed;
        
        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = _jump;
            }

        }
        else
        {
            velocity.y -= gravity;
        }
        
        _controller.Move(velocity * Time.deltaTime);
    }
}
