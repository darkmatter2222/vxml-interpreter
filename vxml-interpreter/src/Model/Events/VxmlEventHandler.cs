using System.Collections.Generic;
using VxmlInterpreter.Core;

namespace VxmlInterpreter.Model.Events
{
    /// <summary>
    /// Represents an event handler for a specific VoiceXML event (e.g., noinput, nomatch).
    /// Event handlers define what should happen when the event occurs, which can include:
    /// - Playing prompts
    /// - Executing actions (like <goto>, <exit>)
    /// - Assigning variables
    /// - Transitioning to other dialogs
    ///
    /// In a full implementation:
    /// - We would store references to prompts and executable elements that belong to the event handler.
    /// - We might need logic to determine if conditions are met before executing.
    /// - We will integrate this with the interpreter to invoke the handler when its event fires.
    /// </summary>
    public class VxmlEventHandler
    {
        /// <summary>
        /// The name of the event this handler handles (e.g., "noinput", "nomatch", "help").
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// A list of actions or elements to be executed when this event is triggered.
        /// These might be prompts, goto elements, scripts, etc.
        /// For now, we store objects; later we will define a more structured approach.
        /// </summary>
        private List<object> _actions;

        public VxmlEventHandler(string eventName)
        {
            EventName = eventName;
            _actions = new List<object>();
        }

        /// <summary>
        /// Add an action to be performed when the event occurs.
        /// Once we define action classes (like VxmlPrompt, VxmlGoto), we will use them here.
        /// </summary>
        public StatusCode AddAction(object action)
        {
            if (action == null)
            {
                return StatusCode.ValidationError;
            }
            _actions.Add(action);
            return StatusCode.Success;
        }

        /// <summary>
        /// Execute all actions associated with this event handler.
        /// In the future, this will interface with the interpreter to:
        /// - Play prompts
        /// - Follow gotos
        /// - Execute scripts
        /// For now, just return success as a placeholder.
        /// </summary>
        public StatusCode ExecuteActions()
        {
            // TODO: Implement execution logic once actions are defined.
            return StatusCode.Success;
        }
    }
}
