using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio
{
    public const float DefaultMinDistance = 1.0f;
    public const float DefaultMaxDistance = 20.0f;

    public static void Spawn(AudioClip clip, Vector3 position, float minDistance, float maxDistance)
    {
        GameObject gameObject = new GameObject($"AudioClip ({clip.name})");
        gameObject.transform.position = position;

        AudioSource audioSourceComponent = gameObject.AddComponent<AudioSource>();
        audioSourceComponent.clip = clip;

        GameObject.Destroy(gameObject, clip.length);

        audioSourceComponent.minDistance = minDistance;
        audioSourceComponent.maxDistance = maxDistance;
        audioSourceComponent.spatialBlend = 1.0f;
        audioSourceComponent.rolloffMode = AudioRolloffMode.Custom;
        audioSourceComponent.Play();
    }

    public static void Spawn(AudioClip clip, Vector3 position)
    {
        Spawn(clip, position, DefaultMinDistance, DefaultMaxDistance);
    }
}