using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-100)]
[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerInput _playerInput;
    public PlayerInput PlayerInput { get { return _playerInput; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Instance._playerInput = GetComponent<PlayerInput>();// Asignamos el playerInput
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public UnityEvent<InputAction.CallbackContext> OnJump;

    //Metodo que invoca el evento del Jump
    public void InvokeOnJump(InputAction.CallbackContext context)
    {
        if (context.performed)// Comprobamos si se ha realizado la accion
        {
            OnJump?.Invoke(context);
        }
    }

    public UnityEvent<InputAction.CallbackContext> OnPause;
    public void InvokeOnPause(InputAction.CallbackContext context)
    {

        if (context.performed)// Comprobamos si se ha realizado la accion
        {
            
            _playerInput.SwitchCurrentActionMap("UI");// Cambiamos el actionMap
            Time.timeScale = 0f;

            OnPause?.Invoke(context);
        }
        
    }

    public UnityEvent<InputAction.CallbackContext> OnResume;
    public void InvokeOnResume(InputAction.CallbackContext context)
    {

        if (context.performed)// Comprobamos si se ha realizado la accion
        {
            Debug.Log("Player mierda");
            _playerInput.SwitchCurrentActionMap("Player");// Cambiamos el actionMap
            Time.timeScale = 1f;

            OnResume?.Invoke(context);
        }

    }
}
