using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    private Rigidbody2D _rigidbody2D;
    private void Awake() 
    {
        this._rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        Debug.Log($"Fase: {callbackContext.phase}");// Fases del input action

        float value = callbackContext.ReadValue<float>();
        Debug.Log($"Valor: {value}");

        //if(callbackContext.phase == InputActionPhase.Performed) otra manera
        if (callbackContext.performed)// Comprobamos si se ha realizado la accion
        {
            this._rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
        
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        
        if (callbackContext.performed)// Comprobamos si se ha realizado la accion
        {
            Vector2 move = callbackContext.ReadValue<Vector2>();
            this._rigidbody2D.AddForce(move * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
