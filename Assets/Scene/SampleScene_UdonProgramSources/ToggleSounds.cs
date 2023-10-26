using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ToggleSounds : UdonSharpBehaviour
{
    public AudioSource audioSource;
    public float fadeDuration = 2.0f; // Duration for fade out in seconds

    private bool isFadingOut = false;
    private float startVolume;

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player.IsValid())
        {
            if (player.isLocal)
            {
                audioSource.Play();
            }
        }
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if (!player.IsValid() || !player.isLocal) return;
        StartFadeOut();
    }

    private void Update()
    {
        if (isFadingOut)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;

            if (audioSource.volume <= 0)
            {
                audioSource.Pause();  // Pause the audio when volume reaches zero
                audioSource.volume = startVolume; // Reset volume for next time
                isFadingOut = false;
            }
        }
    }

    private void StartFadeOut()
    {
        if (!isFadingOut)
        {
            isFadingOut = true;
            startVolume = audioSource.volume;
        }
    }
}
