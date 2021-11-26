using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Localization;

public class LanguageController : MonoBehaviour
{
    [SerializeField] LeanLocalization _leanLocalization;

    private void Start()
    {
        if (SettingsController.langIsRus)
        {
            _leanLocalization.SetCurrentLanguage("Russian");
        } else
        {
            _leanLocalization.SetCurrentLanguage("English");
        }
    }
}
