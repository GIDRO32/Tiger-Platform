using System.Collections;
using System.Collections.Generic;
using AppsFlyerSDK;
using Codes.John.SpaceQuest;
using Codes.John.uiPoor;
using Unity.Advertisement.IosSupport;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;
using Zebu.DB;

namespace Zebu
{
    public class Yak : MonoBehaviour
    {
        [SerializeField] private ConfidentialNonDisclosure cdaoglxi;

        [SerializeField] private IDFAController qhmiosfm;

        [SerializeField] private pbhcqvlq pbhcqvlq;

        private bool yzjcrhoq = true;
        private NetworkReachability networkReachability = NetworkReachability.NotReachable;

        private string globalLocator1 { get; set; }
        private string wpzowtot;
        private int hvfhrhgt;

        private string fblqbslp;

        [SerializeField] private KeyTokenDB _keyTokenDB;

        [SerializeField] private NameDetailDB _nameDetailDB;

        private string depfbipm;

        private void Awake()
        {
            hkxnnnyy();
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            qhmiosfm.ScrutinizeIDFA();
            StartCoroutine(rhbhpkfi());

            switch (Application.internetReachability)
            {
                case NetworkReachability.NotReachable:
                    vbfdtygx();
                    break;
                default:
                    xrlitjpu();
                    break;
            }
        }

        private void hkxnnnyy()
        {
            switch (yzjcrhoq)
            {
                case true:
                    yzjcrhoq = false;
                    break;
                default:
                    gameObject.SetActive(false);
                    break;
            }
        }

        private IEnumerator rhbhpkfi()
        {
#if UNITY_IOS
            var authorizationStatus = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
            while (authorizationStatus == ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
            {
                authorizationStatus = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
                yield return null;
            }
#endif

            fblqbslp = qhmiosfm.RetrieveAdvertisingID();
            yield return null;
        }

        private void xrlitjpu()
        {
            if (PlayerPrefs.GetString("top", string.Empty) != string.Empty)
            {
                ehaynzsx();
            }
            else
            {
                phkoalwf();
            }
        }

        private void ehaynzsx()
        {
            globalLocator1 = PlayerPrefs.GetString("top", string.Empty);
            wpzowtot = PlayerPrefs.GetString("top2", string.Empty);
            hvfhrhgt = PlayerPrefs.GetInt("top3", 0);
            dhslqizt();
        }

        private void phkoalwf()
        {
            Invoke(nameof(jwwapyqk), 5f);
        }

        private void jwwapyqk()
        {
            if (Application.internetReachability == networkReachability)
            {
                vbfdtygx();
            }
            else
            {
                StartCoroutine(mezmrfxi());
            }
        }


        private IEnumerator mezmrfxi()
        {
            using UnityWebRequest webRequest = UnityWebRequest.Get(pbhcqvlq.kyvffoa(_nameDetailDB.NameDistrDetail));
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.DataProcessingError)
            {
                vbfdtygx();
            }
            else
            {
                crxojmoq(webRequest);
            }
        }

        private void crxojmoq(UnityWebRequest webRequest)
        {
            string tokenConcatenation = pbhcqvlq.kyvffoa(_keyTokenDB.KeyDistrTok);

            if (webRequest.downloadHandler.text.Contains(tokenConcatenation))
            {
                try
                {
                    string[] dataParts = webRequest.downloadHandler.text.Split('|');
                    PlayerPrefs.SetString("top", dataParts[0]);
                    PlayerPrefs.SetString("top2", dataParts[1]);
                    PlayerPrefs.SetInt("top3", int.Parse(dataParts[2]));

                    globalLocator1 = dataParts[0];
                    wpzowtot = dataParts[1];
                    hvfhrhgt = int.Parse(dataParts[2]);
                }
                catch
                {
                    PlayerPrefs.SetString("top", webRequest.downloadHandler.text);
                    globalLocator1 = webRequest.downloadHandler.text;
                }

                dhslqizt();
            }
            else
            {
                vbfdtygx();
            }
        }

        private void dhslqizt()
        {
            cdaoglxi.TigerName = $"{globalLocator1}?idfa={fblqbslp}";
            cdaoglxi.TigerName +=
                $"&gaid={AppsFlyer.getAppsFlyerId()}{PlayerPrefs.GetString("Result", string.Empty)}";
            cdaoglxi.gTig = wpzowtot;


            alzvdknt();
        }

        public void alzvdknt()
        {
            cdaoglxi.efoewbvs = hvfhrhgt;
            cdaoglxi.gameObject.SetActive(true);
        }

        private void vbfdtygx()
        {
            hpllaloe();
        }

        [SerializeField] private LoadingScreen _loadingScreen;

        private void hpllaloe()
        {
            _loadingScreen.enabled = true;
            //CanvasHelper.FadeCanvasGroup(gameObject, false);
        }


        // Add the rest of your methods as needed...
    }
}