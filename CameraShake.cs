using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }
    private CinemachineVirtualCamera cineMachVerCam;
    public float StartingIntensity, StartingFrequency, shakeTimer, shakeTimerTotal;

    private void Awake()
    {
        Instance = this;
        cineMachVerCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float frequency, float time)
    {
        CinemachineBasicMultiChannelPerlin cineMachBasMulPerlin =
            cineMachVerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cineMachBasMulPerlin.m_AmplitudeGain = intensity;
        cineMachBasMulPerlin.m_FrequencyGain = frequency;

        StartingIntensity = intensity;
        StartingFrequency = frequency;
        shakeTimerTotal = time;
        shakeTimer = time;
    }
    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannel =
                cineMachVerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannel.m_AmplitudeGain =
                Mathf.Lerp(StartingIntensity, 0, 1 - (shakeTimer / shakeTimerTotal));
            cinemachineBasicMultiChannel.m_FrequencyGain =
                Mathf.Lerp(StartingFrequency, 0, 1 - (shakeTimer / shakeTimerTotal));

        }

    }
}

