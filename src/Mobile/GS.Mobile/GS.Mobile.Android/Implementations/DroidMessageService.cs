// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DroidMessageService.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the DroidMessageService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GS.Mobile.Droid.Implementations;

[assembly: Xamarin.Forms.Dependency(typeof(DroidMessageService))]

namespace GS.Mobile.Droid.Implementations
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Android.App;
    using GS.Mobile.Share.Messages;
    using GS.Mobile.Types.Extensions;
    using GS.Mobile.Types.Messages;

    using Xamarin.Forms;

    /// <summary>
    /// The message service implementation.
    /// </summary>
    public class DroidMessageService : IMessageService
    {
        /// <summary>
        /// The open dialogs.
        /// </summary>
        private readonly List<AlertDialog> openDialogs;

        /// <summary>
        /// Initializes a new instance of the <see cref="DroidMessageService"/> class.
        /// </summary>
        public DroidMessageService()
        {
            this.openDialogs = new List<AlertDialog>();
        }

        /// <inheritdoc />
        public async Task ShowMessageAsync(MessageType type, string message)
        {
            await this.ShowAlert(type.GetFriendlyName(), message, UserResponse.Ok.GetFriendlyName());
        }

        /// <inheritdoc />
        public async Task<bool> ShowQuestionMessageAsync(MessageType type, string message)
        {
            return await this.ShowAlert(type.GetFriendlyName(), message, UserResponse.Yes.GetFriendlyName(), UserResponse.No.GetFriendlyName());
        }

        /// <summary>
        /// Shows a dialog on screen.
        /// </summary>
        /// <param name="title">
        /// The dialog title.
        /// </param>
        /// <param name="content">
        /// The dialog content.
        /// </param>
        /// <param name="confirmButtonText">
        /// The confirm button text.
        /// </param>
        /// <param name="cancelButtonText">
        /// The cancel button text.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private Task<bool> ShowAlert(string title, string content, string confirmButtonText = null, string cancelButtonText = null)
        {
            var tcs = new TaskCompletionSource<bool>();
            var alert = new AlertDialog.Builder(MainActivity.ApplicationInstance);
            alert.SetTitle(title);
            alert.SetMessage(content);

            if (!string.IsNullOrEmpty(confirmButtonText))
            {
                alert.SetPositiveButton(
                    confirmButtonText,
                    (sender, e) =>
                    {
                        // callback?.Invoke(true);
                        tcs.SetResult(true);
                        this.CloseAllDialogs();
                    });
            }

            if (!string.IsNullOrEmpty(cancelButtonText))
            {
                alert.SetNegativeButton(
                    cancelButtonText,
                    (sender, e) =>
                    {
                        // callback?.Invoke(false);
                        tcs.SetResult(false);
                        this.CloseAllDialogs();
                    });
            }

            Device.BeginInvokeOnMainThread(() =>
            {
                var dialog = alert.Show();
                this.openDialogs.Add(dialog);
                dialog.SetCanceledOnTouchOutside(false);
                dialog.SetCancelable(false);
            });

            return tcs.Task;
        }

        /// <summary>
        /// Closes all opened dialogs.
        /// </summary>
        private void CloseAllDialogs()
        {
            foreach (var dialog in this.openDialogs)
            {
                dialog.Dismiss();
            }

            this.openDialogs.Clear();
        }
    }
}