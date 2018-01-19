import { MessageType } from './message-type.enum';

/// <summary>
/// Message returned by the service
/// </summary>
export class Message
{
    /// <summary>
    /// Name of the DTO associated with the message (Contact, Exposure, Modifier, etc...)
    /// </summary>
    DTOName: string;

    /// <summary>
    /// Name of the DTO' Property associated with the message (ContactName, ExposureAmt, ModifierType, etc...)
    /// </summary>
    DTOProperty: string;

    /// <summary>
    /// Error / Warning / Info / SystemError...<br />
    /// NOTE: 'SystemError' messages contain error text that shouldn't be displayed to end users.<br />
    /// Examples: if a request is not formatted properly...<br />
    ///		"QuoteId is required for the specified Exposure."<br />
    ///		"Unexpected character encountered while parsing value: 'ExposureAmt', line 1, position 175"<br />
    /// </summary>
    MessageType: MessageType;

    /// <summary>
    /// Message Text.<br />
    /// Example:<br />
    ///	The amount specified must be at least: $15,000."<br />
    /// </summary>
    Text: string;
}