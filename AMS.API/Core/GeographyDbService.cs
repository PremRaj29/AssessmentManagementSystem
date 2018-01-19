using AMS.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XCU.Common.DBHelper;
using System.Data.SqlClient;
using System.Data;
using AMS.API.DTO.Geography;
using AMS.API.DTO;

namespace AMS.API.Core
{
    public class GeographyDbService : BaseDbService, IGeographyDbService
    {
        #region Public Methods

        #region Comment : Here GET/SELECTION Methods        

        /// <summary>
        /// Return list of Geography data like State, City
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GeographyResponse IGeographyDbService.GetGeographies(GeographyRequestParams request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return list of States or specific state when state-id is supplied
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns></returns>
        GeographyResponse IGeographyDbService.GetStates(int stateId)
        {
            GeographyResponse geographyResponse = new GeographyResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("GetStates", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@StateId", Value = stateId, SqlDbType = SqlDbType.Int }
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listStates = new List<State>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listStates.Add(
                            new State()
                            {
                                Id = Convert.ToInt32(dataRow["StateId"]),
                                Name = dataRow["StateName"].ToString(),
                            });
                    }
                }

                //assign fecthed list
                geographyResponse.States = listStates;
                geographyResponse.OperationStatus = new OperationStatus { ServiceName = "GetStates", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                geographyResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "State", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return geographyResponse;
        }

        /// <summary>
        /// Return list of Cities under state-id or specific City when city-id supplied
        /// </summary>
        /// <param name="stateId"></param>
        /// <param name="cityId"></param>
        /// <returns></returns>
        GeographyResponse IGeographyDbService.GetCities(int stateId, int cityId)
        {
            GeographyResponse geographyResponse = new GeographyResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("GetCities", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@StateId", Value = stateId, SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@CityId", Value = cityId, SqlDbType = SqlDbType.Int }
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listCities = new List<City>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listCities.Add(
                            new City()
                            {
                                Id = Convert.ToInt32(dataRow["CityId"]),
                                StateId = Convert.ToInt32(dataRow["StateId"]),                                
                                Name = dataRow["CityName"].ToString(),
                                StateName = dataRow["StateName"].ToString(),
                                IsActive = Convert.ToBoolean((dataRow["IsActive"] == DBNull.Value || dataRow["IsActive"] == null) ? 0 : dataRow["IsActive"])
                            });
                    }
                }

                //assign fecthed list
                geographyResponse.Cities = listCities;
                geographyResponse.OperationStatus = new OperationStatus { ServiceName = "GetCities", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                geographyResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "City", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return geographyResponse;
        }

        #endregion

        #endregion        
    }
}