// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumExtensions.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the EnumExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Types.Extensions
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Enum extension methods.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets enum friendly name.
        /// </summary>
        /// <param name="enumValue">
        /// The enumeration value.
        /// </param>
        /// <typeparam name="T">
        /// Enum based object.
        /// </typeparam>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when parameter is not a enum based object.
        /// </exception>
        public static string GetFriendlyName<T>(this T enumValue) where T : struct
        {
            var type = enumValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumValue));
            }

            var memberInfo = type.GetMember(enumValue.ToString());

            var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : enumValue.ToString();
        }
    }
}