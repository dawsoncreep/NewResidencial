// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMessageService.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IMessageService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Share.Messages
{
    using System.Threading.Tasks;

    using GS.Mobile.Types.Messages;

    /// <summary>
    /// The MessageService interface.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Shows a message box dialog.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="message">
        /// The dialog message.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task ShowMessageAsync(MessageType type, string message);

        /// <summary>
        /// Shows a question message.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<bool> ShowQuestionMessageAsync(MessageType type, string message);
    }
}