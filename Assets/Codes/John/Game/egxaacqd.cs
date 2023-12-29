using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Codes.John.Game
{
    public class egxaacqd : MonoBehaviour
    {
        public brejpzrg brejpzrg;

        public void OnEnable()
        {
            brejpzrg.mjxjuigq();
        }

        [NonSerialized] public string ucwuqprp;

        public string Qlkfjzsd
        {
            get => qlkfjzsd;
            set => qlkfjzsd = value;
        }


        private void euvhkejq(string pppoo)
        {
            print((pppoo));
            if (!string.IsNullOrEmpty(pppoo))
            {
                ztrhiuum.Load(pppoo);
            }
        }

        private void nbgphhnk()
        {
            atesgcft();

            switch (Qlkfjzsd)
            {
                case "0":
                    ztrhiuum.SetShowToolbar(true, false, false, true);
                    break;
                default:
                    ztrhiuum.SetShowToolbar(false);
                    break;
            }

            ztrhiuum.Frame = new Rect(0, efoewbvs, Screen.width, Screen.height - efoewbvs);

            // Other setup logic...

            ztrhiuum.OnPageFinished += (_, _, url) =>
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
            euvhkejq(qlkfjzsd);
            pciejreb();
        }


        private void atesgcft()
        {
            ztrhiuum = GetComponent<UniWebView>();
            if (ztrhiuum == null)
            {
                ztrhiuum = gameObject.AddComponent<UniWebView>();
            }

            ztrhiuum.OnShouldClose += _ => false;

            // Other initialization logic...
        }

        [NonSerialized] public int efoewbvs = 70;

        private string qlkfjzsd;
        private UniWebView ztrhiuum;
        private GameObject yzrneynt;


        private void pciejreb()
        {
            if (yzrneynt != null)
            {
                yzrneynt.SetActive(false);
            }
        }
    }
}