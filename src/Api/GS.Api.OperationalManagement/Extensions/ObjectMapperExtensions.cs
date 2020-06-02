// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectMapperExtensions.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ObjectMapperExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.OperationalManagement.Extensions
{
    using System;

    using GS.Api.Types;
    using GS.Api.Types.Exceptions;

    /// <summary>
    /// The object mapper extensions.
    /// </summary>
    public static class ObjectMapperExtensions
    {
        /// <summary>
        /// Transforms a <see cref="source"/> object into a <see cref="TDestination"/> object.
        /// </summary>
        /// <param name="source">
        /// Source object to transform.
        /// </param>
        /// <typeparam name="TDestination">
        /// Transformation result.
        /// </typeparam>        
        /// <returns>
        /// The <see cref="TDestination"/>.
        /// </returns>
        public static TDestination MapTo<TDestination>(this object source)
        {
            try
            {
                return ObjectMapper.MapperInstance.Map<TDestination>(source);
            }
            catch (Exception exception)
            {
                throw new DevelopmentException(exception);
            }
        }
    }
}