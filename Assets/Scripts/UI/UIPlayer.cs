using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    [SerializeField] private Slider _sliderHealthBar;
    [SerializeField] private Text _textHealth;

    private void Awake()
    {
        LoadComponent();
    }

    private void Reset()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        _sliderHealthBar = transform.Find("HealthBar").GetComponent<Slider>();
        _textHealth = _sliderHealthBar.transform.Find("Text").GetComponent<Text>();
    }

    public void SetMaxHealth(int health)
    {
        _sliderHealthBar.maxValue = health;
    }

    public void SetCurrentHealth(int health)
    {
        _sliderHealthBar.value = health;
        _textHealth.text = health.ToString();
    }
}