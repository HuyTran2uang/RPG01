using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;

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
        _player = GameObject.FindWithTag("Player");
    }
}
