using UnityEngine;
using System.Collections;
using Unity.Cinemachine;

[RequireComponent(typeof(CinemachineCamera))]
public class CameraController : SingletonMonoBehaviour<CameraController>
{
    [SerializeField] private ParticleSystem speedUpEffect;
    [SerializeField] private float minFOV = 20f;
    [SerializeField] private float maxFOV = 120f;
    [SerializeField] private float zoomDuration = 1f;
    [SerializeField] private float zoomSpeedMultiplier = 5f;

    private CinemachineCamera _cinemachineCamera;

    protected override void Awake()
    {
        base.Awake();
        _cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    public void ChangeCameraFOV(float amount)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeFOVRoutine(amount));

        if (amount > 0)
        {
            speedUpEffect.Play();
        }
    }

    private IEnumerator ChangeFOVRoutine(float amount)
    {
        float startFOV = _cinemachineCamera.Lens.FieldOfView;
        float targetFOV = Mathf.Clamp(startFOV + amount * zoomSpeedMultiplier, minFOV, maxFOV);

        float elapsedTime = 0f;

        while (elapsedTime < zoomDuration)
        {
            float t = elapsedTime / zoomDuration;
            elapsedTime += Time.deltaTime;

            _cinemachineCamera.Lens.FieldOfView = Mathf.Lerp(startFOV, targetFOV, t);
            yield return null;
        }

        _cinemachineCamera.Lens.FieldOfView = targetFOV;
    }
}
