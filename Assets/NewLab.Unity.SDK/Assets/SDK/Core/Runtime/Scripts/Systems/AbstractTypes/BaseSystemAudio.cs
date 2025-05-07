using UnityEngine;


namespace NewLab.Unity.SDK.Core.Systems.Audio
{

    public abstract class BaseSystemAudio : BaseSystem
    {

        #region API

        #region _Sfx

        /// <summary>
        /// Method that plays an sfx clip.
        /// The method accepts as an argument a parameter of type "AudioClip" which represents the sfx to play.
        /// </summary>
        /// <param name="sfxToPlay"></param>
        public virtual void PlaySfx(AudioClip sfxToPlay) { }

        /// <summary>
        /// Method that plays an sfx clip.
        /// The method accepts as an argument a parameter of type "int" which represents the sfx to play.
        /// </summary>
        /// <param name="sfxToPlay"></param>
        public virtual void PlaySfx(int sfxToPlay) { }

        /// <summary>
        /// Method that plays an sfx clip.
        /// The method accepts as an argument a parameter of type "string" which represents the sfx to play.
        /// </summary>
        /// <param name="sfxToPlay"></param>
        public virtual void PlaySfx(string sfxToPlay) { }

        #endregion<
        #region _Ambience

        /// <summary>
        /// Method that plays an ambience clip.
        /// </summary>
        public virtual void PlayAmbience() { }

        /// <summary>
        ///  Method that pause an ambience clip.
        /// </summary>
        public virtual void PauseAmbience() { }

        /// <summary>
        /// Method that stops an ambience clip.
        /// </summary>
        public virtual void StopAmbience() { }



        /// <summary>
        /// Method that plays an ambience clip.
        /// The method accepts as an argument a parameter of type "AudioClip" which represents the ambience to play.
        /// </summary>
        /// <param name="ambienceToPlay"></param>
        public virtual void PlayAmbience(AudioClip ambienceToPlay) { }

        /// <summary>
        /// Method that pause an ambience clip.
        /// The method accepts as an argument a parameter of type "AudioClip" which represents the ambience to pause.
        /// The parameter is set to null by default and so you can also use the method without passing any arguments.
        /// </summary>
        /// <param name="ambienceToPlay"></param>
        public virtual void PauseAmbience(AudioClip ambienceToPause = null) { }

        /// <summary>
        /// Method that stops an ambience clip.
        /// The method accepts as an argument a parameter of type "AudioClip" which represents the ambience to stop.
        /// The parameter is set to null by default and so you can also use the method without passing any arguments.
        /// </summary>
        /// <param name="ambienceToStop"></param>
        public virtual void StopAmbience(AudioClip ambienceToStop = null) { }



        /// <summary>
        /// Method that plays an ambience clip.
        /// The method accepts as an argument a parameter of type "int" which represents the ambience to play.
        /// </summary>
        /// <param name="ambienceToPlay"></param>
        public virtual void PlayAmbience(int ambienceToPlay) { }

        /// <summary>
        /// Method that pause an ambience clip.
        /// The method accepts as an argument a parameter of type "int" which represents the ambience to pause.
        /// </summary>
        /// <param name="ambienceToPlay"></param>
        public virtual void PauseAmbience(int ambienceToPause) { }

        /// <summary>
        /// Method that stops an ambience clip.
        /// The method accepts as an argument a parameter of type "int" which represents the ambience to stop.
        /// </summary>
        /// <param name="ambienceToStop"></param>
        public virtual void StopAmbience(int ambienceToStop) { }



        /// <summary>
        /// Method that plays an ambience clip.
        /// The method accepts as an argument a parameter of type "string" which represents the ambience to play.
        /// </summary>
        /// <param name="ambienceToPlay"></param>
        public virtual void PlayAmbience(string ambienceToPlay) { }

        /// <summary>
        /// Method that pause an ambience clip.
        /// The method accepts as an argument a parameter of type "string" which represents the ambience to pause.
        /// </summary>
        /// <param name="ambienceToPlay"></param>
        public virtual void PauseAmbience(string ambienceToPause) { }

        /// <summary>
        /// Method that stops an ambience clip.
        /// The method accepts as an argument a parameter of type "string" which represents the ambience to stop.
        /// </summary>
        /// <param name="ambienceToStop"></param>
        public virtual void StopAmbience(string ambienceToStop) { }

        #endregion
        #region _Volumes

        /// <summary>
        /// Method to set the volume of all the sfx of the application.
        /// The method accepts as an argument a parameter of type "float" that represent the volume to set.
        /// </summary>
        /// <param name="volume"></param>
        public virtual void SetAllSfxVolumes(float volume) { }

        /// <summary>
        /// Method to set the volume of the ambience of the application.
        /// The method accepts as an argument a parameter of type "float" that represent the volume to set.
        /// </summary>
        /// <param name="volume"></param>
        public virtual void SetAmbienceVolume(float volume) { }

        #endregion

        #endregion

    }

}