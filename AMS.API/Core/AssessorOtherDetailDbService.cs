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
    public class AssessorOtherDetailDbService : BaseDbService, IAssessorOtherDetailDbService
    {
        #region Public Methods

        #region Comment : Here GET/SELECTION Methods

        /// <summary>
        /// Method will return list of Assessor OtherDetails
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        OtherDetailsResponse IAssessorOtherDetailDbService.GetOtherDetails(Int64 assessorId)
        {
            OtherDetailsResponse communicationDetailsResponse = new OtherDetailsResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("GetAssessorOtherDetails", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@AssessorId", Value = assessorId, SqlDbType = SqlDbType.BigInt },
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listAssessorPerosnalDetail = new List<AssessorOtherDetail>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listAssessorPerosnalDetail.Add(
                            new AssessorOtherDetail()
                            {
                                AssessorId = Convert.ToInt64(dataRow["AssessorId"]),
                                OdigoOkayStatus = dataRow["OdigoOkayStatus"].ToString(),
                                BankName = dataRow["BankName"].ToString(),

                                //rest of fields
                            });
                    }
                }

                //assign fecthed list
                communicationDetailsResponse.OtherDetails = listAssessorPerosnalDetail;
                communicationDetailsResponse.OperationStatus = new OperationStatus { ServiceName = "GetAssessorOtherDetail", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                communicationDetailsResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "AssessorOtherDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return communicationDetailsResponse;
        }

        #endregion

        #region Comment : Here POST/INSERT Methods.

        OperationStatus IAssessorOtherDetailDbService.AddOtherDetail(AssessorOtherDetail data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Add/Create details

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorOtherDetails(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "AddAssessorOtherDetail";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorOtherDetail", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "AssessorOtherDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here PUT/UPDATE Methods.

        OperationStatus IAssessorOtherDetailDbService.UpdateOtherDetail(AssessorOtherDetail data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorOtherDetails(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "UpdateAssessorOtherDetail";
                    operationStatus.ServiceMethod = "PUT";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorOtherDetail", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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

        OperationStatus IAssessorOtherDetailDbService.RemoveOtherDetail(Int64 assessorId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Private Methods

        private Int64 SubmitAssessorOtherDetails(AssessorOtherDetail data)
        {
            var parameterList = new List<System.Data.IDbDataParameter>
                                {
                                    new SqlParameter() { ParameterName = "@AssessorId", Value = data.AssessorId, SqlDbType = SqlDbType.BigInt},
                                    new SqlParameter() { ParameterName = "@OdigoOkayStatus", Value = data.OdigoOkayStatus, SqlDbType = SqlDbType.VarChar, Size=20 },
                                    new SqlParameter() { ParameterName = "@BankName", Value = data.BankName, SqlDbType = SqlDbType.VarChar, Size=250 },
                                    new SqlParameter() { ParameterName = "@AccountNumber", Value = data.AccountNumber, SqlDbType = SqlDbType.VarChar, Size=20 },
                                    new SqlParameter() { ParameterName = "@IFSC_Code", Value = data.IFSC_Code, SqlDbType = SqlDbType.VarChar, Size=20 },
                                    new SqlParameter() { ParameterName = "@BankAddress", Value = data.BankAddress, SqlDbType = SqlDbType.VarChar, Size=500 },
                                    new SqlParameter() { ParameterName = "@HighestQualificationId", Value = data.HighestQualificationId, SqlDbType = SqlDbType.Int},
                                    new SqlParameter() { ParameterName = "@Qualifications", Value = data.Qualifications, SqlDbType = SqlDbType.VarChar, Size=500 },

                                    new SqlParameter() { ParameterName = "AssessorId", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.ReturnValue }
                                };

            //Comment : Here get DbConnector object
            var rowEffeted = GetDbConnector().ExecuteNonQuery("MaintainAssessorOtherDetails", QueryCommandType.StoredProcedure, parameterList);

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