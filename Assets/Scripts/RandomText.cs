using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomText : MonoBehaviour
{
    [SerializeField] private string[] _Texts;
    [SerializeField] private Text textField;
    private int _randomNum;
    private void Start()
    {
        _randomNum = Random.Range(0, _Texts.Length);
        textField.text = _Texts[_randomNum];
    }
}
