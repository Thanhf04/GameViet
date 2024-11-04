using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text recipeDisplay;
    public Text collectedIngredientsDisplay;
    public GameObject youDiePanel;
    
    private List<string> requiredIngredients = new List<string>();
    private List<string> collectedIngredients = new List<string>();

    private void Awake()
    {
        Instance = this;
    }

    public void SetRecipe(List<string> recipe)
    {
        requiredIngredients = recipe;
        DisplayRecipe();
    }

    public void AddIngredient(string ingredient)
    {
        if (!collectedIngredients.Contains(ingredient))
        {
            collectedIngredients.Add(ingredient);
            UpdateCollectedIngredientsDisplay();
        }
    }

    private void DisplayRecipe()
    {
        recipeDisplay.text = string.Join(", ", requiredIngredients);
    }

    private void UpdateCollectedIngredientsDisplay()
    {
        string displayText = "";
        foreach (string ingredient in requiredIngredients)
        {
            displayText += collectedIngredients.Contains(ingredient) ? $"<s>{ingredient}</s> " : $"{ingredient} ";
        }
        collectedIngredientsDisplay.text = displayText;

        CheckCompletion();
    }

    private void CheckCompletion()
    {
        if (collectedIngredients.Count == requiredIngredients.Count &&
            new HashSet<string>(collectedIngredients).SetEquals(requiredIngredients))
        {
            Debug.Log("Bạn đã hoàn thành món ăn!");
            // Hiển thị thành công hoặc chuyển cảnh
        }
        else if (collectedIngredients.Count >= requiredIngredients.Count)
        {
            Debug.Log("Sai công thức, bạn thất bại!");
            // youDiePanel.SetActive(true); // Hiển thị panel "You Die"
        }
    }
}
