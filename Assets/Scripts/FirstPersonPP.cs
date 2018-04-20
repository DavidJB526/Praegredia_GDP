using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FirstPersonPP : MonoBehaviour
{
    [SerializeField]
    Player player;

    Vignette vignette;
    ChromaticAberration chromaticAberration;
    PostProcessVolume volume;

    // Use this for initialization
    void Start ()
    {
        volume = gameObject.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out chromaticAberration);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        CheckStamina();
        CheckHealth();
	}

    private void CheckStamina()
    {
        chromaticAberration.intensity.value = 1 - ((player.stamina) / 100);
    }

    private void CheckHealth()
    {
        vignette.intensity.value = (1.0f-(player.health/100.0f))/2;
    }
}
