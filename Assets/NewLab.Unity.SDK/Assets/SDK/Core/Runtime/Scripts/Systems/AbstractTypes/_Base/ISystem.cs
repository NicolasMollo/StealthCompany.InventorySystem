namespace NewLab.Unity.SDK.Core.Systems
{

    /// <summary>
    /// Interface that will be implemented by all types that want to define themselves as "System".
    /// </summary>
    public interface ISystem
    {

        void SetUp();
        void CleanUp();

    }

}