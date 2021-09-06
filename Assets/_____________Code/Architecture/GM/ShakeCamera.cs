using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public Pipe_CamShakes pipe;
    [Space]
    public float shakeLength = .05f;

    public Vector3 CurrentDisplacement { get; private set; }

    void Update()
    {
        foreach (var newCamShake in pipe.AwaitingCamShakes)
        {
            Shake(newCamShake);
        }
        pipe.AwaitingCamShakes.Clear();
    }

    public void Shake(ShakeAtributes shakeAtributes)
    {
        StartCoroutine(PerformShake(shakeAtributes));
    }

    IEnumerator PerformShake(ShakeAtributes shakeAtributes)
    {
        float timeStart = Time.timeSinceLevelLoad;
        float PassedTime() => Time.timeSinceLevelLoad - timeStart;
        float GetAmplitude() => Random.Range(-shakeAtributes.amplitude, shakeAtributes.amplitude);
        do
        {
            var newDisplacement = new Vector3(GetAmplitude(), GetAmplitude());
            CurrentDisplacement += newDisplacement;
            yield return new WaitForSeconds(shakeLength);
            CurrentDisplacement = Vector2.zero;

            // wait for next shake
            yield return new WaitForSeconds(Mathf.Max(1 / shakeAtributes.shakesPerSecond, shakeLength));
        } while (PassedTime() < shakeAtributes.duration);
    }
}
