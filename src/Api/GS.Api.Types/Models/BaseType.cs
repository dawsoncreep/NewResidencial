// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseType.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the BaseType type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using GS.Api.Types.Exceptions;

    /// <summary>
    /// The base type.
    /// </summary>
    public class BaseType
    {
        /// <summary>
        /// Validates a type object.
        /// </summary>
        /// <exception cref="TypeValidationException">
        /// Thrown when type(model) inherits from <see cref="BaseType"/> and has some invalid properties.
        /// </exception>
        public void Validate()
        {
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results, true);
            if (!isValid)
            {
                throw new TypeValidationException(results.Select(r => r.ErrorMessage));
            }
        }
    }
}
