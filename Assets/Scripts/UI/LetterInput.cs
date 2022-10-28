using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LetterInput : MonoBehaviour
{
    private char[] _allowedCharacters =
    {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    };

    [Header("Navigation Icons")]
    [SerializeField]
    private GameObject _upArrow;
    [SerializeField]
    private GameObject _downArrow;
    [Header("Letter Text")]
    [SerializeField]
    private TextMeshProUGUI _text;

    private int _value;
    public char Value => _allowedCharacters[_value];

    private int _verticalInput = 0;
    private int _lastVerticalInput = 0;
    private bool _verticalInputPressed = false;

    private bool _hasFocus = false;

    void Update()
    {
        if(_hasFocus)
        {
            Debug.Log("Letter: " + gameObject.name);
            _verticalInput = (int) Input.GetAxisRaw("Vertical");
            if(_verticalInput != 0) _verticalInputPressed = true;
            else _verticalInputPressed = false;

            if(_verticalInputPressed && _lastVerticalInput == _verticalInput) _verticalInput = 0;
            else _lastVerticalInput = _verticalInput;
            
            _value = Mod((_value + _verticalInput), _allowedCharacters.Length);

            ChangeLetterText();
        }
    }

    public void Reset()
    {
        _value = 0;
        ChangeLetterText();
        Unfocus();
    }

    int Mod(int a, int n) => (a % n + n) % n;

    private void ChangeLetterText()
    {
        _text.text = _allowedCharacters[_value].ToString();
    }

    public void Unfocus()
    {
        _upArrow.SetActive(false);
        _downArrow.SetActive(false); 
        _hasFocus = false;  
    }

    public void Focus()
    {
        _upArrow.SetActive(true);
        _downArrow.SetActive(true);   
        _hasFocus = true;  
    }
}
