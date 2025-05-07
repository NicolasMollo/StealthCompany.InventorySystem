using System;


namespace NewLab.Unity.SDK.Core.Modules
{

    public class Module_Test : BaseModule
    {

        //[SerializeField]
        //private TestData testData = null;

        public Action<Module_Test> OnSetUpMe = null;


        #region API

        public override void SetUp()
        {

            ModuleName = "New name";
            ModuleID = 100;
            OnSetUpMe?.Invoke(this);

        }

        public override void CleanUp()
        {

            ModuleName = "Old name";
            ModuleID = -99;

        }

        #endregion

    }

}