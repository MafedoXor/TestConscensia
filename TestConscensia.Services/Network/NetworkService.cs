using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestConscensia.Abstractions.Mapper;
using TestConscensia.Abstractions.Network;
using TestConscensia.Models.Domain;
using TestConscensia.Models.Dto;
using TestConscensia.Models.Enums;

namespace TestConscensia.Services.Network
{
    public class NetworkService : INetworkService
    {
        private readonly string _connectionUrl;

        private const string _allReportCodes = "api/ReportCode/GetAll";
        private const string _createNewReportCodes = "api/ReportCode/CreateNew";
        private const string _reportCodesByDateRange = "api/ReportCode/GetByDateRange";
        private const string _latestReportCode = "api/ReportCode/GetLatest";
        private const string _reportCodesByLocation = "api/ReportCode/GetByLocation";
        private const string _reportCodesCountByDateRange = "api/ReportCode/GetCountByDateRange";

        private const string _allOfficeLocations = "api/OfficeLocation/GetAll";

        //private readonly IConnectionHelper _connectionHelper;
        private readonly IAppMapper _appMapper;

        public NetworkService(/*IConnectionHelper connectionHelper,*/ IAppMapper appMapper)
        {
            //_connectionHelper = connectionHelper;
            _appMapper = appMapper;
            _connectionUrl = ConfigurationManager.AppSettings["ConnectionUrl"];
        }

        public async Task<IEnumerable<ReportCode>> GetReportCodesByLocation(string officeLocation, CancellationToken token)
        {
            //if (_connectionHelper.IsNetworkAvailable())
            //{
            try
            {
                var response = await SendRequest(HttpRequestEnum.ReportCodesByLocation, HttpMethod.Get, null, token, officeLocation);

                var dtos = JsonConvert.DeserializeObject<IEnumerable<ReportCodeDto>>(response);

                var mapped = _appMapper.Map<IEnumerable<ReportCode>>(dtos);

                return mapped;
            }
            catch (Exception)
            {
                return new List<ReportCode>();
            }
            //}

            //throw new Exception("No Internet connectivity detected. Please reconnect and try again.");
        }

        public async Task<IEnumerable<ReportCode>> GetAllReportCodes(CancellationToken token)
        {
            //if (_connectionHelper.IsNetworkAvailable())
            //{
            try
            {
                var response = await SendRequest(HttpRequestEnum.AllReportCodes, HttpMethod.Get, null, token);

                var dtos = JsonConvert.DeserializeObject<IEnumerable<ReportCodeDto>>(response);

                var mapped = _appMapper.Map<IEnumerable<ReportCode>>(dtos);

                return mapped;
            }
            catch (Exception)
            {
                return new List<ReportCode>();
            }
            //}

            // throw new Exception("No Internet connectivity detected. Please reconnect and try again.");
        }

        public async Task<IEnumerable<OfficeLocation>> GetAllOfficeLocations(CancellationToken token)
        {
            //if (_connectionHelper.IsNetworkAvailable())
            //{
            try
            {
                var response = await SendRequest(HttpRequestEnum.AllOfficeLocations, HttpMethod.Get, null, token);

                var dtos = JsonConvert.DeserializeObject<IEnumerable<OfficeLocationDto>>(response);

                var mapped = _appMapper.Map<IEnumerable<OfficeLocation>>(dtos);

                return mapped;
            }
            catch (Exception)
            {
                return new List<OfficeLocation>();
            }
            //}

            //throw new Exception("No Internet connectivity detected. Please reconnect and try again.");
        }

        public async Task<ReportCode> CreateNewReportCode(OfficeLocation officeLocation, CancellationToken token)
        {
            //if (_connectionHelper.IsNetworkAvailable())
            //{
            try
            {
                var response = await SendRequest(HttpRequestEnum.CreateNewReportCode, HttpMethod.Post, officeLocation, token);

                var dto = JsonConvert.DeserializeObject<ReportCodeDto>(response);

                var mapped = _appMapper.Map<ReportCode>(dto);

                return mapped;
            }
            catch (Exception)
            {
                return null;
            }
            //}

            //throw new Exception("No Internet connectivity detected. Please reconnect and try again.");
        }

        private async Task<string> SendRequest(HttpRequestEnum httpRequest, HttpMethod httpMethod, object content, CancellationToken token, params string[] args)
        {
            int timeout = 30;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var url = _connectionUrl + GetUrl(httpRequest);

                    client.Timeout = TimeSpan.FromSeconds(timeout);

                    AddHeaders(httpRequest, client.DefaultRequestHeaders, ref url, args);

                    HttpResponseMessage response = null;
                    if (httpMethod == HttpMethod.Post)
                    {
                        var json = JsonConvert.SerializeObject(content);
                        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                        response = await client.PostAsync(url, stringContent, token);
                    }
                    else
                    {
                        response = await client.GetAsync(url, token);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        return result;
                    }

                    throw new Exception(response.ReasonPhrase);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AddHeaders(HttpRequestEnum httpRequest, HttpRequestHeaders headers, ref string url, params string[] args)
        {
            switch (httpRequest)
            {
                case HttpRequestEnum.AllReportCodes:
                    break;
                case HttpRequestEnum.ReportCodesByDateRange:
                    url += $"/{args[0]}/{args[1]}";
                    headers.Add("from", args[0]);
                    headers.Add("to", args[1]);
                    break;
                case HttpRequestEnum.LatestReportCode:
                    break;
                case HttpRequestEnum.ReportCodesByLocation:
                    url += $"/{args[0]}";
                    headers.Add("officeLocation", args[0]);
                    break;
                case HttpRequestEnum.ReportCodesCountByDateRange:
                    url += $"/{args[0]}/{args[1]}";
                    headers.Add("from", args[0]);
                    headers.Add("to", args[1]);
                    break;
                case HttpRequestEnum.AllOfficeLocations:
                    break;
                default:
                    break;
            }
        }

        private string GetUrl(HttpRequestEnum httpRequest)
        {
            string url = "";

            switch (httpRequest)
            {
                case HttpRequestEnum.AllReportCodes:
                    url = _allReportCodes;
                    break;
                case HttpRequestEnum.CreateNewReportCode:
                    url = _createNewReportCodes;
                    break;
                case HttpRequestEnum.ReportCodesByDateRange:
                    url = _reportCodesByDateRange;
                    break;
                case HttpRequestEnum.LatestReportCode:
                    url = _latestReportCode;
                    break;
                case HttpRequestEnum.ReportCodesByLocation:
                    url = _reportCodesByLocation;
                    break;
                case HttpRequestEnum.ReportCodesCountByDateRange:
                    url = _reportCodesCountByDateRange;
                    break;
                case HttpRequestEnum.AllOfficeLocations:
                    url = _allOfficeLocations;
                    break;
                default:
                    throw new ArgumentException("invalid enum value", nameof(httpRequest));
            }

            return url;
        }
    }
}