using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodController : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text _numberOfApple, _numberOfMilk, _numberOfBread, _numberOfCheese, _numberOfJuice, _numberOfEgg;

    public static FoodController instance;

    public void Start() {
        instance = this;
        try
            {
            _numberOfApple.text = "x" + Food.CountOfFood("Apple");
            _numberOfMilk.text = "x" + Food.CountOfFood("Milk");
            _numberOfBread.text = "x" + Food.CountOfFood("Bread");
            _numberOfCheese.text = "x" + Food.CountOfFood("Cheese");
            _numberOfEgg.text = "x" + Food.CountOfFood("Egg");
            _numberOfJuice.text = "x" + Food.CountOfFood("Juice");   
            }
        catch (System.Exception)
            {
            return;
            }
    }

    public void BuyFood(string foodName)
    {
        if (Money.GetMoney() >= Food.GetFoodPrice(foodName))
        {
            Food.AddFood(foodName);
            Money.ChangeMoney(-Food.GetFoodPrice(foodName));
            Events.instance.Notify(EventTypes.BUY);
        }
        
    }

    public void EatFood(string foodName)
    {
        Food.EatFood(foodName);

        if (Food.CountOfFood(foodName) >= 0) {
            switch (foodName)
            {
                case "Apple":
                    _numberOfApple.text = $"x{Food.CountOfFood("Apple")}";
                    break;

                case "Milk":
                    _numberOfMilk.text = $"x{Food.CountOfFood("Milk")}";
                    break;

                case "Bread":
                    _numberOfBread.text = $"x{Food.CountOfFood("Bread")}";
                    break;

                case "Cheese":
                    _numberOfCheese.text = $"x{Food.CountOfFood("Cheese")}";
                    break;

                case "Egg":
                    _numberOfEgg.text = $"x{Food.CountOfFood("Egg")}";
                    break;

                case "Juice":
                    _numberOfJuice.text = $"x{Food.CountOfFood("Juice")}";
                    break;
            }
        }
    }

    public void ReturnToTown() {
        SceneManager.LoadScene("NewTown");
    }
}
