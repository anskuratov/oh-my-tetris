using System;
using System.Threading.Tasks;
using UnityEngine;

public class AnimationsLoaderBehaviour : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Loading canvas transform")]
    private Transform _loadingCanvasTransform;

    [SerializeField]
    [Tooltip("Loading screen prefab")]
    private GameObject _loadingScreenPrefab;

    [SerializeField]
    [Tooltip("Successful notification prefab")]
    private GameObject _successfulNotificationPrefab;

    [SerializeField]
    [Tooltip("Failed notification prefab")]
    private GameObject _failedNotificationPrefab;

    [SerializeField]
    [Tooltip("Notification lifetime duration in seconds")]
    private int _notificationLifetimeDurationInSeconds = 3;

    private GameObject _loadingScreenObject;

    public void StartLoading() =>
        _loadingScreenObject = Instantiate(_loadingScreenPrefab, _loadingCanvasTransform);

    public void StopLoading() =>
        Destroy(_loadingScreenObject);

    public async Task ShowSuccessScreenAsync()
        => await ShowInfoScreenAsync(_successfulNotificationPrefab);

    public async Task ShowFailedScreenAsync()
        => await ShowInfoScreenAsync(_failedNotificationPrefab);

    private async Task ShowInfoScreenAsync(GameObject screenPrefab)
    {
        var infoScreen = Instantiate(screenPrefab, _loadingCanvasTransform);

        await Task.Delay(TimeSpan.FromSeconds(_notificationLifetimeDurationInSeconds));

        Destroy(infoScreen);
    }
}