using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float speed = 5.0f;

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


        _controller.Move(velocity * Time.deltaTime);
    }
}
