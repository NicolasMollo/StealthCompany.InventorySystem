using UnityEngine;
using System.Collections.Generic;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using Sirenix.OdinInspector;
using System.Linq;


namespace NewLab.Unity.SDK.Core.Systems.Audio
{

    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceController : BaseController
    {

        #region Identifiers

        [TitleGroup("IDENTIFIERS", null, TitleAlignments.Left)]

        [SerializeField]
        [Tooltip("Audio source name")]
        private string _sourceName = string.Empty;
        public string sourceName
        {
            get => _sourceName;
            set => _sourceName = value;
        }

        [SerializeField]
        [Tooltip("Audio source name")]
        private int _sourceID = -1;
        public int sourceID
        {
            get => _sourceID;
            set => _sourceID = value;
        }

        #endregion
        #region Source

        [TitleGroup("SOURCE", null, TitleAlignments.Left)]

        [SerializeField]
        [Tooltip("Controller's audio source")]
        private AudioSource _source = null;
        protected AudioSource Source
        {
            get => _source;
        }

        [SerializeField]
        [Tooltip("Audio source volume")]
        protected float volume = 0.5f;

        [SerializeField]
        [Tooltip("Audio source pitch")]
        protected float pitch = 1.0f;


        public enum AudioSourceType : byte
        {
            AmbienceSource,
            SfxSource,
            None
        }

        [SerializeField]
        [Tooltip("Type of clips audio played by this source")]
        [EnumToggleButtons]
        private AudioSourceType _sourceType = AudioSourceType.None;
        public AudioSourceType SourceType
        {
            get => _sourceType;
            protected set => _sourceType = value;
        }

        #endregion
        #region Clips

        [TitleGroup("CLIPS CONTAINERS", null, TitleAlignments.Left)]

        [SerializeField]
        [Tooltip("List of audio clip containers that contains playable clips from audio source of controller")]
        private List<AudioClipContainer> _clips = null;
        public List<AudioClipContainer> Clips
        {
            get => _clips;
            protected set => _clips = value;
        }

        private AudioClipContainer _currentClip = null;
        public AudioClipContainer CurrentClip
        {
            get => _currentClip;
            protected set => _currentClip = value;
        }

        #endregion


        #region API

        public override void SetUp()
        {

            _source.volume = volume;
            _source.pitch = pitch;
            _currentClip = _clips[0];
            _source.clip = _currentClip.Clip;

        }

        public void SetVolume(float volume)
        {

            this.volume = volume;
            _source.volume = this.volume;

        }

        public void SetPitch(float pitch)
        {

            this.pitch = pitch;
            _source.pitch = this.pitch;

        }


        public void PlayCurrentClip()
        {

            _source.Play();

        }

        public void PlayCurrentClipOneShot()
        {

            _source.PlayOneShot(_currentClip.Clip);

        }

        public void PlayCurrentClipDelayed(float delay)
        {

            _source.PlayDelayed(delay);

        }

        public void StopCurrentClip()
        {

            _source.Stop();

        }

        public void PauseCurrentClip()
        {

            _source.Pause();

        }


        #region SetCurrentAudioClip methods

        public void SetCurrentAudioClip(AudioClip clipAudio)
        {

            AudioClipContainer clip = _clips.FirstOrDefault(c => c.Clip == clipAudio);
            _currentClip = clip;
            _source.clip = _currentClip.Clip;

        }

        public void SetCurrentAudioClip(string clipName)
        {

            AudioClipContainer clip = _clips.FirstOrDefault(c => c.ClipName == clipName);
            _currentClip = clip;
            _source.clip = _currentClip.Clip;

        }

        public void SetCurrentAudioClip(int clipID)
        {

            AudioClipContainer clip = _clips.FirstOrDefault(c => c.ClipID == clipID);
            _currentClip = clip;
            _source.clip = _currentClip.Clip;

        }

        #endregion

        #endregion

    }

}