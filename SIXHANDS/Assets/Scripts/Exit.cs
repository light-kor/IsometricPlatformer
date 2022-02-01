using UnityEngine;

public class Exit : MonoBehaviour
{
    private void Awake()
    {
        InputSystem.Input.General.ApplicationExit.performed += ctx => Application.Quit();
    }
}
