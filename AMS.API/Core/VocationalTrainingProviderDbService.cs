using AMS.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XCU.Common.DBHelper;
using System.Data.SqlClient;
using System.Data;
using AMS.API.DTO;
using AMS.API.DTO.VTP;

namespace AMS.API.Core
{
    public class VocationalTrainingProviderDbService : BaseDbService, IVocationalTrainingProviderDbService
    {
        #region Public Methods

        #region Comment : Here GET/SELECTION Methods

        /// <summary>
        /// Method will return list of Vocation training providers 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        VocationalTrainingProviderResponse IVocationalTrainingProviderDbService.GetVocationalTrainingProvider(VocationalTrainingProviderRequestParams request)
        {
            VocationalTrainingProviderResponse vocationalTrainingProviderResponse = new VocationalTrainingProviderResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("GetVocationalTrainingProvider", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@VocationalTrainingProviderId", Value = request.Id, SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@OnlyActive", Value = request.IsActive, SqlDbType = SqlDbType.Bit }
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listVocationalTrainingProvider = new List<VocationalTrainingProvider>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listVocationalTrainingProvider.Add(
                            new VocationalTrainingProvider()
                            {
                                Id = Convert.ToInt32(dataRow["VocationalTrainingProviderId"]),
                                Code = dataRow["Code"].ToString(),
                                Name = dataRow["Name"].ToString(),
                                Description = dataRow["Description"].ToString(),
                                IsActive = Convert.ToBoolean((dataRow["IsActive"] == DBNull.Value || dataRow["IsActive"] == null) ? 0 : dataRow["IsActive"])
                            });
                    }
                }

                //assign fecthed list
                vocationalTrainingProviderResponse.VocationalTrainingProvider = listVocationalTrainingProvider;
                vocationalTrainingProviderResponse.OperationStatus = new OperationStatus { ServiceName = "GetVocationalTrainingProviders", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                vocationalTrainingProviderResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "VocationalTrainingProvider", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return vocationalTrainingProviderResponse;
        }

        #endregion

        #region Comment : Here POST/INSERT Methods.

        OperationStatus IVocationalTrainingProviderDbService.AddVocationalTrainingProvider(VocationalTrainingProvider data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int32 effectedRecordId = SubmitVocationalTrainingProvider(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "AddVocationalTrainingProvider";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "VocationalTrainingProvider", DTOProperty = "VocationalTrainingProviderId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "VocationalTrainingProvider", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }        

        #endregion

        #region Comment : Here PUT/UPDATE Methods.

        OperationStatus IVocationalTrainingProviderDbService.UpdateVocationalTrainingProvider(VocationalTrainingProvider data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int32 effectedRecordId = SubmitVocationalTrainingProvider(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "UpdateVocationalTrainingProvider";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "VocationalTrainingProvider", DTOProperty = "VocationalTrainingProviderId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "VocationalTrainingProvider", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here DELETE/REMOVE Methods.

        OperationStatus IVocationalTrainingProviderDbService.RemoveVocationalTrainingProvider(int vocationalTrainingProviderId)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };
            try
            {

                var rowEffeted = GetDbConnector().ExecuteNonQuery("RemoveVocationalTrainingProvider", QueryCommandType.StoredProcedure,
                                    new List<IDbDataParameter>
                                    {
                                        new SqlParameter() { ParameterName = "@VocationalTrainingProviderId", Value = vocationalTrainingProviderId
                                        ,SqlDbType = SqlDbType.Int }
                                    });

                //if successfully executed
                if (rowEffeted > 0)
                {
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "RemoveVocationalTrainingProvider";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "VocationalTrainingProvider", DTOProperty = "VocationalTrainingProviderId", IdValue = vocationalTrainingProviderId.ToString(), OperationType = OperationType.DELETE });
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
                operationStatus.Messages.Add(new Message() { DTOName = "VocationalTrainingProvider", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            return operationStatus;
        }

        #endregion

        #region Comment : Here Custom Methods

        /// <summary>
        /// Return list of VTP's based on supplied Search-Parameters
        /// </summary>
        /// <returns></returns>
        VocationalTrainingProviderResponse IVocationalTrainingProviderDbService.SearchVtps(string vtpCode, string vtpName)
        {
            VocationalTrainingProviderResponse vocationalTrainingProviderResponse = new VocationalTrainingProviderResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("SearchVTPs", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@VTPCode", Value = vtpCode, SqlDbType = SqlDbType.VarChar, Size=10 },
                                                new SqlParameter() { ParameterName = "@VTPName", Value = vtpName, SqlDbType = SqlDbType.VarChar, Size=500 },
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listVtp = new List<VocationalTrainingProvider>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listVtp.Add(
                            new VocationalTrainingProvider()
                            {
                                Id = Convert.ToInt32(dataRow["VTPId"]),
                                Code = dataRow["Code"].ToString(),
                                Name = dataRow["Name"].ToString(),
                                Description = dataRow["Description"].ToString(),
                                IsActive = Convert.ToBoolean((dataRow["IsActive"] == DBNull.Value || dataRow["IsActive"] == null) ? 0 : dataRow["IsActive"])
                            });
                    }
                }

                //assign fecthed list
                vocationalTrainingProviderResponse.VocationalTrainingProvider = listVtp;
                vocationalTrainingProviderResponse.OperationStatus = new OperationStatus { ServiceName = "SearchVtps", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                vocationalTrainingProviderResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "VTP", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return vocationalTrainingProviderResponse;
        }

        #endregion

        #endregion

        #region Private Methods

        private Int32 SubmitVocationalTrainingProvider(VocationalTrainingProvider data)
        {
            var parameterList = new List<System.Data.IDbDataParameter>
                                {
                                   new SqlParameter() { ParameterName = "@VocationalTrainingProviderId", Value = data.Id, SqlDbType = SqlDbType.Int } ,
                                   new SqlParameter() { ParameterName = "@Code", Value = data.Code, SqlDbType = SqlDbType.VarChar, Size=10 },
                                   new SqlParameter() { ParameterName = "@Name", Value = data.Name, SqlDbType = SqlDbType.VarChar, Size=500 },
                                   new SqlParameter() { ParameterName = "@Description", Value = data.Description, SqlDbType = SqlDbType.VarChar, Size=500 },

                                   new SqlParameter() { ParameterName = "@CreatedBy", Value = data.CreatedBy, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@ModifiedBy", Value = data.ModifiedBy, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@IsActive", Value = data.IsActive, SqlDbType = SqlDbType.Bit },

                                   new SqlParameter() { ParameterName = "VocationalTrainingProviderId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.ReturnValue }
                                };

            //Comment : Here get DbConnector object
            var rowEffeted = GetDbConnector().ExecuteNonQuery("MaintainVocationalTrainingProvider", QueryCommandType.StoredProcedure, parameterList);

            //if successfully executed
            if (rowEffeted > 0)
            {
                Int32 jobRoleId = Convert.ToInt32(parameterList[parameterList.Count() - 1].Value);
                return jobRoleId;
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