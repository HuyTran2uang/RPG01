using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private UIPlayer _uiPlayer;

    public UIPlayer UIPlayer
    {
        get { return _uiPlayer; }
        private set { _uiPlayer = value; }
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        LoadComponent();
    }

    private void Reset()
    {
        LoadComponent();
    }

    private void LoadComponent()
    {
        UIPlayer = Transform.FindObjectOfType<UIPlayer>();
    }
}
