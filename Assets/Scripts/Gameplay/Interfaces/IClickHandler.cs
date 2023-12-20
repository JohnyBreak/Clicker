using System;

public interface IClickHandler
{
    public event Action<int> ClickEvent;

    public void Click(int amount);
}
