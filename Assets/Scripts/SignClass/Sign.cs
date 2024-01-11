using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Sign : MonoBehaviour
{
    public abstract void SetMessageInSign(string title, string qTypeTxt, string qTotalTxt);
}
