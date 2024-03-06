// Author: Chrysalis shiyuchongf@gmail.com

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Chrysalis.Core;
using ProjectHKU.Gameplay;

namespace ProjectHKU.UI
{
    public class StatusPanel : UIElement
    {
        public Text desc;

        public override void UIUpdate()
        {
            desc.text = $"Nutrition\n\nStock:            {GameplayManager.Instance.nutritionStock}\nHourly Income: {GameplayManager.Instance.nutritionIncome}";
        }
    }
}
