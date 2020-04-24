// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectGenerator.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   This class will create an object of a given type and populate it with sample data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api.Areas.HelpPage.SampleGeneration
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// This class will create an object of a given type and populate it with sample data.
    /// </summary>
    public class ObjectGenerator
    {
        /// <summary>
        /// The simple object generator.
        /// </summary>
        private readonly SimpleTypeObjectGenerator simpleObjectGenerator = new SimpleTypeObjectGenerator();

        /// <summary>
        /// The default collection size.
        /// </summary>
        internal const int DefaultCollectionSize = 2;
        
        #region Private Methods
        
        /// <summary>
        /// The generate generic type.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="collectionSize">
        /// The collection size.
        /// </param>
        /// <param name="createdObjectReferences">
        /// The created object references.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object GenerateGenericType(Type type, int collectionSize, Dictionary<Type, object> createdObjectReferences)
        {
            var genericTypeDefinition = type.GetGenericTypeDefinition();
            if (genericTypeDefinition == typeof(Nullable<>))
            {
                return GenerateNullable(type, createdObjectReferences);
            }

            if (genericTypeDefinition == typeof(KeyValuePair<,>))
            {
                return GenerateKeyValuePair(type, createdObjectReferences);
            }

            if (IsTuple(genericTypeDefinition))
            {
                return GenerateTuple(type, createdObjectReferences);
            }

            var genericArguments = type.GetGenericArguments();
            if (genericArguments.Length == 1)
            {
                if (genericTypeDefinition == typeof(IList<>) ||
                    genericTypeDefinition == typeof(IEnumerable<>) ||
                    genericTypeDefinition == typeof(ICollection<>))
                {
                    var collectionType = typeof(List<>).MakeGenericType(genericArguments);
                    return GenerateCollection(collectionType, collectionSize, createdObjectReferences);
                }

                if (genericTypeDefinition == typeof(IQueryable<>))
                {
                    return GenerateQueryable(type, collectionSize, createdObjectReferences);
                }

                var closedCollectionType = typeof(ICollection<>).MakeGenericType(genericArguments[0]);
                if (closedCollectionType.IsAssignableFrom(type))
                {
                    return GenerateCollection(type, collectionSize, createdObjectReferences);
                }
            }

            if (genericArguments.Length == 2)
            {
                if (genericTypeDefinition == typeof(IDictionary<,>))
                {
                    var dictionaryType = typeof(Dictionary<,>).MakeGenericType(genericArguments);
                    return GenerateDictionary(dictionaryType, collectionSize, createdObjectReferences);
                }

                var closedDictionaryType = typeof(IDictionary<,>).MakeGenericType(genericArguments[0], genericArguments[1]);
                if (closedDictionaryType.IsAssignableFrom(type))
                {
                    return GenerateDictionary(type, collectionSize, createdObjectReferences);
                }
            }

            if (type.IsPublic || type.IsNestedPublic)
            {
                return GenerateComplexObject(type, createdObjectReferences);
            }

            return null;
        }

        /// <summary>
        /// Generates the documentation object tuple.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="createdObjectReferences">
        /// The created object references.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object GenerateTuple(Type type, Dictionary<Type, object> createdObjectReferences)
        {
            var genericArgs = type.GetGenericArguments();
            var parameterValues = new object[genericArgs.Length];
            var failedToCreateTuple = true;
            var objectGenerator = new ObjectGenerator();

            for (var i = 0; i < genericArgs.Length; i++)
            {
                parameterValues[i] = objectGenerator.GenerateObject(genericArgs[i], createdObjectReferences);
                failedToCreateTuple &= parameterValues[i] == null;
            }

            if (failedToCreateTuple)
            {
                return null;
            }

            var result = Activator.CreateInstance(type, parameterValues);
            return result;
        }

        /// <summary>
        /// Indicates if the documentation object is a tuple.
        /// </summary>
        /// <param name="genericTypeDefinition">
        /// The generic type definition.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsTuple(Type genericTypeDefinition)
        {
            return genericTypeDefinition == typeof(Tuple<>) ||
                genericTypeDefinition == typeof(Tuple<,>) ||
                genericTypeDefinition == typeof(Tuple<,,>) ||
                genericTypeDefinition == typeof(Tuple<,,,>) ||
                genericTypeDefinition == typeof(Tuple<,,,,>) ||
                genericTypeDefinition == typeof(Tuple<,,,,,>) ||
                genericTypeDefinition == typeof(Tuple<,,,,,,>) ||
                genericTypeDefinition == typeof(Tuple<,,,,,,,>);
        }

        /// <summary>
        /// Generates the documentation object key-value pair.
        /// </summary>
        /// <param name="keyValuePairType">
        /// The key value pair type.
        /// </param>
        /// <param name="createdObjectReferences">
        /// The created object references.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object GenerateKeyValuePair(Type keyValuePairType, Dictionary<Type, object> createdObjectReferences)
        {
            var genericArgs = keyValuePairType.GetGenericArguments();
            var typeK = genericArgs[0];
            var typeV = genericArgs[1];
            var objectGenerator = new ObjectGenerator();
            var keyObject = objectGenerator.GenerateObject(typeK, createdObjectReferences);
            var valueObject = objectGenerator.GenerateObject(typeV, createdObjectReferences);
            if (keyObject == null && valueObject == null)
            {
                // Failed to create key and values
                return null;
            }

            var result = Activator.CreateInstance(keyValuePairType, keyObject, valueObject);
            return result;
        }

        /// <summary>
        /// Generates the documentation object array.
        /// </summary>
        /// <param name="arrayType">
        /// The array type.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <param name="createdObjectReferences">
        /// The created object references.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object GenerateArray(Type arrayType, int size, Dictionary<Type, object> createdObjectReferences)
        {
            var type = arrayType.GetElementType();
            var result = Array.CreateInstance(type ?? throw new InvalidOperationException(), size);
            var areAllElementsNull = true;
            var objectGenerator = new ObjectGenerator();
            for (var i = 0; i < size; i++)
            {
                var element = objectGenerator.GenerateObject(type, createdObjectReferences);
                result.SetValue(element, i);
                areAllElementsNull &= element == null;
            }

            return areAllElementsNull ? null : result;
        }

        /// <summary>
        /// Generates the documentation object dictionary.
        /// </summary>
        /// <param name="dictionaryType">
        /// The dictionary type.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <param name="createdObjectReferences">
        /// The created object references.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object GenerateDictionary(Type dictionaryType, int size, Dictionary<Type, object> createdObjectReferences)
        {
            var typeK = typeof(object);
            var typeV = typeof(object);
            if (dictionaryType.IsGenericType)
            {
                var genericArgs = dictionaryType.GetGenericArguments();
                typeK = genericArgs[0];
                typeV = genericArgs[1];
            }

            var result = Activator.CreateInstance(dictionaryType);
            var addMethod = dictionaryType.GetMethod("Add") ?? dictionaryType.GetMethod("TryAdd");
            var containsMethod = dictionaryType.GetMethod("Contains") ?? dictionaryType.GetMethod("ContainsKey");
            var objectGenerator = new ObjectGenerator();
            for (var i = 0; i < size; i++)
            {
                var newKey = objectGenerator.GenerateObject(typeK, createdObjectReferences);
                if (newKey == null)
                {
                    // Cannot generate a valid key
                    return null;
                }

                if (containsMethod == null)
                {
                    continue;
                }

                var containsKey = (bool)containsMethod.Invoke(result, new[] { newKey });

                if (containsKey)
                {
                    continue;
                }

                var newValue = objectGenerator.GenerateObject(typeV, createdObjectReferences);
                addMethod?.Invoke(result, new[] { newKey, newValue });
            }

            return result;
        }

        /// <summary>
        /// Generates the documentation object enumeration.
        /// </summary>
        /// <param name="enumType">
        /// The enum type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object GenerateEnum(Type enumType)
        {
            var possibleValues = Enum.GetValues(enumType);
            return possibleValues.Length > 0 ? possibleValues.GetValue(0) : null;
        }

        /// <summary>
        /// Generates the documentation queryable object .
        /// </summary>
        /// <param name="queryableType">
        /// The queryable type.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <param name="createdObjectReferences">
        /// The created object references.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object GenerateQueryable(Type queryableType, int size, Dictionary<Type, object> createdObjectReferences)
        {
            var isGeneric = queryableType.IsGenericType;
            object list;
            if (isGeneric)
            {
                var listType = typeof(List<>).MakeGenericType(queryableType.GetGenericArguments());
                list = GenerateCollection(listType, size, createdObjectReferences);
            }
            else
            {
                list = GenerateArray(typeof(object[]), size, createdObjectReferences);
            }

            if (list == null)
            {
                return null;
            }

            if (!isGeneric)
            {
                return Queryable.AsQueryable((IEnumerable)list);
            }

            var argumentType = typeof(IEnumerable<>).MakeGenericType(queryableType.GetGenericArguments());
            var asQueryableMethod = typeof(Queryable).GetMethod("AsQueryable", new[] { argumentType });
            return asQueryableMethod?.Invoke(null, new[] { list });
        }

        /// <summary>
        /// Generates the documentation object collection.
        /// </summary>
        /// <param name="collectionType">
        /// The collection type.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <param name="createdObjectReferences">
        /// The created object references.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object GenerateCollection(Type collectionType, int size, Dictionary<Type, object> createdObjectReferences)
        {
            var type = collectionType.IsGenericType ?
                           collectionType.GetGenericArguments()[0] :
                           typeof(object);
            var result = Activator.CreateInstance(collectionType);
            var addMethod = collectionType.GetMethod("Add");
            var areAllElementsNull = true;
            var objectGenerator = new ObjectGenerator();
            for (var i = 0; i < size; i++)
            {
                var element = objectGenerator.GenerateObject(type, createdObjectReferences);
                addMethod?.Invoke(result, new[] { element });
                areAllElementsNull &= element == null;
            }

            if (areAllElementsNull)
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Generates the documentation nullable object.
        /// </summary>
        /// <param name="nullableType">
        /// The nullable type.
        /// </param>
        /// <param name="createdObjectReferences">
        /// The created object references.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object GenerateNullable(Type nullableType, Dictionary<Type, object> createdObjectReferences)
        {
            var type = nullableType.GetGenericArguments()[0];
            var objectGenerator = new ObjectGenerator();
            return objectGenerator.GenerateObject(type, createdObjectReferences);
        }

        /// <summary>
        /// Generates the documentation complex object.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="createdObjectReferences">
        /// The created object references.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object GenerateComplexObject(Type type, Dictionary<Type, object> createdObjectReferences)
        {
            if (createdObjectReferences.TryGetValue(type, out var result))
            {
                // The object has been created already, just return it. This will handle the circular reference case.
                return result;
            }

            if (type.IsValueType)
            {
                result = Activator.CreateInstance(type);
            }
            else
            {
                var defaultCtor = type.GetConstructor(Type.EmptyTypes);
                if (defaultCtor == null)
                {
                    // Cannot instantiate the type because it doesn't have a default constructor
                    return null;
                }

                result = defaultCtor.Invoke(new object[0]);
            }

            createdObjectReferences.Add(type, result);
            SetPublicProperties(type, result, createdObjectReferences);
            SetPublicFields(type, result, createdObjectReferences);
            return result;
        }

        /// <summary>
        /// Sets the documentation public properties.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <param name="createdObjectReferences">
        /// The created object references.
        /// </param>
        private static void SetPublicProperties(Type type, object obj, Dictionary<Type, object> createdObjectReferences)
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var objectGenerator = new ObjectGenerator();
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    var propertyValue = objectGenerator.GenerateObject(property.PropertyType, createdObjectReferences);
                    property.SetValue(obj, propertyValue, null);
                }
            }
        }

        /// <summary>
        /// Sets the documentation public fields.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <param name="createdObjectReferences">
        /// The created object references.
        /// </param>
        private static void SetPublicFields(Type type, object obj, Dictionary<Type, object> createdObjectReferences)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            var objectGenerator = new ObjectGenerator();
            foreach (var field in fields)
            {
                var fieldValue = objectGenerator.GenerateObject(field.FieldType, createdObjectReferences);
                field.SetValue(obj, fieldValue);
            }
        }

        /// <summary>
        /// Generates an object for a given type. The type needs to be public, have a public default constructor and settable public properties/fields. Currently it supports the following types:
        /// Simple types: <see cref="int"/>, <see cref="string"/>, <see cref="Enum"/>, <see cref="DateTime"/>, <see cref="Uri"/>, etc.
        /// Complex types: POCO types.
        /// Nullables: <see cref="Nullable{T}"/>.
        /// Arrays: arrays of simple types or complex types.
        /// Key value pairs: <see cref="KeyValuePair{TKey,TValue}"/>
        /// Tuples: <see cref="Tuple{T1}"/>, <see cref="Tuple{T1,T2}"/>, etc
        /// Dictionaries: <see cref="IDictionary{TKey,TValue}"/> or anything deriving from <see cref="IDictionary{TKey,TValue}"/>.
        /// Collections: <see cref="IList{T}"/>, <see cref="IEnumerable{T}"/>, <see cref="ICollection{T}"/>, <see cref="IList"/>, <see cref="IEnumerable"/>, <see cref="ICollection"/> or anything deriving from <see cref="ICollection{T}"/> or <see cref="IList"/>.
        /// Queryables: <see cref="IQueryable"/>, <see cref="IQueryable{T}"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>An object of the given type.</returns>
        public object GenerateObject(Type type)
        {
            return this.GenerateObject(type, new Dictionary<Type, object>());
        }

        /// <summary>
        /// Generates the documentation object.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="createdObjectReferences">
        /// The created object references.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Here we just want to return null if anything goes wrong.")]
        private object GenerateObject(Type type, Dictionary<Type, object> createdObjectReferences)
        {
            try
            {
                if (SimpleTypeObjectGenerator.CanGenerateObject(type))
                {
                    return this.simpleObjectGenerator.GenerateObject(type);
                }

                if (type.IsArray)
                {
                    return GenerateArray(type, DefaultCollectionSize, createdObjectReferences);
                }

                if (type.IsGenericType)
                {
                    return GenerateGenericType(type, DefaultCollectionSize, createdObjectReferences);
                }

                if (type == typeof(IDictionary))
                {
                    return GenerateDictionary(typeof(Hashtable), DefaultCollectionSize, createdObjectReferences);
                }

                if (typeof(IDictionary).IsAssignableFrom(type))
                {
                    return GenerateDictionary(type, DefaultCollectionSize, createdObjectReferences);
                }

                if (type == typeof(IList) ||
                    type == typeof(IEnumerable) ||
                    type == typeof(ICollection))
                {
                    return GenerateCollection(typeof(ArrayList), DefaultCollectionSize, createdObjectReferences);
                }

                if (typeof(IList).IsAssignableFrom(type))
                {
                    return GenerateCollection(type, DefaultCollectionSize, createdObjectReferences);
                }

                if (type == typeof(IQueryable))
                {
                    return GenerateQueryable(type, DefaultCollectionSize, createdObjectReferences);
                }

                if (type.IsEnum)
                {
                    return GenerateEnum(type);
                }

                if (type.IsPublic || type.IsNestedPublic)
                {
                    return GenerateComplexObject(type, createdObjectReferences);
                }
            }
            catch
            {
                // Returns null if anything fails
                return null;
            }

            return null;
        }
        #endregion
    }
}