using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _moveForce = 3f;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        this._rigidbody2D = GetComponent<Rigidbody2D>();

        InputManager.Instance.OnJump.AddListener(Jump);
    }

    private void Update()
    {
        //EventSystem.current.SetSelectedGameObject(); Poner objeto fijo
        Debug.Log(InputManager.Instance.PlayerInput.currentActionMap);// Valor para ver que ActionMap se esta usando

        Vector2 inputMove = InputManager.Instance.PlayerInput.actions["Move"].ReadValue<Vector2>();// Acedemos al valor de la accion del playerInputs de Move
        this._rigidbody2D.AddForce(inputMove * this._moveForce, ForceMode2D.Impulse);
        Debug.Log(inputMove);

    }

    public void Jump(InputAction.CallbackContext callbackContext)
    {
        Debug.Log($"Fase: {callbackContext.phase}");// Fases del input action

        float value = callbackContext.ReadValue<float>();
        Debug.Log($"Valor: {value}");

        //if(callbackContext.phase == InputActionPhase.Performed) otra manera

        this._rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

    }

    /*public void OnMove(InputAction.CallbackContext callbackContext)
    {
        
        if (callbackContext.performed)// Comprobamos si se ha realizado la accion
        {
            Vector2 move = callbackContext.ReadValue<Vector2>();
            this._rigidbody2D.AddForce(move * _moveForce, ForceMode2D.Impulse);
        }
    }*/
}
