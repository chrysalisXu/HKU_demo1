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
    public class PartStatusPanel : UIElement
    {
        public Text name;
        public Text statusText;
        public Button button;
        public Text buttonText;

        public override void UIUpdate()
        {
            if (GameplayManager.Instance.currentPart==null) {
                gameObject.SetActive(false);
                return;
            }
            name.text = GameplayManager.Instance.currentPart.elementID;
            
            string temp = $"Status: {GameplayManager.Instance.currentPart.status}\n Level: {GameplayManager.Instance.currentPart.level}\n";
            if (GameplayManager.Instance.currentUpgradePart == GameplayManager.Instance.currentPart.elementID)
            {
                button.gameObject.SetActive(true);
                if (GameplayManager.Instance.currentPart.status == "good")
                {
                    buttonText.text = "upgrade";
                    temp += "This part can be upgraded";
                }
                else
                {
                    buttonText.text = "fix";
                    temp += "This part should be fixed";
                }
            }
            else
            {
                button.gameObject.SetActive(false);
                temp += $"Only {GameplayManager.Instance.currentUpgradePart} can be operated";
            }
            statusText.text = temp;
        }

    }
}
