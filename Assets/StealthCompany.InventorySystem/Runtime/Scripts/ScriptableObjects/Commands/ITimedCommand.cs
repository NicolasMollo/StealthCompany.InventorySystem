namespace InventorySystem.ScriptableObjects.Commands
{

    /// <summary>
    /// Interface that will implement all the commands you want to define as timed commands.
    /// </summary>
    public interface ITimedCommand
    {

        public float Duration
        {
            get;
            set;
        }

    }

}