using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueManager : MonoBehaviour
{
    public float CurrentValue = 0;

    private CalculateCurrency MoneyMaster;
    private Text text;

    private void Start()
    {
        text = gameObject.GetComponent<Text>();
        MoneyMaster = transform.parent.GetComponent<CalculateCurrency>();
    }

    public void ChangeValue(float Value = 1)
    {
        CurrentValue += Value;
        text.text = CurrentValue.ToString();
        MoneyMaster.ButtonUpdateDesiredMoney();
    }
}
