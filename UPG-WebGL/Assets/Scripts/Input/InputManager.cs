using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public delegate void EnvironmentChange(EnvironmentBackgroundData backgroundData);
    public static event EnvironmentChange onEnvironmentChange;

    public EnvironmentBackgroundData[] backgroundData;

    public GameObject testWindow = null;

    InputControls inputs;

    int i = 0;

    private void OnEnable()
    {
        inputs.Enable();
        
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    public void Awake()
    {
        inputs = new InputControls();

        inputs.DesktopControls.NextAreaTest.performed += ctx => Clicked(ctx);
        inputs.DesktopControls.NextAreaTest.performed += ctx => SpaceBar(ctx);

    }

    private void Start()
    {
        onEnvironmentChange.Invoke(backgroundData[0]);
    }

    private void Clicked(InputAction.CallbackContext context)
    {

        if(i < backgroundData.Length - 1)
        {
            i++;
            onEnvironmentChange.Invoke(backgroundData[i]);
        }
        else
        {
            i = 0;
            onEnvironmentChange.Invoke(backgroundData[0]);
        }
    }
    
    //this is for testing and won't be permanent very simply coded
    private void SpaceBar(InputAction.CallbackContext context)
    {
    }
}
