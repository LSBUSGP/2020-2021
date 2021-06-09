using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCompare : MonoBehaviour
{
    public CalculateCurrency Combo1;
    public CalculateCurrency Combo2;

    private Text SelfText;

    private void Start()
    {
        SelfText = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        GetBiggestCombo();
    }

    private void GetBiggestCombo()
    {
        if(Combo1.GetDesiredMoney() > Combo2.GetDesiredMoney())
        {
            SelfText.text = "Combo 1 has the biggest value of " + Combo1.GetDesiredMoney().ToString() + "p compared to Combo 2 of " + Combo2.GetDesiredMoney().ToString() + "p";
        }
        else if (Combo1.GetDesiredMoney() < Combo2.GetDesiredMoney())
        {
            SelfText.text = "Combo 2 has the biggest value of " + Combo2.GetDesiredMoney().ToString() + "p compared to Combo 1 of " + Combo1.GetDesiredMoney().ToString() + "p";
        }
        else
        {
            print("Combo 1 and 2 have the same value of " + Combo1.GetDesiredMoney().ToString() + "p");
        }
    }

}
