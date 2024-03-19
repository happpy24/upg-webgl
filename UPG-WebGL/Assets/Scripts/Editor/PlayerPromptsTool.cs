using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class PlayerPromptsTool : EditorWindow
{
    private int chosenPlayer = 1;
    private PlayerPrompts simulatedPrompt;
    private bool[] directions = new bool[4];
    private bool SendButton = false;


    [MenuItem("Tools/Player prompts")]
    public static void ShowWidnow()
    {
        GetWindow(typeof(PlayerPromptsTool));
    }

    private void OnGUI()
    {

        GUILayout.Label("Simulate game prompt", EditorStyles.boldLabel);

        chosenPlayer = EditorGUILayout.IntSlider("Player to give prompt", chosenPlayer, 1, 4);

        GUILayout.Label("Prompt to simulate", EditorStyles.boldLabel);
        simulatedPrompt = (PlayerPrompts)EditorGUILayout.EnumPopup(simulatedPrompt);

        CheckSelectedEnum(simulatedPrompt);
    }

    private void CheckSelectedEnum(PlayerPrompts prompt)
    {
        switch (prompt)
        {
            case PlayerPrompts.chooseDirection:
                ChooseDirectionlayout();
            break;

            case PlayerPrompts.playCard:

            break; 

            case PlayerPrompts.throwDice:

            break;
        }

        SendData<PlayerPromptChooseDirection>();
    }

    //UI that handles the direction choosing I am so sorry for how this looks I have sinned
    private void ChooseDirectionlayout()
    {
        GUILayout.FlexibleSpace();
        GUILayout.BeginHorizontal();
            GUILayout.Space(position.width/2.5f);
            GUILayout.BeginVertical();
            AddDirection("Up", 0, 35);
                GUILayout.BeginHorizontal();
                GUILayout.Space(-20);
                AddDirection("Left", 3, 35);
                AddDirection("Right", 1, 35);
                GUILayout.EndHorizontal();
            AddDirection("Down", 2, 35);
            GUILayout.FlexibleSpace();
                GUILayout.BeginHorizontal();
                GUILayout.Space(-55);
                SendButton = GUILayout.Button("SendPrompt", GUILayout.Width(200));
                GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }

    //simple Function thats adds a new checkbox for the direction
    private void AddDirection(string directionText, int directionValue, float space)
    {
        directions[directionValue] = GUILayout.Toggle(directions[directionValue], directionText, GUILayout.Width(50));
    }

    private void SendData<promptState>() where promptState : State
    {
        if (SendButton)
        {
            StateManager stateManager = FindObjectOfType<StateManager>();
            promptState prompt = FindObjectOfType<promptState>();  


            if (stateManager != null)
            {
                stateManager.currentState = prompt;
            }
        }
    }

}
