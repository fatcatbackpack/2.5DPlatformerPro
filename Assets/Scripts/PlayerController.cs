using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float gravity = 1.0f;
    [SerializeField]
    private float _jump = 50.0f;
    private float _yVelocity;
    [SerializeField]
    private bool _canDoubleJump = false;
    [SerializeField]
    private int _playerCoins;

    private UIManager _uiManager;
    [SerializeField]
    private int _lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("UI manager is null");
        }

        _uiManager.UpdateLivesDisplay(_lives);

        _playerCoins = 0;
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
                _yVelocity = _jump;
                _canDoubleJump = true;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(_canDoubleJump == true)
                {
                    _yVelocity = 0 + _jump;
                    _canDoubleJump = false;
                }
            }
            _yVelocity -= gravity;
        }

        velocity.y = _yVelocity;
        
        _controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoin()
    {
        _playerCoins++;

        _uiManager.UpdateCoinDisplay(_playerCoins);
    }

    public void Damage()
    {
        _lives--;

        _uiManager.UpdateLivesDisplay(_lives);

        if(_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
