using VxmlInterpreter.Core;

namespace VxmlInterpreter.Model.Dialogs
{
    /// <summary>
    /// VxmlDialog is an abstract base class for any dialog type in VoiceXML 2.1.
    /// Dialogs can be forms, menus, or subdialogs, each with distinct behaviors.
    /// 
    /// Common responsibilities:
    /// - Holding an identifier (id attribute)
    /// - Providing a method to initialize or "start" the dialog
    /// - Providing a method to determine if the dialog is complete
    /// - Managing local event handlers and properties
    /// 
    /// Derived classes will implement their own logic for:
    /// - Presenting prompts
    /// - Handling user input (fields, choices)
    /// - Navigation between form items or menu choices
    /// - Triggering events like noinput, nomatch, help
    /// </summary>
    public abstract class VxmlDialog
    {
        /// <summary>
        /// The unique identifier of the dialog, typically set by the 'id' attribute in VoiceXML.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Initialize the dialog, preparing it for interaction.
        /// For forms: reset fields, set initial prompts.
        /// For menus: prepare menu choices, prompts.
        /// 
        /// Returns a StatusCode indicating success or the type of error encountered.
        /// </summary>
        public abstract StatusCode StartDialog();

        /// <summary>
        /// Checks if this dialog is complete.
        /// For forms: check if all required fields have values.
        /// For menus: check if a choice was selected and navigation occurred.
        /// 
        /// Returns true if the dialog no longer needs user interaction and can transition.
        /// </summary>
        public abstract bool IsComplete();
    }
}
