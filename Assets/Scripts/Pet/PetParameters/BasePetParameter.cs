public abstract class BasePetParameter
{
    public int MaxValue { get; protected set; }
    public int DecreaseValuePerSecond { get; protected set; }
    public int CurrentValue { get; protected set; }
    
    public BasePetParameter(int maxValue, int decreaseValuePerSecond)
    {
        MaxValue = maxValue;
        DecreaseValuePerSecond = decreaseValuePerSecond;
        CurrentValue = MaxValue;
    }

    public abstract void Tick();
    public abstract void UpdateGraphic();
}
