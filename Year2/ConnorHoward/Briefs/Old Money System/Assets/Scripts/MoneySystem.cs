using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoneySystem : MonoBehaviour
{

    public Text totalPoundsOne;
    public Text totalPoundsTwo;
    public Text totalShillingsOne;
    public Text totalShillingsTwo;
    public Text totalPenniesOne;
    public Text totalPenniesTwo;

    private float totalValuePoundsOne;
    private float totalValuePoundsTwo;
    private float totalValueShillingsOne;
    private float totalValueShillingsTwo;
    private float totalValuePenniesOne;
    private float totalValuePenniesTwo;

    private float currentAmountOfShillingsOne;
    private float currentAmountOfShillingsTwo;
    private float currentAmountOfPenniesOne;
    private float currentAmountOfPenniesTwo;

    // Start is called before the first frame update
    void Start()
    {
        totalValuePoundsOne = 0f;
        totalValuePoundsTwo = 0f;
        totalValueShillingsOne = 0f;
        totalValueShillingsTwo = 0f;
        totalValuePenniesOne = 0f;
        totalValuePenniesTwo = 0f;

        currentAmountOfShillingsOne = 0f;
        currentAmountOfShillingsTwo = 0f;
        currentAmountOfPenniesOne = 0f;
        currentAmountOfPenniesTwo = 0f;


        totalPoundsOne.text = "£ " + totalValuePoundsOne;
        totalPoundsTwo.text = "£ " + totalValuePoundsTwo;
        totalShillingsOne.text = "S  " + totalValueShillingsOne;
        totalShillingsTwo.text = "S " + totalValueShillingsTwo;
        totalPenniesOne.text = "D " + totalValuePenniesOne;
        totalPenniesTwo.text = "D " + totalValuePenniesTwo;
    }

    // Update is called once per frame
    void Update()
    {

        //One penny was divided into two halfpennies, or four farthings.
        totalPoundsOne.text = "£ " + totalValuePoundsOne;
        totalPoundsTwo.text = "£ " + totalValuePoundsTwo;
        totalShillingsOne.text = "S  " + totalValueShillingsOne;
        totalShillingsTwo.text = "S " + totalValueShillingsTwo;
        totalPenniesOne.text = "D " + totalValuePenniesOne;
        totalPenniesTwo.text = "D " + totalValuePenniesTwo;


        //SHILLINGS
        //If the amount of shillings reaches 12 reset the shillings and increase the amount of pounds by one
        if (totalValueShillingsOne == 12f)
        {
            totalValueShillingsOne = 0f;
            totalValuePoundsOne++;
        }
        //If the amount of shillings reaches 12 reset the shillings and increase the amount of pounds by one
        if (totalValueShillingsTwo == 12f)
        {
            totalValueShillingsTwo = 0f;
            totalValuePoundsTwo++;
        }
        //If the amount of shillings reaches below 0, check if you have any pounds left if so take a pound away and set the number of shillings to 11, if no pounds left say so in console
        if (totalValueShillingsOne < 0f)
        {
            if (totalValuePoundsOne > 0f)
            {
                totalValuePoundsOne--;
                totalValueShillingsOne = 11f;
            }
            else
            {
                totalValueShillingsOne = 0f;
                Debug.Log("You have no more shillings to take away");
            }
            
        }
        //If the amount of shillings reaches below 0, check if you have any pounds left if so take a pound away and set the number of shillings to 11, if no pounds left say so in console
        if (totalValueShillingsTwo < 0f)
        {
            if (totalValuePoundsTwo > 0f)
            {
                totalValuePoundsTwo--;
                totalValueShillingsTwo = 11f;
            }
            else
            {
                totalValueShillingsTwo = 0f;
                Debug.Log("You have no more shillings to take away");
            }

        }


        //PENNIES, HALF PENNIES AND FARTHINGS
        //If the amount of pennies reaches 20 reset the pennies and increase the amount of shillings by one
        if (totalValuePenniesOne == 20f)
        {
            totalValuePenniesOne = 0f;
            totalValueShillingsOne++;
        }
        //If the value of pennies exceeds 20
        else if (totalValuePenniesOne > 20f)
        {
            //Over by a half penny?
            if (totalValuePenniesOne == 20.5f)
            {
                totalValuePenniesOne = 0.5f;
                totalValueShillingsOne++;
            }
            //Over by a 0.25 farthing?
            else if (totalValuePenniesOne == 20.25f)
            {
                totalValuePenniesOne = 0.25f;
                totalValueShillingsOne++;
            }
            //Over by a 0.75 farthing?
            else if (totalValuePenniesOne == 20.75f)
            {
                totalValuePenniesOne = 0.75f;
                totalValueShillingsOne++;
            }
            
        }
        //If the amount of pennies reaches 20 reset the pennies and increase the amount of shillings by one
        if (totalValuePenniesTwo == 20f)
        {
            totalValuePenniesTwo = 0f;
            totalValueShillingsTwo++;
        }
        //If the value of pennies exceeds 20
        else if (totalValuePenniesTwo > 20f)
        {
            //Over by a half penny?
            if (totalValuePenniesTwo == 20.5f)
            {
                totalValuePenniesTwo = 0.5f;
                totalValueShillingsTwo++;
            }
            //Over by a 0.25 farthing?
            else if (totalValuePenniesTwo == 20.25f)
            {
                totalValuePenniesTwo = 0.25f;
                totalValueShillingsTwo++;
            }
            //Over by a 0.75 farthing?
            else if (totalValuePenniesTwo == 20.75f)
            {
                totalValuePenniesTwo = 0.75f;
                totalValueShillingsTwo++;
            }

        }
        //If the amount of penniess reaches below 0
        if (totalValuePenniesOne < 0f)
        {
            //If you have shillings
            if (totalValueShillingsOne > 0f)
            {
                //taken away a half penny
                if (totalValuePenniesOne == -0.5f)
                {
                    totalValuePenniesOne = 19.5f;
                    totalValueShillingsOne--;
                }
                //taken away a farthing 
                else if (totalValuePenniesOne == -0.25f)
                {
                    totalValuePenniesOne = 19.75f;
                    totalValueShillingsOne--;
                }
                //taken away a penny
                else if (totalValuePenniesOne == -1f)
                {
                    totalValuePenniesOne = 19f;
                    totalValueShillingsOne--;
                }
                //taken away a penny at 0.25f
                else if (totalValuePenniesOne == -0.75f)
                {
                    totalValuePenniesOne = 19.25f;
                    totalValueShillingsOne--;
                }
            }
            //no shillings left
            else
            {
                totalValuePenniesOne = 0f;
                Debug.Log("You have no more pennies to take away");
            }
        }
        //If the amount of penniess reaches below 0
        if (totalValuePenniesTwo < 0f)
        {
            //If you have shillings
            if (totalValueShillingsTwo > 0f)
            {
                //taken away a half penny
                if (totalValuePenniesTwo == -0.5f)
                {
                    totalValuePenniesTwo = 19.5f;
                    totalValueShillingsTwo--;
                }
                //taken away a farthing
                else if (totalValuePenniesTwo == -0.25f)
                {
                    totalValuePenniesTwo = 19.75f;
                    totalValueShillingsTwo--;
                }
                //taken away a penny
                else if (totalValuePenniesTwo == -1f)
                {
                    totalValuePenniesTwo = 19f;
                    totalValueShillingsTwo--;
                }
                //taken away a penny at 0.25f
                else if (totalValuePenniesTwo == -0.75f)
                {
                    totalValuePenniesTwo = 19.25f;
                    totalValueShillingsTwo--;
                }
            }
            //no shillings left
            else
            {
                totalValuePenniesTwo = 0f;
                Debug.Log("You have no more pennies to take away");
            }
        }
    }

    //ADDITION FUNCTIONS
    //Add a farthing to amounts
    public void AddFarthingToAmountOne()
    {
        totalValuePenniesOne += 0.25f;
    }
    public void AddFarthingToAmountTwo()
    {
        totalValuePenniesTwo += 0.25f;
    }

    //Add a Half Penny to amounts
    public void AddHalfPennyToAmountOne()
    {
        totalValuePenniesOne += 0.5f;
    }
    public void AddHalfPennyToAmountTwo()
    {
        totalValuePenniesTwo += 0.5f;
    }

    //Add a Penny to amounts
    public void AddPennyToAmountOne()
    {
        totalValuePenniesOne++;
    }
    public void AddPennyToAmountTwo()
    {
        totalValuePenniesTwo++;
    }

    //Check shilling amounts
    public void AddShillingToAmountOne()
    {
        totalValueShillingsOne++;
    }
    public void AddShillingToAmountTwo()
    {
        totalValueShillingsTwo++;
    }

    //Add a Pound to amounts
    public void AddPoundToAmountOne()
    {
        totalValuePoundsOne++;
    }
    public void AddPoundToAmountTwo()
    {
        totalValuePoundsTwo++;
    }



    //SUBTRACT FUNCTIONS
    //Minus a Farthing to amounts
    public void MinusFarthingToAmountOne()
    {
        totalValuePenniesOne -= 0.25f;
    }
    public void MinusFarthingToAmountTwo()
    {
        totalValuePenniesTwo -= 0.25f;
    }

    //Minus a Half Penny to amounts
    public void MinusHalfPennyToAmountOne()
    {
        totalValuePenniesOne -= 0.5f;
    }
    public void MinusHalfPennyToAmountTwo()
    {
        totalValuePenniesTwo -= 0.5f;
    }

    //Minus a Penny to amounts

    public void MinusPennyToAmountOne()
    {
        totalValuePenniesOne--;
    }
    public void MinusPennyToAmountTwo()
    {
        totalValuePenniesTwo--;
    }

    //Minus a Shilling to amounts
    public void MinusShillingToAmountOne()
    {
        totalValueShillingsOne--;      
    }
    public void MinusShillingToAmountTwo()
    {
        totalValueShillingsTwo--;
    }

    //Minus a Pound to amounts
    public void MinusPoundToAmountOne()
    {
        totalValuePoundsOne--;
    }
    public void MinusPoundToAmountTwo()
    {
        totalValuePoundsTwo--;
    }

    //Reset all values
    public void ResetOne()
    {
        totalValuePoundsOne = 0f;
        totalValueShillingsOne = 0f;
        totalValuePenniesOne = 0f;
    }
    //Reset all values
    public void ResetTwo()
    {
        totalValuePoundsTwo = 0f;
        totalValueShillingsTwo = 0f;
        totalValuePenniesTwo = 0f;
    }

    public void Check()
    {
        if (totalValuePoundsOne == totalValuePoundsTwo)
        {
            if (totalValueShillingsOne == totalValueShillingsTwo)
            {
                if (totalValuePenniesOne == totalValuePenniesTwo)
                {
                    print("Both amounts are the same");
                }
                else if (totalValuePenniesOne > totalValuePenniesTwo)
                {
                    print("Amount 1 has more");
                }
                else if (totalValuePenniesOne < totalValuePenniesTwo)
                {
                    print("Amount 2 has more");
                }
            }
            else if (totalValueShillingsOne > totalValueShillingsTwo)
            {
                print("Amount 1 has more");
            }
            else if (totalValueShillingsOne < totalValueShillingsTwo)
            {
                print("Amount 2 has more");
            }
            
        }
        else if (totalValuePoundsOne > totalValuePoundsTwo)
        {
            print("Amount 1 has more");
        }
        else if (totalValuePoundsOne < totalValuePoundsTwo)
        {
            print("Amount 2 has more");
        }
    }
}
