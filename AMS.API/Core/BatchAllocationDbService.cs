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

namespace AMS.API.Core
{
    public class BatchAllocationDbService : BaseDbService, IBatchAllocationDbService
    {
        #region Public Methods

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
                                   new SqlParameter() { ParameterName = "@AssessmentDate", Value = data.AssessmentDate, SqlDbType = SqlDbType.DateTime },
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

        #endregion        
    }
}