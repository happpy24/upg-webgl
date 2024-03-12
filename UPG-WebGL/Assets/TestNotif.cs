using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNotif : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NotificationManager.Instance.SetNewNotification("Test");
    }
}
