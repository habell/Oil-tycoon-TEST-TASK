using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSystem : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed = 1;
    [SerializeField] private float _jumpMax = 100;
    [SerializeField] private Vector3 _direction;
    private float _yDefault; // в целом можно и проверять просто на 0, но это на случай если стандартная координата каким-то магическим образом изменится
    private bool _jumpStop;

    void Start()
    {
        _yDefault = _direction.y;
    }
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");
        if (x != 0)
            transform.Rotate(0, x, 0); // я столько себе мозг компосировал, забыл как делать поворот, на месте этой строчки было 30 строк моей часовой огонии и идиотских попыток крутить объект хз как..

        // логика прыжка
        if (Input.GetKeyUp(KeyCode.Space)) _jumpStop = true;
        if (Input.GetKey(KeyCode.Space) && !_jumpStop)
        {
            gameObject.transform.position += new Vector3(0, Time.deltaTime * _jumpSpeed, 0);
            if (gameObject.transform.position.y >= _jumpMax) _jumpStop = true;
        }
        else
        {
            if (_yDefault < gameObject.transform.position.y)
            {
                gameObject.transform.position -= new Vector3(0, Time.deltaTime * _jumpSpeed, 0);
                if (gameObject.transform.position.y <= _yDefault) _jumpStop = false;
            }
        }
        gameObject.GetComponent<Rigidbody>().freezeRotation = true; // блокируем самостоятельный поворот
    }

    private void FixedUpdate()
    {
        Vector3 moveSpeed = _direction * _speed * Time.deltaTime;
        transform.Translate(moveSpeed);
    }
}
