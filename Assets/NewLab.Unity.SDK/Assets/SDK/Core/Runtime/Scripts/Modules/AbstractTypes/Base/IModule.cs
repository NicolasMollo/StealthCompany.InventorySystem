namespace NewLab.Unity.SDK.Core.Modules
{

    /// <summary>
    /// Interface that will be implemented by all types that want to define themselves as "Module"
    /// </summary>
    public interface IModule
    {

        void SetUp();
        void UpdateModule();
        void FixedUpdateModule();
        void CleanUp();

    }

}