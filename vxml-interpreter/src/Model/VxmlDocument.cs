using System.Collections.Generic;

namespace VxmlInterpreter.Model
{
    /// <summary>
    /// Represents the root VoiceXML document.
    /// This includes:
    /// - A collection of dialogs (forms, menus).
    /// - Global scripts, variables, and properties.
    /// - Document-level event handlers (catch elements).
    /// 
    /// The VxmlDocument class will be populated by the parser and then validated
    /// during initialization. It serves as the entry point for the interpreter's 
    /// dialog execution sequence.
    /// 
    /// Future development:
    /// - Add fields for dialogs
    /// - Add properties for application-level variables and properties
    /// - Add references to global grammars and resources
    /// - Add methods for retrieving dialogs by ID
    /// </summary>
    public class VxmlDocument
    {
        // In VoiceXML, the application is composed of multiple dialogs: forms, menus, etc.
        // We will define VxmlDialog and its subclasses soon.
        private List<object> _dialogs; // Will be replaced by a VxmlDialog type once defined.

        // Application-level variables, properties, and scripts can be stored here.
        // private Dictionary<string, object> _variables;
        // private Dictionary<string, string> _properties;

        // Global event handlers: noinput, nomatch, help, etc., at the document level.
        // private Dictionary<string, object> _eventHandlers; // Will refine this as we define event model.

        public VxmlDocument()
        {
            _dialogs = new List<object>();
        }

        /// <summary>
        /// Add a dialog to the document.
        /// This method will be used by the parser once we have a VxmlDialog type.
        /// </summary>
        /// <param name="dialog">The dialog object to add.</param>
        /// <returns>StatusCode indicating success or error.</returns>
        public Core.StatusCode AddDialog(object dialog)
        {
            if (dialog == null)
            {
                return Core.StatusCode.ValidationError;
            }

            _dialogs.Add(dialog);
            return Core.StatusCode.Success;
        }

        /// <summary>
        /// Retrieve the list of dialogs defined in this document.
        /// Later, we will strongly type this return to a List<VxmlDialog>.
        /// </summary>
        public List<object> GetDialogs()
        {
            return _dialogs;
        }

        // Additional methods to retrieve dialogs by ID, handle global events, 
        // and manage scripts will be added once we define those classes.
    }
}
