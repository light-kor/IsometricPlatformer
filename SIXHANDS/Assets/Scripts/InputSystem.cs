using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public static PlayerInput Input { get; private set; }

    private void Awake()
    {
        Input = new PlayerInput();
        Input.Enable();
    }

    public static void EnablePlayerInput()
    {
        Input.Player.Enable();
    }

    public static void DisablePlayerInput()
    {
        Input.Player.Disable();
    }
}
