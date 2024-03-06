// Author: Chrysalis shiyuchongf@gmail.com

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


using ProjectHKU.UI;
using Chrysalis.Core;

namespace ProjectHKU.Gameplay
{
    public class OrganPart : MonoBehaviour
    {
        [SerializeField]
        public string elementID = ""; // any new component should change it!

        public string status = "good";
        public int level = 1;

        void Awake()
        {
            GameplayManager.Instance.ComponentsList.Add(elementID, this);
        }

        public void Select()
        {
            GameplayManager.Instance.currentPart = this;
            UIManager.Instance.ComponentsList["partPanel"].gameObject.SetActive(true);
        }

        public void ClickUpgrade()
        {
            if (status!="good") { // hardcorded shit
                status = "good";
                GameplayManager.Instance.DialogAdvance();
            }
            else level ++;
            if (level >= 2 && elementID == "Aorta")
            {
                GameplayManager.Instance.DialogAdvance();
            }
            GameplayManager.Instance.nutritionIncome += 1;

            if (elementID == "Aorta")
                GameplayManager.Instance.currentUpgradePart = "'Fontan' tunnel";
            else
                GameplayManager.Instance.currentUpgradePart = "Aorta";
        }
    }
}