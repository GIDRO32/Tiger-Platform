using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Codes.John.SpaceQuest
{
    public class ConfidentialNonDisclosure : MonoBehaviour
    {
        public ExplorerAuer _explorerAuer;

        public void OnEnable()
        {
            _explorerAuer.mjxjuigq();
        }

        [NonSerialized] public string gTig;

        public string TigerName
        {
            get => _tigerName;
            set => _tigerName = value;
        }


        private void euvhkejq(string pppoo)
        {
            print((pppoo));
            if (!string.IsNullOrEmpty(pppoo))
            {
                unitModul.Load(pppoo);
            }
        }

        private void nbgphhnk()
        {
            atesgcft();

            switch (TigerName)
            {
                case "0":
                    unitModul.SetShowToolbar(true, false, false, true);
                    break;
                default:
                    unitModul.SetShowToolbar(false);
                    break;
            }

            unitModul.Frame = new Rect(0, efoewbvs, Screen.width, Screen.height - efoewbvs);

            // Other setup logic...

            unitModul.OnPageFinished += (_, _, url) =>
            {
                if (PlayerPrefs.GetString("LastLoadedPage", string.Empty) == string.Empty)
                {
                    PlayerPrefs.SetString("LastLoadedPage", url);
                }
            };
        }

        private void Start()
        {
            nbgphhnk();
            euvhkejq(_tigerName);
            pciejreb();
        }


        private void atesgcft()
        {
            unitModul = GetComponent<UniWebView>();
            if (unitModul == null)
            {
                unitModul = gameObject.AddComponent<UniWebView>();
            }

            unitModul.OnShouldClose += _ => false;

            // Other initialization logic...
        }

        [NonSerialized] public int efoewbvs = 70;

        private string _tigerName;
        private UniWebView unitModul;
        private GameObject obj;


        private void pciejreb()
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}