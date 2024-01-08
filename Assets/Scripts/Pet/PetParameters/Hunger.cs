using UnityEngine;
using UnityEngine.UI;

public class Hunger : BasePetParameter
{
    private float currentVelocity;
    private Slider _slider;
    public Hunger(int maxValue, int decreaseValuePerSecond, Slider slider) : base(maxValue, decreaseValuePerSecond)
    {
        _slider = slider;
        _slider.value = CurrentValue / MaxValue;
        Debug.Log($"Hunger = {CurrentValue}");
    }

    public override void Tick()
    {
        if (CurrentValue <= 0) return;

        CurrentValue -= DecreaseValuePerSecond;

        if (CurrentValue < 0) CurrentValue = 0;

    }

    public override void UpdateGraphic()
    {
        if (CurrentValue == 0) return;

        float temp = Mathf.SmoothDamp(_slider.value, (CurrentValue * 1f / MaxValue * 1f), ref currentVelocity, 1000 * Time.deltaTime);
        // float temp = (CurrentValue * 1f / MaxValue * 1f);
        _slider.value = temp;
        Debug.Log($"Hunger = {CurrentValue} {temp}");
    }
}
