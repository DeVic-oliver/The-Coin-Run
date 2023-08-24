namespace Assets.Scripts.Core.UI_Interactions
{
    using Assets.Scripts.Core.Services.Prefs;
    using TMPro;
    using UnityEngine;
    
    public class NickNameLoader : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nickNameTMP;


        void Start()
        {
            _nickNameTMP.text = PlayerNickPref.GetPlayerNickPref();
        }
    }
}