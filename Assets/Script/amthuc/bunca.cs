using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunca : MonoBehaviour
{
    public List<string> ingredientsForRecipe;

    public void OnEnable()
    {
        GameManager.Instance.SetRecipe(ingredientsForRecipe);
    }
}
