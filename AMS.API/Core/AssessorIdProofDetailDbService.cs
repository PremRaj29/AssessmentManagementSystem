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
    public class AssessorIdProofDetailDbService : BaseDbService, IAssessorIdProofDetailDbService
    {
        #region Public Methods

        #region Comment : Here GET/SELECTION Methods

        /// <summary>
        /// Method will return list of Assessor IdProofDetails
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IdProofDetailsResponse IAssessorIdProofDetailDbService.GetIdProofDetails(AssessorIdProofDetailRequestParams request)
        {
            IdProofDetailsResponse communicationDetailsResponse = new IdProofDetailsResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("GetAssessorIdProofDetails", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@Id", Value = request.Id,SqlDbType = SqlDbType.BigInt },
                                                new SqlParameter() { ParameterName = "@AssessorId", Value = request.AssessorId,SqlDbType = SqlDbType.BigInt },
                                                new SqlParameter() { ParameterName = "@IdProofTypeId", Value = request.IdProofTypeId,SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@OnlyActive", Value = request.IsActive, SqlDbType = SqlDbType.Bit }
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listAssessorPerosnalDetail = new List<AssessorIdProofDetail>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listAssessorPerosnalDetail.Add(
                            new AssessorIdProofDetail()
                            {
                                Id = Convert.ToInt64(dataRow["Id"]),
                                AssessorId = Convert.ToInt64(dataRow["AssessorId"]),

                                //rest of fields
                            });
                    }
                }

                //assign fecthed list
                communicationDetailsResponse.IdProofDetails = listAssessorPerosnalDetail;
                communicationDetailsResponse.OperationStatus = new OperationStatus { ServiceName = "GetAssessorIdProofDetail", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                communicationDetailsResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "AssessorIdProofDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return communicationDetailsResponse;
        }

        #endregion

        #region Comment : Here POST/INSERT Methods.

        OperationStatus IAssessorIdProofDetailDbService.AddIdProofDetail(AssessorIdProofDetail data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Add/Create details

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorIdProofDetails(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "AddAssessorIdProofDetail";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorIdProofDetail", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "AssessorIdProofDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here PUT/UPDATE Methods.

        OperationStatus IAssessorIdProofDetailDbService.UpdateIdProofDetail(AssessorIdProofDetail data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorIdProofDetails(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "UpdateAssessorIdProofDetail";
                    operationStatus.ServiceMethod = "PUT";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorIdProofDetail", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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

        OperationStatus IAssessorIdProofDetailDbService.RemoveIdProofDetail(Int64 assessorId, int idProofTypeId, Int64 id)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };
            try
            {
                var rowEffeted = GetDbConnector().ExecuteNonQuery("RemoveAssessorIdProofDetails", QueryCommandType.StoredProcedure,
                                    new List<IDbDataParameter>
                                    {
                                        new SqlParameter() { ParameterName = "@Id", Value = id,SqlDbType = SqlDbType.BigInt },
                                        new SqlParameter() { ParameterName = "@AssessorId", Value = assessorId,SqlDbType = SqlDbType.BigInt },
                                        new SqlParameter() { ParameterName = "@IdProofTypeId", Value = idProofTypeId,SqlDbType = SqlDbType.Int },
                                    });

                //if successfully executed
                if (rowEffeted > 0)
                {
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "RemoveAssessorIdProofDetail";
                    operationStatus.ServiceMethod = "DELETE";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorIdProofDetail", DTOProperty = "assessorId", IdValue = assessorId.ToString(), OperationType = OperationType.DELETE });
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

        private Int64 SubmitAssessorIdProofDetails(AssessorIdProofDetail data)
        {
            var parameterList = new List<System.Data.IDbDataParameter>
                                {
                                    new SqlParameter() { ParameterName = "@Id", Value = data.Id, SqlDbType = SqlDbType.BigInt},
                                    new SqlParameter() { ParameterName = "@AssessorId", Value = data.AssessorId, SqlDbType = SqlDbType.BigInt},
                                    new SqlParameter() { ParameterName = "@IdProofTypeId", Value = data.IdProofTypeId, SqlDbType = SqlDbType.Int},
                                    new SqlParameter() { ParameterName = "@UniqueNumber", Value = data.UniqueNumber, SqlDbType = SqlDbType.VarChar, Size=30 },
                                    new SqlParameter() { ParameterName = "@NameOnDocument", Value = data.NameOnDocument, SqlDbType = SqlDbType.VarChar, Size=200 },
                                    new SqlParameter() { ParameterName = "@DocumentFileName", Value = data.DocumentFileName, SqlDbType = SqlDbType.VarChar, Size=50 },
                                    
                                    //5S Params
                                    new SqlParameter() { ParameterName = "@CreatedBy", Value = data.CreatedBy, SqlDbType = SqlDbType.Int },
                                    new SqlParameter() { ParameterName = "@ModifiedBy", Value = data.ModifiedBy, SqlDbType = SqlDbType.Int },
                                    new SqlParameter() { ParameterName = "@IsActive", Value = data.IsActive, SqlDbType = SqlDbType.Bit },

                                    new SqlParameter() { ParameterName = "AssessorIdProofDocMappingId", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.ReturnValue }
                                };

            //Comment : Here get DbConnector object
            var rowEffeted = GetDbConnector().ExecuteNonQuery("MaintainAssessorIdProofDetails", QueryCommandType.StoredProcedure, parameterList);

            //if successfully executed
            if (rowEffeted > 0)
            {
                Int64 assessorIdProofDocMappingId = Convert.ToInt64(parameterList[parameterList.Count() - 1].Value);
                return assessorIdProofDocMappingId;
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