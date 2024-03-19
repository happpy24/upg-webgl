using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPromptChooseDirection : State
{
    [SerializeField] private GameObject directioneUI;


    private void Start()
    {
       // directioneUI.SetActive(true);
    }

    public override State RunCurrentState()
    {
        return this;
    }
}
