using System;
using System.Threading.Tasks;
using UnityEngine;

public class AnimationsLoaderBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _loadingCanvasTransform;

    [SerializeField]
    private GameObject _loadingScreenPrefab;

    [SerializeField]
    private GameObject _successfulNotificationPrefab;

    [SerializeField]
    private GameObject _failedNotificationPrefab;

    [SerializeField]
    private int _notificationLifetimeDurationInSeconds = 3;

    private GameObject _loadingScreenObject;

    public void StartLoading() =>
        _loadingScreenObject = Instantiate(_loadingScreenPrefab, transform);

    public void StopLoading() =>
        Destroy(_loadingScreenObject);

    public async Task ShowSuccessScreenAsync()
        => await ShowInfoScreenAsync(_successfulNotificationPrefab);

    public async Task ShowFailedScreenAsync()
        => await ShowInfoScreenAsync(_failedNotificationPrefab);

    private async Task ShowInfoScreenAsync(GameObject screenPrefab)
    {
        var infoScreen = Instantiate(screenPrefab, transform);

        await Task.Delay(TimeSpan.FromSeconds(_notificationLifetimeDurationInSeconds));

        Destroy(infoScreen);
    }
}