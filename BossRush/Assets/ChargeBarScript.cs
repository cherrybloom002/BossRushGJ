using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ChargeBarScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] 
    private Slider slider;
    bool isHolding;
    float damageMultiplier;

    // Update is called once per frame
    void Update()
    {
        if (isHolding) 
        {
            slider.value += (Time.deltaTime / 2);
            if(slider.value > 1)
            {
                slider.value = 1;
            }
        }
    }

    public void OnHold(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isHolding = true;
        }else if (context.canceled)
        {
            isHolding = false;
            slider.value = 0f;
        }
    }
}
