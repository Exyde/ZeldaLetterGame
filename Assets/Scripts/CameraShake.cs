using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private Vector3 _originalPos;
    public static CameraShake _instance;

    void Awake()
    {
        _originalPos = transform.localPosition;

        _instance = this;
    }

    public static void Shake (float duration, float amount) {
        _instance.StopAllCoroutines();
        _instance.StartCoroutine(_instance.cShake(duration, amount));
    }

    public static void PlaySound(AudioClip clip, float volume = 1.0f){
        GameObject go = new GameObject();
        AudioSource ad = go.AddComponent<AudioSource>();
        ad.clip = clip;
        ad.volume = volume;
        ad.Play();
        Destroy(go, clip.length);
    }

    public IEnumerator cShake (float duration, float amount) {
        float endTime = Time.time + duration;

        while (Time.time < endTime) {
            transform.localPosition = _originalPos + Random.insideUnitSphere * amount;

            duration -= Time.deltaTime;

            yield return null;
        }

        transform.localPosition = _originalPos;
}

}