using AMS.API.Contracts;
using AMS.API.DTO;
using AMS.API.DTO.BatchAllocation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using XCU.Common.DBHelper;
using ASSESSOR = AMS.API.DTO.Assessor;

namespace AMS.API.Core
{
    public class BatchAllocationDbService : BaseDbService, IBatchAllocationDbService
    {
        #region Public Methods

        #region Comment : Here GET/SELECTION Methods

        BatchMatchingAssessorResponse IBatchAllocationDbService.GetBatchMatchingAssessors(SearchBatchMatchingAssessorRequestParams request)
        {
            BatchMatchingAssessorResponse batchMatchingAssessorResponse = new BatchMatchingAssessorResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("SearchAssessorForBatchMaster", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@BatchId", Value = request.BatchId, SqlDbType = SqlDbType.VarChar, Size=10 },
                                                new SqlParameter() { ParameterName = "@BatchName", Value = request.BatchName, SqlDbType = SqlDbType.VarChar, Size=100 },
                                                new SqlParameter() { ParameterName = "@AssessorName", Value = request.AssessorName, SqlDbType = SqlDbType.VarChar, Size=200 },
                                                new SqlParameter() { ParameterName = "@AssessmentDate", Value = request.AssessmentDate, SqlDbType = SqlDbType.DateTime },
                                                new SqlParameter() { ParameterName = "@Timing", Value = request.AssessmentTiming, SqlDbType = SqlDbType.Bit }
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listAssessor = new List<ASSESSOR.Assessor>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    Int64 assessorId = 0;

                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        //hold assessor-id
                        assessorId = Convert.ToInt64(dataRow["AssessorId"]);

                        listAssessor.Add(
                            new ASSESSOR.Assessor()
                            {
                                Id = assessorId,

                                //Comment": Here data for BatchDetails
                                PerosnalDetail = new ASSESSOR.AssessorPersonalDetail()
                                {
                                    AssessorId = assessorId,
                                    Name = dataRow["AssessorName"].ToString(),
                                },

                                CommunicationDetail = new ASSESSOR.AssessorCommunicationDetail()
                                {
                                    AssessorId = assessorId,
                                    EmailId = dataRow["EmailId"].ToString(),
                                    MobileNo = dataRow["MobileNo"].ToString(),
                                    WhatsAppNo = dataRow["WhatsAppNo"].ToString(),
                                    StateName = dataRow["AssessorStateName"].ToString(),
                                    CityName = dataRow["AssessorCityName"].ToString(),
                                },
                            });
                    }
                }

                //assign fecthed list
                batchMatchingAssessorResponse.Assessors = listAssessor;
                batchMatchingAssessorResponse.OperationStatus = new OperationStatus { ServiceName = "GetBatchMetchingAssessor", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                batchMatchingAssessorResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "BatchAllocation", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return batchMatchingAssessorResponse;
        }

        #endregion        

        #region Comment : Here POST/CREATE Methods        

        OperationStatus IBatchAllocationDbService.AddBatchAllocation(BatchAllocation data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };
            try
            {

                var parameterList = new List<System.Data.IDbDataParameter>
                                {
                                   new SqlParameter() { ParameterName = "@BatchAllocationId", Value = data.Id, SqlDbType = SqlDbType.BigInt },
                                   new SqlParameter() { ParameterName = "@BatchMasterId", Value = data.BatchMasterId, SqlDbType = SqlDbType.BigInt },
                                   new SqlParameter() { ParameterName = "@AssessorId", Value = data.AssessorId, SqlDbType = SqlDbType.BigInt },
                                   new SqlParameter() { ParameterName = "@AssessmentDate", Value = data.AssessmentDate, SqlDbType = SqlDbType.Date },
                                   new SqlParameter() { ParameterName = "@Timing", Value = data.Timing, SqlDbType = SqlDbType.Bit },

                                   new SqlParameter() { ParameterName = "@CreatedBy", Value = data.CreatedBy, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@ModifiedBy", Value = data.ModifiedBy, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@IsActive", Value = data.IsActive, SqlDbType = SqlDbType.Bit },

                                   new SqlParameter() { ParameterName = "BatchAllocationId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.ReturnValue }
                                };

                //Comment : Here get DbConnector object
                var rowEffeted = GetDbConnector().ExecuteNonQuery("MaintainBatchAllocation", QueryCommandType.StoredProcedure, parameterList);

                //if successfully executed
                if (rowEffeted > 0)
                {
                    Int64 batchAllocationId = Convert.ToInt64(parameterList[parameterList.Count() - 1].Value);

                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "AddBatchAllocation";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "BatchAllocation", DTOProperty = "BatchAllocationId", IdValue = batchAllocationId.ToString(), OperationType = OperationType.DELETE });
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
                operationStatus.Messages.Add(new Message() { DTOName = "JobRole", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            return operationStatus;
        }

        #endregion

        #region Comment : Here DELETE/REMOVE Methods.

        OperationStatus IBatchAllocationDbService.RemoveBatchAllocation(int allocationId, int batchMasterId, int asessorId)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };
            try
            {

                var rowEffeted = GetDbConnector().ExecuteNonQuery("RemoveBatchAllocation", QueryCommandType.StoredProcedure,
                                    new List<IDbDataParameter>
                                    {
                                        new SqlParameter() { ParameterName = "@BatchAllocationId", Value = allocationId, SqlDbType = SqlDbType.BigInt } ,
                                        new SqlParameter() { ParameterName = "@BatchMasterId", Value = batchMasterId, SqlDbType = SqlDbType.BigInt },
                                        new SqlParameter() { ParameterName = "@AssessorId", Value = asessorId, SqlDbType = SqlDbType.BigInt }
                                    });

                //if successfully executed
                if (rowEffeted > 0)
                {
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "RemoveBatchAllocation";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "BatchAllocation", DTOProperty = "BatchAllocationId", IdValue = allocationId.ToString(), OperationType = OperationType.DELETE });
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
                operationStatus.Messages.Add(new Message() { DTOName = "SkillCouncil", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            return operationStatus;
        }

        #endregion

        #endregion        
    }
}