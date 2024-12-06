using VxmlInterpreter.Core;

namespace VxmlInterpreter.Model.Elements
{
    /// <summary>
    /// Represents a <choice> element within a <menu>.
    /// A choice can have:
    /// - A DTMF key or spoken phrase the user can say.
    /// - A 'next' attribute specifying the next dialog or document to transition to.
    /// - Associated prompts or conditional logic.
    /// 
    /// This class provides basic structure to store the choice’s identifier and target.
    /// In a full implementation, you would add:
    /// - Grammar references or inline grammars for speech recognition.
    /// - Handling for events and properties.
    /// - Support for conditional expressions (if present).
    /// </summary>
    public class VxmlMenuChoice
    {
        /// <summary>
        /// An identifier for this choice, which could be DTMF digits or a name.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The URI or dialog ID to jump to if this choice is selected.
        /// This could be another form’s ID or a different VoiceXML document.
        /// </summary>
        public string NextUri { get; set; }

        /// <summary>
        /// Indicates whether this choice has been selected by the user.
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Reset the choice’s selection status.
        /// </summary>
        public StatusCode Reset()
        {
            Selected = false;
            return StatusCode.Success;
        }

        /// <summary>
        /// Marks this choice as selected.
        /// In a full implementation, this might also trigger navigation or 
        /// require additional checks.
        /// </summary>
        public StatusCode Select()
        {
            Selected = true;
            return StatusCode.Success;
        }
    }
}
