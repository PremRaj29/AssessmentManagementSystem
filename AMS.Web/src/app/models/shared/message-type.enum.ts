export enum MessageType 
{
    // ----------------------------------------
    // User-Friendly Messages
    // ----------------------------------------

    /// <summary>
    /// Text contains user-safe information associated with an error condition that halted further processing for the request.  The UI may require the user to take steps, depending on the nature of the issue.
    /// EXAMPLE: 'Annual Premium is Required'
    /// </summary>
    UserError = 1,

    /// <summary>
    /// Text contains user-safe information associated with a questionable condition that the user should be made aware of.  The UI may require the user to take steps, depending on the nature of the issue.
    /// EXAMPLE: 'Your policy doesn't include director coverage. If you require director coverage, please add director coverage before proceeding.'
    /// </summary>
    UserWarning = 2,

    /// <summary>
    /// Text contain user-safe information that the user should be made aware of.  
    /// EXAMPLE: 'Your policy has been created!'
    /// </summary>
    UserInfo = 3,

    // ----------------------------------------
    // Messages intended for UI-developer only; shouldn't be displayed to the user
    // ----------------------------------------

    /// <summary>
    /// Text contains information related to model validation (e.g. Required, Range, StringLength, etc...) that is not suitable for end-user consumption.
    /// EXAMPLE:  'QuoteID is required'
    /// </summary>
    ModelError = 4,

    /// <summary>
    /// Text contains information related to an exception that is not be suitable for end-user consumption.
    /// EXAMPLE: (Incorrectly formatted dollar amount in json data) 'Unexpected character encountered while parsing value: abc Path 'ExposureAmt', line 1, position 193'
    /// </summary>
    SystemError = 5,

    /// <summary>
    /// Text contains other information that is not associated with an error condition, and is not suitable for end-user consumption, but may be useful to developers that use the service.
    /// EXAMPLE: 'Default Value Not Saved.  (Although the value submitted is valid, the system automatically uses default values that are configured for this service; it is therefore not neccesary to submit a defined default value.  Non-default values that are submitted will be saved.)'
    /// </summary>
    SystemInfo = 6
}