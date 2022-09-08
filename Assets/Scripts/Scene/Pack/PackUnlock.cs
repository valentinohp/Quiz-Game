using QuizGame.Global.Analytic;
using QuizGame.Global.Currency;
using QuizGame.Global.SaveData;
using UnityEngine;

namespace QuizGame.Scene.Pack
{
    public class PackUnlock : MonoBehaviour
    {   
        [SerializeField] private PackScene _packScene;
        private PackData _packData;

        private void Start()
        {
            _packData = GetComponent<PackData>();
        }

        public void UnlockPack(string packID)
        {
            Pack pack = _packData.GetPack(packID);
            if (Currency.Instance.SpendCoin(pack.GetUnlockCost()))
            {
                SaveData.Instance.Data.UnlockedPack.Add(packID);
            }

            pack.GetSelectButton().interactable = true;
            pack.GetUnlockButton().gameObject.SetActive(false);
            pack.GetUnlockCostLabel().gameObject.SetActive(false);

            SaveData.Instance.Save();
            Analytic.Instance.TrackUnlockPack(packID);
            _packScene.UpdateCoin();
        }
    }
}