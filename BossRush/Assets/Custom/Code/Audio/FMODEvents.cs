using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("BG_music")]
    [field: SerializeField] public EventReference bgMusic { get; private set; }
    [field: Header("Bite")]
    [field: SerializeField] public EventReference snakeBite { get; private set; }
    
    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in this scene");
        }
        instance = this;
    }

}
