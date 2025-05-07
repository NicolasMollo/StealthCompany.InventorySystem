using UnityEngine;
using NewLab.Unity.SDK.Core.Modules;


namespace NewLab.Unity.SDK.Core.Systems.Controllers
{

    /// <summary>
    /// Test Monobehavior used as root controller for modules.
    /// Concrete examples of this structure could be the "PlayerController" and "EnvironmentRootController" classes.
    /// </summary>
    public class ModulesRootController : BaseController
    {

        [SerializeField]
        [Tooltip("Test module")]
        private Module_Test _testModule = null;


        public Module_Test TestModule
        {
            get => _testModule;
        }


        #region API

        // The commented code is another example of how you can subscribe to modules events.

        public override void SetUp(/*SceneRootController sceneRootController = null*//*SystemsManager systemsManager*/)
        {

            //Module_Test testModule = _testModule as Module_Test;
            //if (testModule != null)
            //{
            //    testModule.OnSetUpMe += systemsManager.GetSystem<SystemAudio>().PlaySfx;
            //}

            _testModule.SetUp();

        }

        public override void CleanUp(/*SceneRootController sceneRootController = null*//*SystemsManager systemsManager*/)
        {

            //Module_Test testModule = _testModule as Module_Test;
            //if (testModule != null)
            //{
            //    testModule.OnSetUpMe -= systemsManager.GetSystem<SystemAudio>().PlaySfx;
            //}

            _testModule.CleanUp();

        }

        #endregion

    }

}