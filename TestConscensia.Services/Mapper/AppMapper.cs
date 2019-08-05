using AutoMapper;
using System;
using TestConscensia.Abstractions.Mapper;
using TestConscensia.Data.Entities;
using TestConscensia.Models.Domain;
using TestConscensia.Models.Dto;
using TestConscensia.Models.ViewModels;

namespace TestConscensia.Services.Mapper
{
    public class AppMapper : IAppMapper
    {
        private AutoMapper.Mapper _localMapper;

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

                #region Models to Dtos and back

                ConfigureDtoToDomainModelsMapping(expression);

                #endregion
            });

            return cfg;
        }

        private static void ConfigureEntityToDomainModelsMapping(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ReportCode, ReportCodeEntity>();
            expression.CreateMap<ReportCodeEntity, ReportCode>();

            expression.CreateMap<OfficeLocation, OfficeLocationEntity>();
            expression.CreateMap<OfficeLocationEntity, OfficeLocation>();
        }

        private static void ConfigureViewToDomainModelsMapping(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ReportCode, ReportCodeViewModel>();
            expression.CreateMap<ReportCodeViewModel, ReportCode>();

            expression.CreateMap<OfficeLocation, OfficeLocationViewModel>();
            expression.CreateMap<OfficeLocationViewModel, OfficeLocation>();
        }

        private static void ConfigureDtoToDomainModelsMapping(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ReportCode, ReportCodeDto>();
            expression.CreateMap<ReportCodeDto, ReportCode>();

            expression.CreateMap<OfficeLocation, OfficeLocationDto>();
            expression.CreateMap<OfficeLocationDto, OfficeLocation>();
        }
    }
}