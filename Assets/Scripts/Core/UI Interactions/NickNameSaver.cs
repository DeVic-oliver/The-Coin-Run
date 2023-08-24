namespace Assets.Scripts.Core.UI_Interactions
{
    using UnityEngine;
    using Assets.Scripts.Core.Services.Prefs;
    using TMPro;

    public class NickNameSaver : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _inputField;


        public void SavePlayerNickNameIntoPrefs()
        {
            PlayerNickPref.SaveNickPref(_inputField.text);
        }
    }
}
