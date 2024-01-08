using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    [SerializeField] private Slider _energySlider;
    [SerializeField] private Slider _hungerSlider;
    //private Energy _parameter;
    private List<BasePetParameter> _parametres;
    private float _time;

    void Awake()
    {
        _parametres = new List<BasePetParameter>();

        BasePetParameter parameter = new Energy(75, 2, _energySlider);
        _parametres.Add(parameter);
        parameter = new Hunger(100, 1, _hungerSlider);
        _parametres.Add(parameter);
    }

    
    void Update()
    {
        TickParameters();

        UpdateParametersGraphic();
    }

    private void TickParameters()
    {
        _time += Time.deltaTime;
        if (_time >= 1)
        {
            foreach (BasePetParameter parameter in _parametres)
            {
                parameter.Tick();
            }
            _time = 0;
        }
    }

    private void UpdateParametersGraphic() 
    {
        foreach (BasePetParameter parameter in _parametres)
        {
            parameter.UpdateGraphic();
        }
    }
}
