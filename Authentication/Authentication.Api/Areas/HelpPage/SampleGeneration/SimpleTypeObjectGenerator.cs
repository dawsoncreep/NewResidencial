// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleTypeObjectGenerator.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SimpleTypeObjectGenerator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api.Areas.HelpPage.SampleGeneration
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    /// <summary>
    /// The simple type object generator.
    /// </summary>
    internal class SimpleTypeObjectGenerator
    {
        /// <summary>
        /// The default generators.
        /// </summary>
        private static readonly Dictionary<Type, Func<long, object>> DefaultGenerators = InitializeGenerators();

        /// <summary>
        /// The index.
        /// </summary>
        private long index;

        /// <summary>
        /// The initialize generators.
        /// </summary>
        /// <returns>
        /// The <see cref="Dictionary{T,F}"/>.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "These are simple type factories and cannot be split up.")]
        private static Dictionary<Type, Func<long, object>> InitializeGenerators()
        {
            return new Dictionary<Type, Func<long, object>>
                {
                    { typeof(bool), index => true },
                    { typeof(byte), index => (byte)64 },
                    { typeof(char), index => (char)65 },
                    { typeof(DateTime), index => DateTime.Now },
                    { typeof(DateTimeOffset), index => new DateTimeOffset(DateTime.Now) },
                    { typeof(DBNull), index => DBNull.Value },
                    { typeof(decimal), index => (decimal)index },
                    { typeof(double), index => (double)(index + 0.1) },
                    { typeof(Guid), index => Guid.NewGuid() },
                    { typeof(short), index => (short)(index % short.MaxValue) },
                    { typeof(int), index => (int)(index % int.MaxValue) },
                    { typeof(long), index => (long)index },
                    { typeof(object), index => new object() },
                    { typeof(sbyte), index => (sbyte)64 },
                    { typeof(float), index => (float)(index + 0.1) },
                    {
                        typeof(string), index => string.Format(CultureInfo.CurrentCulture, "sample string {0}", index)
                    },
                    {
                        typeof(TimeSpan), index => TimeSpan.FromTicks(1234567)
                    },
                    { typeof(ushort), index => (ushort)(index % ushort.MaxValue) },
                    { typeof(uint), index => (uint)(index % uint.MaxValue) },
                    { typeof(ulong), index => (ulong)index },
                    {
                        typeof(Uri), index => new Uri(string.Format(CultureInfo.CurrentCulture, "http://webapihelppage{0}.com", index))
                    },
                };
        }

        /// <summary>
        /// The can generate object.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool CanGenerateObject(Type type)
        {
            return DefaultGenerators.ContainsKey(type);
        }

        /// <summary>
        /// The generate object.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GenerateObject(Type type)
        {
            return DefaultGenerators[type](++this.index);
        }
    }
}