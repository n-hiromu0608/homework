using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody;
    [SerializeField] int _speed;
    bool isStop = false;
    bool isWall = false;
    bool isFeild = true;
    bool isStart = false;
    private Vector3 initialPosition;
    [SerializeField] int jumpForce;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // シーン開始時にプレイヤーの初期位置を記録する
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart == true)
        {
            if (isStop == false)
            {
                if (isFeild == true && isWall == false)
                {
                    _rigidBody.velocity = new Vector3(Input.GetAxis("Horizontal") * _speed, 0, 10);
                }
                else if (isWall == true && isFeild == false)
                {
                    _rigidBody.velocity = new Vector3(0, Input.GetAxis("Vertical") * _speed, 10);
                }
            }
            else
            {
                _rigidBody.velocity = transform.forward * _speed;
            }
        }

        if(transform.position.x < -10)
        {
            transform.position = new Vector3(-10, transform.position.y,transform.position.z);
        }
        if (transform.position.x > 10)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }

        if(transform.position.y < 0.5)
        {
            transform.position = new Vector3(transform.position.x, (float)0.5, transform.position.z);
        }
        if(transform.position.y > 20.5)
        {
            transform.position = new Vector3(transform.position.x, (float)20.5, transform.position.z);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Goal")
        {
            isStop = true;
        }
        else if (collision.gameObject.name == "Wall")
        {
            isWall = true;
            isFeild = false;
        }
        else if(collision.gameObject.name == "Feild")
        {
            isWall = false;
            isFeild = true;
        }

        else if((collision.gameObject.name == "jump"))
        {
            _rigidBody.AddForce( Vector3.right * jumpForce, ForceMode.Impulse);
        }
    }

    public void ResetPlayerPosition()
    {
        // プレイヤーの位置を初期位置に設定する
        transform.position = initialPosition;

        ScoreManager scoreManager = ScoreManager.Instance;
        if (scoreManager != null)
        {
            scoreManager.ResetScore();
        }

        isStart = false;
        isStop = false;
    }

    public void StartPlayer()
    {
        isStart = true;
        isStop = false;
    }
}
