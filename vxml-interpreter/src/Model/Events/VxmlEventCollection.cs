using System.Collections.Generic;
using VxmlInterpreter.Core;

namespace VxmlInterpreter.Model.Events
{
    /// <summary>
    /// Manages a collection of event handlers for a given scope (document, dialog, or field).
    /// When an event occurs, the interpreter looks up the event handler by name and executes
    /// the associated actions.
    /// 
    /// Future expansions:
    /// - Add methods to merge event collections from multiple scopes, as VoiceXML specifies a hierarchy.
    /// - Add more sophisticated logic for conditional event handlers.
    /// </summary>
    public class VxmlEventCollection
    {
        private Dictionary<string, VxmlEventHandler> _eventHandlers;

        public VxmlEventCollection()
        {
            _eventHandlers = new Dictionary<string, VxmlEventHandler>();
        }

        /// <summary>
        /// Adds an event handler to this collection.
        /// If an event handler for the same event already exists, it may be replaced or produce a validation error, 
        /// depending on specification details. For simplicity, we’ll replace it here.
        /// </summary>
        public StatusCode AddEventHandler(VxmlEventHandler handler)
        {
            if (handler == null || string.IsNullOrWhiteSpace(handler.EventName))
            {
                return StatusCode.ValidationError;
            }

            _eventHandlers[handler.EventName.ToLower()] = handler;
            return StatusCode.Success;
        }

        /// <summary>
        /// Gets the event handler for a given event name, or null if none is defined.
        /// </summary>
        public VxmlEventHandler GetEventHandler(string eventName)
        {
            if (string.IsNullOrWhiteSpace(eventName))
                return null;

            _eventHandlers.TryGetValue(eventName.ToLower(), out var handler);
            return handler;
        }

        /// <summary>
        /// Executes the event handler associated with the given event, if any.
        /// Returns StatusCode.Success if handled, or StatusCode.EventNotHandled if no handler is found.
        /// </summary>
        public StatusCode HandleEvent(string eventName)
        {
            var handler = GetEventHandler(eventName);
            if (handler == null)
            {
                return StatusCode.EventNotHandled;
            }

            return handler.ExecuteActions();
        }
    }
}
