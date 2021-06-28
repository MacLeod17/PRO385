using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 2;
    public GameObject shot;

    Vector2 input;

    void Start()
    {
        GetComponent<PlayerInput>().onActionTriggered += HandleAction;
    }

    void Update()
    {
        transform.Translate(input * speed * Time.deltaTime);
    }

    void OnFire()
    {
        Instantiate(shot, transform.position, Quaternion.identity);
    }

    void OnMove(InputValue inputValue)
    {
        input = inputValue.Get<Vector2>();
    }

    void OnMove(InputAction.CallbackContext context) 
    { 
        input = context.ReadValue<Vector2>(); 
    }

    public void HandleAction(InputAction.CallbackContext context) 
    { 
        switch(context.action.name)
        {
            case "Fire":
                OnFire();
                break;
            case "Move":
                OnMove(context);
                break;
        }
    }
}
