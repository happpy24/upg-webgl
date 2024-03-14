using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNotif : MonoBehaviour
{
    /// <summary>
    /// get name and set it to player name
    /// </summary>
    void Start()
    {
        name = "TestName";
        //name = activePlayer.name;
        //activePlayer = player with name (activePlayer.name)
        if (name == null)
        {
            NotificationManager.Instance.SetNewNotification("Error");
        }

    }
    /// <summary>
    /// tell player(s) it whose turn it is
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            NotificationManager.Instance.SetNewNotification($"{name}'s Turn");
        }
    }
}
