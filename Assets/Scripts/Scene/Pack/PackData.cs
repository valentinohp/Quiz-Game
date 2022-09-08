using QuizGame.Global.Database;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using QuizGame.Global.SaveData;

namespace QuizGame.Scene.Pack
{
    public class PackData : MonoBehaviour
    {
        [SerializeField] private GameObject _packPrefab;
        [SerializeField] private VerticalLayoutGroup _layoutGroup;
        private Pack[] _packs;
        private PackUnlock _packUnlock;

        private void Start()
        {
            LoadPackList();
            InitPackList(_packs);
            _packUnlock = GetComponent<PackUnlock>();
        }

        private void LoadPackList()
        {
            _packs = new Pack[Database.Instance.GetPackList().Length];
            

            for (int i = 0; i < _packs.Length; i++)
            {
                GameObject packObject = Instantiate(_packPrefab);
                packObject.transform.SetParent(_layoutGroup.transform, false);
                Pack pack = packObject.GetComponent<Pack>();
                Button selectButton = pack.GetSelectButton();
                selectButton.onClick.RemoveAllListeners();
                selectButton.onClick.AddListener(delegate { SelectPack(pack.GetPackID()); });
                Button unlockButton = pack.GetUnlockButton();
                unlockButton.onClick.RemoveAllListeners();
                unlockButton.onClick.AddListener(delegate { UnlockPack(pack.GetPackID()); });
                _packs[i] = pack;
            }
        }

        public void SelectPack(string packID)
        {
            PlayerPrefs.SetString("SelectedPack", packID);
            SceneManager.LoadScene("Level");
        }

        public void UnlockPack(string packID)
        {
            _packUnlock.UnlockPack(packID);
        }

        public Pack[] GetPackList()
        {
            return _packs;
        }

        public Pack GetPack(string packID)
        {
            for (int i = 0; i < _packs.Length; i++)
            {
                if (_packs[i].GetPackID() == packID)
                {
                    return _packs[i];
                }
            }
            return _packs[0];
        }

        public void InitPackList(Pack[] packs)
        {
            string[] packList = Database.Instance.GetPackList();
            for (int i = 0; i < packs.Length; i++)
            {
                packs[i].SetIDName(packList[i]);
                Button button = packs[i].GetSelectButton();
                if (!SaveData.Instance.Data.UnlockedPack.Contains(packs[i].GetPackID()))
                {
                    button.interactable = false;
                    packs[i].GetUnlockButton().gameObject.SetActive(true);
                    packs[i].GetUnlockCostLabel().gameObject.SetActive(true);
                }

                if (SaveData.Instance.Data.CompletedPack.Contains(packs[i].GetPackID()))
                {
                    packs[i].GetCompleteImage().gameObject.SetActive(true);
                }
            }
        }
    }
}