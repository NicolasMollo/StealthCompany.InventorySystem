using UnityEngine;
using Sirenix.OdinInspector;


namespace NewLab.Unity.SDK.Core.Systems.Audio
{

    public class AudioClipContainer : MonoBehaviour
    {

        [TitleGroup("CLIP", null, TitleAlignments.Left)]

        [SerializeField]
        [Tooltip("Audio clip container's audio clip")]
        private AudioClip _clip = null;
        public AudioClip Clip
        {
            get => _clip;
        }

        #region Identifiers

        [TitleGroup("IDENTIFIERS", null, TitleAlignments.Left)]

        [SerializeField]
        [Tooltip("Audio clip name")]
        private string _clipName = string.Empty;
        public string ClipName
        {
            get => _clipName;
            set => _clipName = value;
        }

        [SerializeField]
        [Tooltip("Audio source name")]
        private int _clipID = -1;
        public int ClipID
        {
            get => _clipID;
            set => _clipID = value;
        }

        #endregion

    }

}