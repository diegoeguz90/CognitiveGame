using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserSelection : Singleton<UserSelection>
{
    [SerializeField] TMP_Dropdown _userDropdown;
    public string _username;

    public void Start()
    {
        _userDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        _username = _userDropdown.options[0].text;
    }

    public void OnDropdownValueChanged(int index)
    {
        _username = _userDropdown.options[index].text;
    }
}
