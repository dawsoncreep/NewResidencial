// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectMapper.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ObjectMapper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.Types
{
    using AutoMapper;

    using GS.Api.Types.Models;
    using GS.Api.Types.Models.Persistence;

    /// <summary>
    /// The object mapper.
    /// </summary>
    public static class ObjectMapper
    {
        /// <summary>
        /// Initializes static members of the <see cref="ObjectMapper"/> class.
        /// </summary>
        static ObjectMapper()
        {
            MapperInstance = new Mapper(new MapperConfiguration(MapObjects));
        }

        /// <summary>
        /// The mapper instance.
        /// </summary>
        public static IMapper MapperInstance { get; }

        #region Private Methods
        
        /// <summary>
        /// Defines all objects rules.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        private static void MapObjects(IMapperConfigurationExpression config)
        {
            MapDataLayerObjects(config);
        }

        /// <summary>
        /// Maps all 'Models.Persistence' objects to 'Models' objects.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        private static void MapDataLayerObjects(IProfileExpression config)
        {
            config.CreateMap<SUser, User>()
                .ForMember(dest => dest.Id, worker => worker.MapFrom(source => source.Id))
                .ForMember(dest => dest.Name, worker => worker.MapFrom(source => source.Nombres))
                .ForMember(dest => dest.LastName, worker => worker.MapFrom(source => source.Apellidos))
                .ForMember(dest => dest.Email, worker => worker.MapFrom(source => source.Correo))
                .ForMember(dest => dest.NickName, worker => worker.MapFrom(source => source.Alias))
                .ForMember(dest => dest.Password, worker => worker.MapFrom(source => source.Contraseña));
        }
        #endregion
    }
}