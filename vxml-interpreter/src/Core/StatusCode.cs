namespace VxmlInterpreter.Core
{
    /// <summary>
    /// StatusCode is used throughout the interpreter to communicate the result of operations
    /// without throwing exceptions. Each code corresponds to a known state or outcome that 
    /// can be acted upon by the calling code.
    /// </summary>
    public enum StatusCode
    {
        Success = 0,

        // Document loading and parsing errors
        DocumentNotFound = 1,
        ParseError = 2,
        ValidationError = 3,

        // Unsupported or incomplete features
        UnsupportedFeature = 10,

        // Execution errors
        InternalError = 20,
        InvalidState = 21,
        InvalidTransition = 22,
        MissingRequiredElement = 23,
        EventNotHandled = 24,

        // User/Platform interaction related
        UserHangup = 30,
        NoInput = 31,
        NoMatch = 32,
        Cancel = 33,
        HelpRequested = 34,

        // Application flow
        NoMoreDialogs = 40,
        ExitRequested = 41
    }
}
