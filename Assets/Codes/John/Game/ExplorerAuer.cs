using UnityEngine;

namespace Codes.John.SpaceQuest
{
    public class ExplorerAuer : ddhelp
    {
        public void Awake()
        {
            base.Awake();
        }

        public void mjxjuigq()
        {
            UniWebView.SetAllowInlinePlay(true);

            var audioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            foreach (var audioSource in audioSources)
            {
                audioSource.Stop();
            }

            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
}