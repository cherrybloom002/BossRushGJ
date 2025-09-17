using UnityEngine;
using UnityEngine.UI;

public class VCAController : MonoBehaviour
{

    private FMOD.Studio.VCA vcaController;

    public string vcaName;

    private Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vcaController = FMODUnity.RuntimeManager.GetVCA("vca:/" + vcaName);
        slider = GetComponent<Slider>();
    }

    public void SetVolume(float volume)
    {
        vcaController.setVolume(volume);
    }
}
