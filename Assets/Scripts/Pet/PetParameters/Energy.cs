using UnityEngine;
using UnityEngine.UI;

public class Energy : BasePetParameter
{
    private float currentVelocity;
    private Slider _slider;
    public Energy(int maxValue, int decreaseValuePerSecond, Slider slider) : base(maxValue, decreaseValuePerSecond)
    {
        _slider = slider;
        _slider.value = CurrentValue / MaxValue;
        Debug.Log($"Energy = {CurrentValue}");
    }

    public override void Tick()
    {
        if (CurrentValue <= 0) return;

        CurrentValue -= DecreaseValuePerSecond;

        if (CurrentValue < 0) CurrentValue = 0;


        //float temp = Mathf.SmoothDamp(_slider.value, (CurrentValue * 1f / MaxValue * 1f), ref currentVelocity, 100 * Time.deltaTime);
        float temp = (CurrentValue * 1f / MaxValue * 1f) ;
        _slider.value = temp;
        Debug.Log($"Energy = {CurrentValue} {temp}");
    }
}