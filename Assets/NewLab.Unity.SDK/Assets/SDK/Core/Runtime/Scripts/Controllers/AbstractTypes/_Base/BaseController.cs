namespace NewLab.Unity.SDK.Core.Systems.Controllers
{
    
    public abstract class BaseController : BaseSystem
    {

        #region API

        /// <summary>
        /// Method that takes care of updating the Controller.
        /// </summary>
        public virtual void UpdateController() { }

        /// <summary>
        /// Method that updates the Controller in fixed mode.
        /// </summary>
        public virtual void FixedUpdateController() { }

        #endregion

    }

    /// <summary> ENG
    /// If an entity (in this case a controller, more specifically a CustomizableItemsController) within a project must have/add new behaviors (methods) 
    /// compared to those defined within the abstract implementations present in the SDK, a new abstract implementation (project specific) that will inherit 
    /// from the abstract implementation of the SDK (Core) and from which all the concrete implementations of the project will inherit, so as to be able to 
    /// use the type of the implementation abstract within the code and be able to "peel and stick" the correct implementation within the editor.
    /// </summary>
    /// <summary> ITA
    /// Nel caso, una entità (in questo caso un controller, più nello specifico un CustomizableItemsController) all'interno di un progetto deve avere/aggiungere
    /// nuovi comportamenti (metodi) rispetto a quelli definiti all'interno delle implementazioni astratte presenti nel SDK si creerà una nuova implementazione astratta
    /// (specifica del progetto) che erediterà dalla implementazione astratta dell'SDK (Core) e da cui erediteranno tutte le implementazioni concrete del progetto, così 
    /// da poter usare il tipo dell'implementazione astratta all'interno del codice e poter "staccare e attaccare" l'implementazione corretta all'interno dell'editor. 
    /// </summary>

}