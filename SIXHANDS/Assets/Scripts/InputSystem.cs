using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static Action MagnetPower;
    public static Action SimpleShot;
    public static Action<bool> LaserShot;
    public static Action Reset;
    private static PlayerInput _input;
    
    private void Awake()
    {
        _input = new PlayerInput();
        _input.Enable();
        
        _input.Player.MagnetPower.performed += ctx => MagnetPower?.Invoke();
        _input.Player.SimpleShot.performed += ctx => SimpleShot?.Invoke();
        _input.Player.LaserShot.started += ctx => LaserShot?.Invoke(true);
        _input.Player.LaserShot.canceled += ctx => LaserShot?.Invoke(false);
        _input.General.ApplicationExit.performed += ctx => Application.Quit();
        _input.General.ResetLevel.performed += ctx => Reset?.Invoke();
    }

    public static void EnablePlayerInput()
    {
        _input.Player.Enable();
    }

    public static void DisablePlayerInput()
    {
        _input.Player.Disable();
    }
    
    public static void EnableAllInput()
    {
        _input.Enable();
    }

    public static void DisableAllInput()
    {
        _input.Disable();
    }
    
    public static Vector2 ReadMoveValue()
    {
        return _input.Player.Move.ReadValue<Vector2>();
    }
}
