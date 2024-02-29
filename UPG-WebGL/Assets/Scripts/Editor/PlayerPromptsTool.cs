using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class PlayerPromptsTool : EditorWindow
{
    private enum SimulatedPrompt
    {
        None,
        chooseDirection,
        playCard,
        throwDice,
        PlayerTurn
    }

    private int chosenPlayer = 1;
    private SimulatedPrompt simulatedPrompt;
    private bool[] directions = new bool[4];

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
        simulatedPrompt = (SimulatedPrompt)EditorGUILayout.EnumPopup(simulatedPrompt);

        CheckSelectedEnum(simulatedPrompt);
    }

    private void CheckSelectedEnum(SimulatedPrompt prompt)
    {
        switch (prompt)
        {
            case SimulatedPrompt.chooseDirection:
                ChooseDirectionlayout();
            break;

            case SimulatedPrompt.playCard:

            break; 

            case SimulatedPrompt.throwDice:

            break;
        }
    }

    //UI that handles the direction choosing
    private void ChooseDirectionlayout()
    {
        GUILayout.BeginHorizontal();
            GUILayout.Space(position.width/2);
            GUILayout.BeginVertical();
            AddDirection("Up", 0, 35);
                GUILayout.BeginHorizontal();
                GUILayout.Space(-20);
                AddDirection("Left", 3, 35);
                AddDirection("Right", 1, 35);
                GUILayout.EndHorizontal();
            AddDirection("Down", 2, 35);
            GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }

    //simple Function thats adds a new checkbox for the direction
    private void AddDirection(string directionText, int directionValue, float space)
    {
        //GUILayout.Space(position.width / Spacing);
        directions[directionValue] = GUILayout.Toggle(directions[directionValue], directionText, GUILayout.Width(50));
    }

}
