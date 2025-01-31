using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ChargeBarScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] 
    private Slider slider;
    [SerializeField]
    Attacks attack;
    bool isHolding;
    float damage = 2;

    // Update is called once per frame
    void Update()
    {
        if (isHolding) 
        {
            slider.value += (Time.deltaTime * 2f);
            if(slider.value > 5)
            {
                slider.value = 5;
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
            if(slider.value >= 1)
                damage *= slider.value;
            attack.shoot(damage);
            damage = 100;
            slider.value = 0f;
        }
    }
}
