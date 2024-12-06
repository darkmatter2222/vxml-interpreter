namespace VxmlInterpreter.Core
{
    /// <summary>
    /// Represents the high-level states of the VoiceXML interpreter.
    /// The interpreter transitions through these states as it loads documents,
    /// executes dialogs, handles events, and eventually completes.
    /// </summary>
    public enum InterpreterState
    {
        /// <summary>
        /// The interpreter has not started or has been reset.
        /// </summary>
        Idle = 0,

        /// <summary>
        /// The interpreter is in the process of loading and parsing a VoiceXML document.
        /// </summary>
        Loading = 1,

        /// <summary>
        /// The interpreter is validating and preparing the document (e.g. resolving references).
        /// </summary>
        Initializing = 2,

        /// <summary>
        /// The interpreter is currently active in a dialog, potentially waiting for user input or presenting prompts.
        /// </summary>
        DialogActive = 3,

        /// <summary>
        /// The interpreter is transitioning between dialogs or handling internal events.
        /// </summary>
        Transitioning = 4,

        /// <summary>
        /// The interpreter encountered an error state that it cannot recover from.
        /// </summary>
        Error = 5,

        /// <summary>
        /// The interpreter has completed execution of the entire VoiceXML application.
        /// </summary>
        Complete = 6
    }
}
