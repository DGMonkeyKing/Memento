using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class InputName : MonoBehaviour
{
    private char[] _allowedCharacters =
    {
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    };

    [SerializeField]
    private TextMeshProUGUI[] _letters;

    private int[] _input = {0, 0, 0};

    private int _focusLetter = 0;

    public string RetrieveName()
    {
        return "" + _allowedCharacters[_input[0]] + 
        _allowedCharacters[_input[1]] + 
        _allowedCharacters[_input[2]];
    }

    private int _focusValue = 0;

    private int _horizontalInput = 0;
    private int _lastHorizontalInput = 0;
    private bool _horizontalInputPressed = false;
    private int _verticalInput = 0;
    private int _lastVerticalInput = 0;
    private bool _verticalInputPressed = false;

    public void Reset() 
    {
        _input[0] = 0;
        _input[1] = 0;
        _input[2] = 0;

        _focusLetter = 0;
        _focusValue = 0;

        foreach(var l in _letters)
        {
            l.text = _allowedCharacters[0].ToString();
        }
    }   

    void Update()
    {
        _horizontalInput = (int) Input.GetAxisRaw("Horizontal");
        if(_horizontalInput != 0) _horizontalInputPressed = true;
        else _horizontalInputPressed = false;

        if(_horizontalInputPressed && _lastHorizontalInput == _horizontalInput) _horizontalInput = 0;
        else _lastHorizontalInput = _horizontalInput;

        _focusLetter = Mod((_focusLetter + _horizontalInput), _letters.Length);
        _focusValue = _input[_focusLetter];

        _verticalInput = (int) Input.GetAxisRaw("Vertical");
        if(_verticalInput != 0) _verticalInputPressed = true;
        else _verticalInputPressed = false;

        if(_verticalInputPressed && _lastVerticalInput == _verticalInput) _verticalInput = 0;
        else _lastVerticalInput = _verticalInput;

        _focusValue = Mod((_focusValue + _verticalInput), _allowedCharacters.Length);

        _input[_focusLetter] = _focusValue;
        _letters[_focusLetter].text = _allowedCharacters[_input[_focusLetter]].ToString();
    }

    int Mod(int a, int n) => (a % n + n) % n;
}
