using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _options;

    private void Start()
    {
        InputManager.Instance.OnPause?.AddListener(ShowMenu);// La interrogacion sirve para ver si es null
        InputManager.Instance.OnResume?.AddListener(HideMenu);
    }
    
    private void ShowMenu(InputAction.CallbackContext context)
    {
        this._options.SetActive(true);
    }

    private void HideMenu(InputAction.CallbackContext context)
    {
        this._options.SetActive(false);
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnPause?.RemoveListener(ShowMenu);
        InputManager.Instance.OnResume?.RemoveListener(HideMenu);
    }
}
