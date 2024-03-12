using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotificationManager : MonoBehaviour
{
    /// <summary>
    /// find out if NotificationManager exists in scene, otherwise make it.
    /// </summary>
    public static NotificationManager Instance {
        get
        {
            if (instance != null)
            {
                return instance;
            }
            instance = FindAnyObjectByType<NotificationManager>();
            if (instance != null)
            {
                return instance;
            }
            CreateNewInstance();
            return instance;
        }
    }
    public static NotificationManager CreateNewInstance()
    {
        NotificationManager notificationManagerPrefab = Resources.Load<NotificationManager>("NotificationManager");
        instance = Instantiate(notificationManagerPrefab);

        return instance;
    }
    private static NotificationManager instance;

    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
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
        notificationCoroutine = FadeOutNotification(message);
        StartCoroutine(notificationCoroutine);
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
            yield return null;
        }
    }

}
