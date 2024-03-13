using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotificationManager : MonoBehaviour
{
    /// <summary>
    /// check if instance is not empty, then return it.
    /// </summary>
    public static NotificationManager Instance {
        get
        {
            if (instance != null)
            {
                return instance;
            }
            instance = FindAnyObjectByType<NotificationManager>();            
            return instance;
        }
    }

    private static NotificationManager instance;
    /// <summary>
    /// set text and make it fade out
    /// </summary>
    [SerializeField] private TextMeshProUGUI notificationText;
    [SerializeField] private float fadeTime;

    private IEnumerator notificationCoroutine;

    public void SetNewNotification(string message)
    { 
        if (notificationCoroutine != null)
        {
            StopCoroutine(notificationCoroutine);
        }
        StartCoroutine(FadeOutNotification(message));
    }
    private IEnumerator FadeOutNotification(string message)
    {
        notificationText.text = message;
        float t = 0;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            notificationText.color = new Color(notificationText.color.r,
                notificationText.color.g,
                notificationText.color.b,
                Mathf.Lerp(1f, 0f, t / fadeTime));
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

}