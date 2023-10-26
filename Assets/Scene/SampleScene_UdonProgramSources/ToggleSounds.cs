using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ToggleSounds : UdonSharpBehaviour
{
    public AudioSource audioSource;
    public float fadeDuration = 2.0f;

    private bool isFadingOut = false;
    private bool isFadingIn = false;
    private float startVolume;

    private void Start()
    {
        startVolume = audioSource.volume;
        audioSource.volume = 0;  // Assume the audio source starts silent.
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player.IsValid())
        {
            if (player.isLocal)
            {
                StartFadeIn();
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
                audioSource.Pause();  
                audioSource.volume = 0;
                isFadingOut = false;
            }
        }
        else if (isFadingIn)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeDuration;

            if (audioSource.volume >= startVolume)
            {
                audioSource.volume = startVolume;
                isFadingIn = false;
            }
        }
    }

    private void StartFadeOut()
    {
        if (!isFadingOut)
        {
            isFadingOut = true;
            isFadingIn = false; // Stop fading in if it was occurring
        }
    }

    private void StartFadeIn()
    {
        if (!isFadingIn)
        {
            audioSource.UnPause();  // Ensure the audio starts playing if it was paused
            isFadingIn = true;
            isFadingOut = false;  // Stop fading out if it was occurring
        }
    }
}
