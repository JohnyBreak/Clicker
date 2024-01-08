using System;

public interface IClickHandler
{
    public event Action<double> ClickEvent;

    public void Click(double amount);
}
