using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject cupFillBar;
    private Vector3 cupStartPos;

    public static UIManager _instance;
    private void Awake()
    {
        if (_instance == null && _instance != this)
        {
            _instance = this;
        }
    }
    private void Start()
    {
        cupStartPos = cupFillBar.transform.position;
    }
    private void Update()
    {
        
    }
    public void ResertBarPosition()
    {
        cupFillBar.transform.position = cupStartPos;
    }
}
