using AutoMapper;
using System;
using TestConscensia.Abstractions.Mapper;

namespace TestConscensia.Services.Mapper
{
    public class AppMapper : IAppMapper
    {
        #region fields
        private AutoMapper.Mapper _localMapper;
        #endregion

        #region Constructors

        public AppMapper()
        {
            _localMapper = new AutoMapper.Mapper(Config());

            try
            {
                _localMapper.DefaultContext.Mapper.ConfigurationProvider.AssertConfigurationIsValid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        public void InitMapper()
        {
            _localMapper = new AutoMapper.Mapper(Config());

            try
            {
                _localMapper.DefaultContext.Mapper.ConfigurationProvider.AssertConfigurationIsValid();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public TDes Map<TSource, TDes>(TSource source)
        {
            return _localMapper.DefaultContext.Mapper.Map<TSource, TDes>(source);
        }

        public TDes Map<TDes>(object source)
        {
            return _localMapper.DefaultContext.Mapper.Map<TDes>(source);
        }

        #region all other members

        private MapperConfiguration Config()
        {
            var cfg = new MapperConfiguration(expression =>
            {
                #region Models to Entities and back

                ConfigureEntityToDomainModelsMapping(expression);

                #endregion

                #region Models to Viewmodels and back

                ConfigureViewToDomainModelsMapping(expression);

                #endregion
            });

            return cfg;
        }

        private static void ConfigureEntityToDomainModelsMapping(IMapperConfigurationExpression expression)
        {

        }

        private static void ConfigureViewToDomainModelsMapping(IMapperConfigurationExpression expression)
        {

        }

        #endregion
    }
}