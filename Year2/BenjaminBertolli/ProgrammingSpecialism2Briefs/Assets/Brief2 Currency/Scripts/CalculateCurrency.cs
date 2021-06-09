using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class CalculateCurrency : MonoBehaviour
{
    public Text DisplayText;
    public ValueManager VM_d;
    public ValueManager VM_s;
    public ValueManager VM_p;

    public string ErrorMessage = "Error: Could not find a combo for this value, use pennies only.";

    //Currency values in terms of d
    private float d_Value = 1; //1 Penny
    private float s_Value = 5; //1 shilling is 5 pence
    private float p_Value = 100; //1 pound is 100 pence
    private float LowestCoinCombo = 10000;
    private List<int[]> g_AcceptedCoinCombo = new List<int[]>();

    private float[] All_d;
    private float[] All_s;
    private float[] All_p;

    private string[] All_d_names;
    private string[] All_s_names;
    private string[] All_p_names;

    private float[][] All_Money;
    private string[][] All_Names;

    private float DesiredMoney;

    // Start is called before the first frame update
    void Start()
    {
        All_Money = new float[3][];
        All_Names = new string[3][];

        All_d = new float[]
        {
            d_Value * 0.25f , //farthing
            d_Value * 0.5f , //halfpenny
            d_Value * 1 , //penny
            d_Value * 2 , //twopence
            d_Value * 3 , //threepence
            d_Value * 4 , //fourpence
            d_Value * 6  //sixpence
        };

        All_d_names = new string[] { "Farthing", "Halfpenny", "Penny", "Twopence", "Threepence", "Fourpence", "Sixpence" };


        All_s = new float[]
        {
            s_Value * 1 , //shilling
            s_Value * 2 , //florin
            s_Value * 2 + d_Value * 6, //half crown
            s_Value * 4 , //double florin
            s_Value * 5 , //crown
            s_Value * 5 + d_Value * 6, //quter guinea
            s_Value * 7 , //third guinea
            s_Value * 10 //half soverign
        };

        All_s_names = new string[] { "Shilling", "Florin", "Half Crown", "Double Florin", "Crown", "Quater Guinea", "Third Guinea", "Half Sovereign" };


        All_p = new float[]
        {
            p_Value * 1, //sovereign
            p_Value * 1 + s_Value * 1, //guinea
            p_Value * 2 + s_Value * 2 , //two guineas
            p_Value * 5 , //five pound
            p_Value * 5 + s_Value * 5 //five guineas
        };

        All_p_names = new string[] { "Sovereign", "Guinea", "Two Guineas", "Five Pound", "Five Guineas" };

        All_Money[0] = All_d;
        All_Money[1] = All_s;
        All_Money[2] = All_p;

        All_Names[0] = All_d_names;
        All_Names[1] = All_s_names;
        All_Names[2] = All_p_names;
    }

    private void ResetComboValues()
    {
        LowestCoinCombo = 10000;
        g_AcceptedCoinCombo = new List<int[]>();

        DesiredMoney = 0;
        DesiredMoney += VM_d.CurrentValue;
        DesiredMoney += VM_s.CurrentValue * s_Value;
        DesiredMoney += VM_p.CurrentValue * p_Value;
    }

    private void DisplayCoinCombo()
    {
        if (g_AcceptedCoinCombo.Count > 0)
        {
            string NewText = "Value of " + DesiredMoney + "p made using " + g_AcceptedCoinCombo.Count + " coins: \n";

            for (int i = g_AcceptedCoinCombo.Count - 1; i >= 0; i--)
            {
                string DisplayCombo = "Coin " + (g_AcceptedCoinCombo.Count - i).ToString() + " = " + All_Names[g_AcceptedCoinCombo[i][0]][g_AcceptedCoinCombo[i][1]] + " (" + All_Money[g_AcceptedCoinCombo[i][0]][g_AcceptedCoinCombo[i][1]] + "p)";
                NewText += DisplayCombo + "\n";
                print(DisplayCombo);

            }

            DisplayText.text = NewText;
        }
        else
        {
            DisplayText.text = ErrorMessage;
            DisplayText.text += "\nUse " + DesiredMoney + "p";
        }

    }

    public void ButtonUpdateDesiredMoney()
    {
        ResetComboValues();
        CalculateMoney(DesiredMoney);
        DisplayCoinCombo();
    }

    public float GetDesiredMoney()
    {
        return DesiredMoney;
    }

    private void CalculateCoinCombos(float d_value, float[] ListMeta, int list, int position)
    {
        List<int[]> AcceptedCoins = new List<int[]>();
        AcceptedCoins.Add(new int[] { list, position });

        float new_d_value = d_value - ListMeta[position];
        float temp_value = 1000000;

        for (int value = All_Money.Length - 1; value >= 0; value--)
        {
            for (int coin = All_Money[value].Length -1; coin >= 0; coin--)
            {
                temp_value = new_d_value - All_Money[value][coin];

                if (temp_value >= 0)
                {
                    int[] temp_NewAcceptedCoin = new int[] { value, coin };

                    AcceptedCoins.Add(temp_NewAcceptedCoin);
                    new_d_value -= temp_value;

                    if (temp_value == 0 && AcceptedCoins.Count < LowestCoinCombo)
                    {

                        LowestCoinCombo = AcceptedCoins.Count;
                        g_AcceptedCoinCombo = AcceptedCoins;

                        new_d_value = d_value - ListMeta[position];
                        AcceptedCoins = new List<int[]>();
                        AcceptedCoins.Add(new int[] { list, position });

                    }
                }
            }
        }
    }

    private void Single_UpdateGlobalCoin(int MetaList, int position)
    {
        LowestCoinCombo = 1;

        List<int[]> temp_coinlist = new List<int[]>();
        temp_coinlist.Add(new int[] { MetaList, position });
        g_AcceptedCoinCombo = temp_coinlist;
    }

    private void CalculateMoney(float d_value = 1)
    {
        print("Calculating Coins of Value: " + d_value + "p");
        for (int p = All_p.Length - 1; p >= 0; p--)
        {
            if (CheckIsSingleCoin(d_value, 2, p))
            {
                Single_UpdateGlobalCoin(2, p);

                break;
            }
            else
            {
                CalculateCoinCombos(d_value, All_p, 2, p);
            }

            for (int s = All_s.Length - 1; s >= 0; s--)
            {

                if (CheckIsSingleCoin(d_value, 1, s))
                {
                    Single_UpdateGlobalCoin(1, s);
                }
                else
                {
                    CalculateCoinCombos(d_value, All_s, 1, s);
                }

                for (int d = All_d.Length - 1; d >= 0; d--)
                {

                    if (CheckIsSingleCoin(d_value, 0, d))
                    {
                        Single_UpdateGlobalCoin(0, d);
                    }
                    else
                    {
                        CalculateCoinCombos(d_value, All_d, 0, d);
                    }

                }
            }
        }
    }

    private bool CheckIsSingleCoin(float d_value, int list, int position)
    {
        float tmp_value = d_value - All_Money[list][position];

        if (tmp_value == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
