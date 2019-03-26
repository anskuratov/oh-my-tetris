using System;
using System.Collections;
using UnityEngine;

namespace Assets.Gameplay
{
    [RequireComponent(typeof(Camera))]
    public class CameraViewAdapter : MonoBehaviour
    {
        [SerializeField]
        private Transform _transformToAdaptTo;

        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();

            if (_camera == null)
            {
                Debug.LogError("Required component was not found!");
                return;
            }

            StartCoroutine(AdaptCameraViewWithDelay(2f));
        }

        private IEnumerator AdaptCameraViewWithDelay(float delayInSeconds)
        {
            yield return new WaitForSeconds(delayInSeconds);
            AdaptCameraView();
        }

        private void AdaptCameraView()
        {
            var playingFieldTransform = _transformToAdaptTo.GetChild(0);

            var lastChildrenPosition =
                playingFieldTransform.GetChild(playingFieldTransform.childCount - 1).localPosition;

            _camera.transform.position =
                new Vector3(
                lastChildrenPosition.x / 2,
                lastChildrenPosition.y / 2,
                _camera.transform.position.z);

            _camera.orthographicSize =
                Math.Max(lastChildrenPosition.x, lastChildrenPosition.y) + 2;
        }
    }
}