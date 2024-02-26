using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//keeps track of the currently active environment
public enum CurrentActiveEnv
{
    plains,
    jungle,
    desert,
    mountain
}
public class Gamemanager : MonoBehaviour
{
    //enum that shows the current active area
    public CurrentActiveEnv currentActiveEnv;

    public EnvironmentBackgroundData currentEnvironmentBackgroundColor;

    public GameObject[] LayoutImages; 

    void Start()
    {
        SetCurrentEnvColor();
    }

    private void Update()
    {
    }
    //sets the colors of the background
    private void SetCurrentEnvColor()
    {
        //make sure the layout images have been set. yes I know this is shit but its simple so why complicate
        if (LayoutImages != null)
        {
            LayoutImages[0].GetComponent<UnityEngine.UI.Image>().color = currentEnvironmentBackgroundColor.primaryColor;
            LayoutImages[1].GetComponent<UnityEngine.UI.Image>().color = currentEnvironmentBackgroundColor.secondaryColor;
            LayoutImages[2].GetComponent<UnityEngine.UI.Image>().color = currentEnvironmentBackgroundColor.secondaryColor;
        }
    }
}
