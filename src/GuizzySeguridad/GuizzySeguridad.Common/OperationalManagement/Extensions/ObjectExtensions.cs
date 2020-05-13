// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectExtensions.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ObjectExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.OperationalManagement.Extensions
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// The object extensions.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// The json serializer settings.
        /// </summary>
        private static readonly JsonSerializerSettings JsonSerializerSettings;

        /// <summary>
        /// Initializes static members of the <see cref="ObjectExtensions"/> class.
        /// </summary>
        static ObjectExtensions()
        {
            JsonSerializerSettings = new JsonSerializerSettings
                                         {
                                             ContractResolver = new CamelCasePropertyNamesContractResolver()
                                         };
        }

        /// <summary>
        /// The to json.
        /// </summary>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToJson(this object target)
        {
            return JsonConvert.SerializeObject(target, JsonSerializerSettings);
        }   
    }
}