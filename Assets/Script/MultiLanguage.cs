using System.Collections;
using Assets.SimpleLocalization;
using System.Collections.Generic;
using UnityEngine;

public class MultiLanguage : MonoBehaviour
{
    private void Awake()
    {
        LocalizationManager.Read();

        switch (Application.systemLanguage)
        {
            case SystemLanguage.English:
                LocalizationManager.Language = "Indonesian";
                break;
            case SystemLanguage.Indonesian:
                LocalizationManager.Language = "English";
                break;
        }
    }
}
