//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputActions/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""228e0af7-d68a-4774-9f13-5fa5cefe065e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1f870be5-4157-4f36-811f-5bc4980e7db1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SimpleShot"",
                    ""type"": ""Button"",
                    ""id"": ""2daa7fd2-4f63-4fe9-a522-984ab0618114"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LaserShot"",
                    ""type"": ""Button"",
                    ""id"": ""828eaa31-3107-4eaa-aa64-a15f63d2dfcd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MagnetPower"",
                    ""type"": ""Button"",
                    ""id"": ""ebd45673-1fcc-4581-8518-4ca9fb2a82a1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b2b43ea3-3abe-4ab9-b6ae-07b52735ca69"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7d7ebec9-e6f1-4081-9423-ecdc562451d5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7f726f01-8a30-4275-ae47-74c61a8c6055"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8ad38d26-a71f-4042-90ca-3f1646fda5c9"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3fea7d2f-12cd-4ae1-bd0e-01a5d38978e7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""db465535-1be7-4d5f-9883-1a4719179922"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0dc8603b-a69d-466b-9d1f-1a7d1c819550"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f4bb9234-ddb8-47ae-948a-bd33e6b095a6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""51184939-8d93-40cb-a510-6c82b786b943"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""131b0a6c-b9d2-48cb-b9ad-f7814151e7ed"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bca05835-fdfb-4dcd-8013-7504f08e15a7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""SimpleShot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48c86773-2bb3-4166-9e6e-37e8a0fa03d4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""LaserShot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9766a6f-dd3d-4835-9de5-43168510abde"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""MagnetPower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""General"",
            ""id"": ""9370a689-7413-4e86-9665-49d19ecd644c"",
            ""actions"": [
                {
                    ""name"": ""ResetLevel"",
                    ""type"": ""Button"",
                    ""id"": ""93a93bbf-9768-4c33-ae20-cb00b3bad3c1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ApplicationExit"",
                    ""type"": ""Button"",
                    ""id"": ""6e60b710-2986-41d1-9452-6f707cf07f45"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5663c930-44e7-487b-8d48-6b22a84f0a9f"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse and Keyboard"",
                    ""action"": ""ResetLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20842d04-0630-41ce-8e7b-2e7b6ae90838"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ApplicationExit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse and Keyboard"",
            ""bindingGroup"": ""Mouse and Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_SimpleShot = m_Player.FindAction("SimpleShot", throwIfNotFound: true);
        m_Player_LaserShot = m_Player.FindAction("LaserShot", throwIfNotFound: true);
        m_Player_MagnetPower = m_Player.FindAction("MagnetPower", throwIfNotFound: true);
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_ResetLevel = m_General.FindAction("ResetLevel", throwIfNotFound: true);
        m_General_ApplicationExit = m_General.FindAction("ApplicationExit", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_SimpleShot;
    private readonly InputAction m_Player_LaserShot;
    private readonly InputAction m_Player_MagnetPower;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @SimpleShot => m_Wrapper.m_Player_SimpleShot;
        public InputAction @LaserShot => m_Wrapper.m_Player_LaserShot;
        public InputAction @MagnetPower => m_Wrapper.m_Player_MagnetPower;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @SimpleShot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSimpleShot;
                @SimpleShot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSimpleShot;
                @SimpleShot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSimpleShot;
                @LaserShot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLaserShot;
                @LaserShot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLaserShot;
                @LaserShot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLaserShot;
                @MagnetPower.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMagnetPower;
                @MagnetPower.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMagnetPower;
                @MagnetPower.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMagnetPower;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @SimpleShot.started += instance.OnSimpleShot;
                @SimpleShot.performed += instance.OnSimpleShot;
                @SimpleShot.canceled += instance.OnSimpleShot;
                @LaserShot.started += instance.OnLaserShot;
                @LaserShot.performed += instance.OnLaserShot;
                @LaserShot.canceled += instance.OnLaserShot;
                @MagnetPower.started += instance.OnMagnetPower;
                @MagnetPower.performed += instance.OnMagnetPower;
                @MagnetPower.canceled += instance.OnMagnetPower;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // General
    private readonly InputActionMap m_General;
    private IGeneralActions m_GeneralActionsCallbackInterface;
    private readonly InputAction m_General_ResetLevel;
    private readonly InputAction m_General_ApplicationExit;
    public struct GeneralActions
    {
        private @PlayerInput m_Wrapper;
        public GeneralActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ResetLevel => m_Wrapper.m_General_ResetLevel;
        public InputAction @ApplicationExit => m_Wrapper.m_General_ApplicationExit;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
            {
                @ResetLevel.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnResetLevel;
                @ResetLevel.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnResetLevel;
                @ResetLevel.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnResetLevel;
                @ApplicationExit.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnApplicationExit;
                @ApplicationExit.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnApplicationExit;
                @ApplicationExit.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnApplicationExit;
            }
            m_Wrapper.m_GeneralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ResetLevel.started += instance.OnResetLevel;
                @ResetLevel.performed += instance.OnResetLevel;
                @ResetLevel.canceled += instance.OnResetLevel;
                @ApplicationExit.started += instance.OnApplicationExit;
                @ApplicationExit.performed += instance.OnApplicationExit;
                @ApplicationExit.canceled += instance.OnApplicationExit;
            }
        }
    }
    public GeneralActions @General => new GeneralActions(this);
    private int m_MouseandKeyboardSchemeIndex = -1;
    public InputControlScheme MouseandKeyboardScheme
    {
        get
        {
            if (m_MouseandKeyboardSchemeIndex == -1) m_MouseandKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse and Keyboard");
            return asset.controlSchemes[m_MouseandKeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSimpleShot(InputAction.CallbackContext context);
        void OnLaserShot(InputAction.CallbackContext context);
        void OnMagnetPower(InputAction.CallbackContext context);
    }
    public interface IGeneralActions
    {
        void OnResetLevel(InputAction.CallbackContext context);
        void OnApplicationExit(InputAction.CallbackContext context);
    }
}
