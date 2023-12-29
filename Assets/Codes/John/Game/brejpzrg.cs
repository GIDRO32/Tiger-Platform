using UnityEngine;

namespace Codes.John.Game
{
    public class brejpzrg : asdafpppf
    {
        public void Awake()
        {
            base.Awake();
        }

        public void mjxjuigq()
        {
            UniWebView.SetAllowInlinePlay(true);

            var ewgseg = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (var dohse in ewgseg)
            {
                dohse.Stop();
            }

            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
}