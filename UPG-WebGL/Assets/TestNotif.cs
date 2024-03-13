using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNotif : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NotificationManager.Instance.SetNewNotification("Test");
        name = "TestName";
        //name = activePlayer.name;
        //activePlayer = player with name (activePlayer.name)
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            NotificationManager.Instance.SetNewNotification($"{name}'s Turn");
        }
    }
}
