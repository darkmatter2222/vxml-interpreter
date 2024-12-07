using VxmlInterpreter.Core;

namespace VxmlInterpreter.Model.Elements
{
    /// <summary>
    /// Represents a <field> element in a <form> dialog.
    /// A field collects user input (via speech or DTMF), stores the result in a variable,
    /// and may trigger filled actions when successfully completed.
    /// 
    /// Fields may have:
    /// - A 'name' attribute that represents the variable bound to user input.
    /// - Grammars that define what input is valid.
    /// - Prompts for asking the user for input.
    /// - Filled elements or actions once input is successfully collected.
    /// - Event handlers (noinput, nomatch, help).
    /// 
    /// This class is a placeholder and will be fleshed out as we implement more 
    /// of the specification, including grammar support and event handling.
    /// </summary>
    public class VxmlField
    {
        /// <summary>
        /// The name of this field, corresponding to a variable where the user's 
        /// input will be stored.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// The current value of this field once filled. Initially empty.
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// Indicates whether this field has been successfully filled.
        /// </summary>
        public bool IsFilled { get; set; }

        /// <summary>
        /// Resets the field to its initial (unfilled) state.
        /// </summary>
        public StatusCode Reset()
        {
            Value = string.Empty;
            IsFilled = false;
            return StatusCode.Success;
        }

        /// <summary>
        /// Sets the field value and marks it as filled.
        /// </summary>
        public StatusCode SetValue(string newValue)
        {
            // In a full implementation, we would validate this value against the field’s grammar.
            // For now, assume all input is valid.
            Value = newValue;
            IsFilled = true;
            return StatusCode.Success;
        }

        // Future enhancements:
        // - Add references to prompt lists
        // - Add references to grammars and grammar validation logic
        // - Add event handling (e.g., noinput, nomatch)
        // - Add type checking and built-in formatting checks
    }
}
