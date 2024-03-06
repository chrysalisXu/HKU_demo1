// Author: Chrysalis shiyuchongf@gmail.com

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using ProjectHKU.UI;
using Chrysalis.Core;

namespace ProjectHKU.Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        private static GameplayManager _instance = null;
        public static GameplayManager Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<GameplayManager>();
                if (_instance == null) throw new Exception("gameplay not found");
                return _instance;
            }
        }

        // game mechanics
        [NonSerialized]
        public float nutritionIncome = 0;
        [NonSerialized]
        public float nutritionStock = 100;

        void Update(){
            nutritionStock += nutritionIncome / 100;
        }

        public GameObject lungObj;

        [NonSerialized]
        public Dictionary<string, OrganPart> ComponentsList = new Dictionary<string, OrganPart>();
        public OrganPart currentPart = null;
        public string currentUpgradePart = "Aorta";

        public void upgradePart()
        {
            currentPart.ClickUpgrade();
        }

        // dialog control
        // ugly & naive, only for demo

        private int dialogIndex = -1;
        [NonSerialized]
        public string[] dialogs = new string[] {
            "This is a demo of body management idea. This is a patient after Bilateral Fontan Procedure. You are now controlling the body.",
            "Oh, no, the Aorta is broken! blood cannot reach other body parts! Now please find the Aorta and try to fix it, fixation will cost nutrition",
            "Problem solved, no more emergent issue.",
            "Now You need to stock more nutrition, To do so, you need to first unlock your respiratory system, scan QR code under any exhibited lung to continue. (In demo it is skipped).",
            "Oh, the lung you scanned is from Hans, his body is donated in 19xx, and .... (museum history story).",
            "Now freely upgrade your heart 2 times to further imporve your nutrition income. Remember, each organ only has one part available for upgrade in the same time, you need to find it. And each upgrade will change the target randomly",
            "More systems will be available, and there will be more emergent events happening in game.\n (End of demo)"
        };
        public void DialogAdvance()
        {
            dialogIndex ++;
            if (dialogIndex == 4)
                lungObj.SetActive(true);
            bool canNext = true;
            if (dialogIndex == 1 || dialogIndex == 5 || dialogIndex == 6) canNext = false;
            ((Dialog)UIManager.Instance.ComponentsList["dialog"]).SetContent(dialogs[dialogIndex], canNext);
        }
    }
}
