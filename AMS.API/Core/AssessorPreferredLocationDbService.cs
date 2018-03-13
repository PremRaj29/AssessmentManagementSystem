using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XCU.Common.DBHelper;
using System.Data.SqlClient;
using System.Data;
using AMS.API.Contracts;
using AMS.API.DTO;
using AMS.API.DTO.Assessor;


namespace AMS.API.Core
{
    public class AssessorPreferredLocationDbService : BaseDbService, IAssessorPreferredLocationDbService
    {
        #region Public Methods

        #region Comment : Here GET/SELECTION Methods

        /// <summary>
        /// Method will return list of Assessor PreferredLocations
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PreferredLocationsResponse IAssessorPreferredLocationDbService.GetPreferredLocations(AssessorPreferredLocationRequestParams request)
        {
            PreferredLocationsResponse communicationDetailsResponse = new PreferredLocationsResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("GetAssessorPreferredLocations", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@Id", Value = request.Id,SqlDbType = SqlDbType.BigInt },
                                                new SqlParameter() { ParameterName = "@AssessorId", Value = request.AssessorId,SqlDbType = SqlDbType.BigInt },
                                                new SqlParameter() { ParameterName = "@CityId", Value = request.CityId,SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@OnlyActive", Value = request.IsActive, SqlDbType = SqlDbType.Bit }
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listAssessorPerosnalDetail = new List<AssessorPreferredLocation>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listAssessorPerosnalDetail.Add(
                            new AssessorPreferredLocation()
                            {
                                Id = Convert.ToInt64(dataRow["Id"]),
                                AssessorId = Convert.ToInt64(dataRow["AssessorId"]),

                                //rest of fields
                            });
                    }
                }

                //assign fecthed list
                communicationDetailsResponse.PreferredLocations = listAssessorPerosnalDetail;
                communicationDetailsResponse.OperationStatus = new OperationStatus { ServiceName = "GetAssessorPreferredLocation", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                communicationDetailsResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "AssessorPreferredLocation", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return communicationDetailsResponse;
        }

        #endregion

        #region Comment : Here POST/INSERT Methods.

        OperationStatus IAssessorPreferredLocationDbService.AddPreferredLocation(AssessorPreferredLocation data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Add/Create details

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorPreferredLocations(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "AddAssessorPreferredLocation";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorPreferredLocation", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
                }
                else
                {
                    //LoggingService.Instance.Fatal(string.Format("Unable to add user :{0}{1}", Environment.NewLine, object));
                }

                #endregion
            }
            catch (Exception ex)
            {
                operationStatus.RequestProcessed = true;
                operationStatus.RequestSuccessful = false;
                operationStatus.Messages.Add(new Message() { DTOName = "AssessorPreferredLocation", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here PUT/UPDATE Methods.

        OperationStatus IAssessorPreferredLocationDbService.UpdatePreferredLocation(AssessorPreferredLocation data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorPreferredLocations(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "UpdateAssessorPreferredLocation";
                    operationStatus.ServiceMethod = "PUT";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorPreferredLocation", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
                }
                else
                {
                    //LoggingService.Instance.Fatal(string.Format("Unable to add user :{0}{1}", Environment.NewLine, object));
                }

                #endregion
            }
            catch (Exception ex)
            {
                operationStatus.RequestProcessed = true;
                operationStatus.RequestSuccessful = false;
                operationStatus.Messages.Add(new Message() { DTOName = "AssessorPerosnalDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here DELETE/REMOVE Methods.

        OperationStatus IAssessorPreferredLocationDbService.RemovePreferredLocation(Int64 assessorId, int cityId, Int64 id)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };
            try
            {
                var rowEffeted = GetDbConnector().ExecuteNonQuery("RemoveAssessorPreferredLocations", QueryCommandType.StoredProcedure,
                                    new List<IDbDataParameter>
                                    {
                                        new SqlParameter() { ParameterName = "@Id", Value = id,SqlDbType = SqlDbType.BigInt },
                                        new SqlParameter() { ParameterName = "@AssessorId", Value = assessorId,SqlDbType = SqlDbType.BigInt },
                                        new SqlParameter() { ParameterName = "@CityId", Value = cityId,SqlDbType = SqlDbType.Int },
                                    });

                //if successfully executed
                if (rowEffeted > 0)
                {
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "RemoveAssessorPreferredLocation";
                    operationStatus.ServiceMethod = "DELETE";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorPreferredLocation", DTOProperty = "assessorId", IdValue = assessorId.ToString(), OperationType = OperationType.DELETE });
                }
                else
                {
                    //LoggingService.Instance.Fatal(string.Format("Unable to remove organisation-role :{0}{1}", Environment.NewLine, object));
                }

            }
            catch (Exception ex)
            {

                operationStatus.RequestProcessed = true;
                operationStatus.RequestSuccessful = false;
                operationStatus.Messages.Add(new Message() { DTOName = "Assessor", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            return operationStatus;
        }

        #endregion

        #endregion

        #region Private Methods

        private Int64 SubmitAssessorPreferredLocations(AssessorPreferredLocation data)
        {
            var parameterList = new List<System.Data.IDbDataParameter>
                                {
                                    new SqlParameter() { ParameterName = "@Id", Value = data.Id, SqlDbType = SqlDbType.BigInt},
                                    new SqlParameter() { ParameterName = "@AssessorId", Value = data.AssessorId, SqlDbType = SqlDbType.BigInt},
                                    new SqlParameter() { ParameterName = "@CityId", Value = data.CityId, SqlDbType = SqlDbType.Int},
                                    
                                    //5S Params
                                    new SqlParameter() { ParameterName = "@CreatedBy", Value = data.CreatedBy, SqlDbType = SqlDbType.Int },
                                    new SqlParameter() { ParameterName = "@ModifiedBy", Value = data.ModifiedBy, SqlDbType = SqlDbType.Int },
                                    new SqlParameter() { ParameterName = "@IsActive", Value = data.IsActive, SqlDbType = SqlDbType.Bit },

                                    new SqlParameter() { ParameterName = "AssessorId", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.ReturnValue }
                                };

            //Comment : Here get DbConnector object
            var rowEffeted = GetDbConnector().ExecuteNonQuery("MaintainAssessorPreferredLocations", QueryCommandType.StoredProcedure, parameterList);

            //if successfully executed
            if (rowEffeted > 0)
            {
                Int64 assessorId = Convert.ToInt32(parameterList[parameterList.Count() - 1].Value);
                return assessorId;
            }
            else
            {
                //LoggingService.Instance.Fatal(string.Format("Unable to add user :{0}{1}", Environment.NewLine, object));
            }

            return 0;
        }

        #endregion
    }
}