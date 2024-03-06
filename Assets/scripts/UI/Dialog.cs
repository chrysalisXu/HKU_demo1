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
    public class Dialog : UIElement
    {
        public Text desc;
        public GameObject button;

        public void SetContent(string text, bool allowNext)
        {
            desc.text = text;
            button.SetActive(allowNext);
        }

        public override void UIStart()
        {
            GameplayManager.Instance.DialogAdvance();
        }
    }
}
