using AMS.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XCU.Common.DBHelper;
using System.Data.SqlClient;
using System.Data;
using AMS.API.DTO;
using AMS.API.DTO.BatchMaster;
using AMS.API.DTO.BatchAllocation;
using ASSESSOR = AMS.API.DTO.Assessor;

namespace AMS.API.Core
{
    public class BatchMasterDbService : BaseDbService, IBatchMasterDbService
    {
        #region Public Methods

        #region Comment : Here GET/SELECTION Methods

        /// <summary>
        /// Method will return list of BatchMaster
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BatchMasterResponse IBatchMasterDbService.GetBatchMaster(BatchMasterRequestParams request)
        {
            BatchMasterResponse batchMasterResponse = new BatchMasterResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("GetBatchMaster", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@BatchMasterId", Value = request.Id, SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@BatchId", Value = request.BatchId, SqlDbType = SqlDbType.VarChar, Size=10 },
                                                new SqlParameter() { ParameterName = "@BatchName", Value = request.BatchName, SqlDbType = SqlDbType.VarChar, Size=100 },
                                                new SqlParameter() { ParameterName = "@OnlyActive", Value = request.IsActive, SqlDbType = SqlDbType.Bit }
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listBatchMaster = new List<BatchMaster>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    #region STEP-1. Get BatchMaster Related Details

                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listBatchMaster.Add(
                            new BatchMaster()
                            {
                                Id = Convert.ToInt64(dataRow["BatchMasterId"]),
                                BatchId = dataRow["BatchId"].ToString(),
                                BatchName = dataRow["BatchName"].ToString(),

                                //Comment": Here data for BatchDetails
                                BatchDetails = new BatchDetail()
                                {
                                    //refrence key data
                                    SchemeId = Convert.ToInt32(dataRow["SchemeId"]),
                                    JobRoleId = Convert.ToInt32(dataRow["JobRoleId"]),
                                    CityId = Convert.ToInt32(dataRow["CityId"]),
                                    District = dataRow["District"].ToString(),
                                    TotalCandidates = Convert.ToInt32(dataRow["TotalCandidates"]),
                                    VTP_Id = Convert.ToInt32(dataRow["VTP_Id"]),
                                    VTP_SPOC_Name = dataRow["VTP_SPOC_Name"].ToString(),
                                    VTP_SPOC_Email = dataRow["VTP_SPOC_Email"].ToString(),
                                    VTP_SPOC_Mobile = dataRow["VTP_SPOC_Mobile"].ToString(),
                                    VTP_SPOC_Mobile2 = dataRow["VTP_SPOC_Mobile2"].ToString(),
                                    VTP_SPOC_AlternativeNo = dataRow["VTP_SPOC_AlternativeNo"].ToString(),
                                    VTP_Address = dataRow["VTP_Address"].ToString(),
                                    Centre_SPOC_Name = dataRow["Centre_SPOC_Name"].ToString(),
                                    Centre_SPOC_Email = dataRow["Centre_SPOC_Email"].ToString(),
                                    Centre_SPOC_Mobile = dataRow["Centre_SPOC_Mobile"].ToString(),

                                    //refrence key Master values data
                                    SchemeName = dataRow["SchemeName"].ToString(),
                                    JobRoleName = dataRow["JobRoleName"].ToString(),
                                    CityName = dataRow["CityName"].ToString(),
                                    VTP_Name = dataRow["VTP_Name"].ToString(),
                                    StateName = dataRow["StateName"].ToString(),

                                    //other additional inoformation mapping
                                    SkillCouncilTypeId = Convert.ToInt32(dataRow["SkillCouncilTypeId"]),
                                    SkillCouncilId = Convert.ToInt32(dataRow["SkillCouncilId"]),
                                    StateId = Convert.ToInt32(dataRow["StateId"]),
                                },

                                //DB.Null should be checked before conversion
                                CreatedDate = (dataRow["CreatedDate"] == DBNull.Value || dataRow["CreatedDate"] == null) ? (DateTime?)null : Convert.ToDateTime(dataRow["CreatedDate"]),
                                CreatedBy = Convert.ToInt32(dataRow["CreatedBy"]),
                                ModifiedDate = (dataRow["ModifiedDate"] == DBNull.Value || dataRow["ModifiedDate"] == null) ? (DateTime?)null : Convert.ToDateTime(dataRow["ModifiedDate"]),
                                ModifiedBy = Convert.ToInt32((dataRow["ModifiedBy"] != DBNull.Value || dataRow["ModifiedBy"] != null) ? 0 : dataRow["ModifiedBy"]),
                                IsActive = Convert.ToBoolean((dataRow["IsActive"] == DBNull.Value || dataRow["IsActive"] == null) ? 0 : dataRow["IsActive"])
                            });
                    }

                    #endregion

                    #region STEP-2. Get BatchAllocation Related Details

                    Int64 assessorId = 0;

                    foreach (DataRow dataRow in dbSet.Tables[1].Rows)
                    {
                        //hold assessor-id
                        assessorId = Convert.ToInt64(dataRow["AssessorId"]);

                        //Comment": Here data for BatchAllocationDetails
                        listBatchMaster[0].BatchAllocationDetails = new BatchAllocationDetail()
                        {
                            BatchMasterId = Convert.ToInt64(dataRow["AllocatedBatchId"]),
                            BatchId = dataRow["BatchId"].ToString(),
                            BatchName = dataRow["BatchName"].ToString(),
                            BatchAllocationId = Convert.ToInt64(dataRow["BatchAllocationId"]),
                            AssessmentDate = Convert.ToDateTime(dataRow["AllocatedAssessmentDate"]),
                            AssessmentTiming = Convert.ToBoolean(dataRow["AllocatedAssessmentTiming"]),
                            Assessor = new ASSESSOR.Assessor()
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
                                    StateName = dataRow["StateName"].ToString(),
                                    CityName = dataRow["CityName"].ToString(),
                                },
                            }
                        };
                    }

                    #endregion
                }

                //assign fecthed list
                batchMasterResponse.BatchMaster = listBatchMaster;
                batchMasterResponse.OperationStatus = new OperationStatus { ServiceName = "GetBatchMasters", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                batchMasterResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "BatchMaster", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return batchMasterResponse;
        }

        #endregion

        #region Comment : Here POST/INSERT Methods.

        OperationStatus IBatchMasterDbService.AddBatchMaster(BatchMaster data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int32 effectedRecordId = SubmitBatchMaster(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "AddBatchMaster";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "BatchMaster", DTOProperty = "BatchMasterId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "BatchMaster", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here PUT/UPDATE Methods.

        OperationStatus IBatchMasterDbService.UpdateBatchMaster(BatchMaster data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int32 effectedRecordId = SubmitBatchMaster(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "UpdateBatchMaster";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "BatchMaster", DTOProperty = "BatchMasterId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "BatchMaster", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here DELETE/REMOVE Methods.

        OperationStatus IBatchMasterDbService.RemoveBatchMaster(int batchMasterId)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };
            try
            {

                var rowEffeted = GetDbConnector().ExecuteNonQuery("RemoveBatchMaster", QueryCommandType.StoredProcedure,
                                    new List<IDbDataParameter>
                                    {
                                        new SqlParameter() { ParameterName = "@BatchMasterId", Value = batchMasterId
                                        ,SqlDbType = SqlDbType.Int }
                                    });

                //if successfully executed
                if (rowEffeted > 0)
                {
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "RemoveBatchMaster";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "BatchMaster", DTOProperty = "BatchMasterId", IdValue = batchMasterId.ToString(), OperationType = OperationType.DELETE });
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
                operationStatus.Messages.Add(new Message() { DTOName = "BatchMaster", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            return operationStatus;
        }

        #endregion

        #region Comment : Here Custom Methods

        /// <summary>
        /// Return list of BatchMaster details based on supplied Search-Parameters
        /// </summary>
        /// <returns></returns>
        BatchMasterResponse IBatchMasterDbService.SearchBatchMaster(SearchBatchMasterRequestParams request)
        {
            BatchMasterResponse batchMasterResponse = new BatchMasterResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("SearchBatchMaster", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@BatchId", Value = request.BatchId, SqlDbType = SqlDbType.VarChar, Size=10 },
                                                new SqlParameter() { ParameterName = "@BatchName", Value = request.BatchName, SqlDbType = SqlDbType.VarChar, Size=100 },
                                                new SqlParameter() { ParameterName = "@SchemeId", Value = request.SchemeId, SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@JobRoleId", Value = request.JobRoleId, SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@CityId", Value = request.CityId, SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@VTP_Id", Value = request.VTP_Id, SqlDbType = SqlDbType.Int },
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listBatchMaster = new List<BatchMaster>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listBatchMaster.Add(
                            new BatchMaster()
                            {
                                Id = Convert.ToInt64(dataRow["BatchMasterId"]),
                                BatchId = dataRow["BatchId"].ToString(),
                                BatchName = dataRow["BatchName"].ToString(),

                                //Comment": Here data for BatchDetails
                                BatchDetails = new BatchDetail()
                                {
                                    //refrence key data
                                    BatchMasterId = Convert.ToInt32(dataRow["BatchMasterId"]),
                                    SchemeName = dataRow["SchemeName"].ToString(),
                                    JobRoleName = dataRow["JobRoleName"].ToString(),
                                    CityName = dataRow["CityName"].ToString(),
                                    VTP_Name = dataRow["VTP_Name"].ToString(),
                                    TotalCandidates = Convert.ToInt32(dataRow["TotalCandidates"]),
                                },

                                IsActive = Convert.ToBoolean((dataRow["IsActive"] == DBNull.Value || dataRow["IsActive"] == null) ? 0 : dataRow["IsActive"])
                            });
                    }
                }

                //assign fecthed list
                batchMasterResponse.BatchMaster = listBatchMaster;
                batchMasterResponse.OperationStatus = new OperationStatus { ServiceName = "SearchBatchMaster", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                batchMasterResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "BatchMaster", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return batchMasterResponse;
        }

        #endregion

        #endregion

        #region Private Methods

        private Int32 SubmitBatchMaster(BatchMaster data)
        {
            var parameterList = new List<System.Data.IDbDataParameter>
                                {                                   
                                   //Batch-Master related data
                                   new SqlParameter() { ParameterName = "@BatchMasterId", Value = data.Id, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@BatchId", Value = data.BatchId, SqlDbType = SqlDbType.VarChar, Size=10 },
                                   new SqlParameter() { ParameterName = "@BatchName", Value = data.BatchName, SqlDbType = SqlDbType.VarChar, Size=100 },                                   

                                   //Batch other details data-1
                                   new SqlParameter() { ParameterName = "@SchemeId", Value = data.BatchDetails.SchemeId, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@JobRoleId", Value = data.BatchDetails.JobRoleId, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@CityId", Value = data.BatchDetails.CityId, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@District", Value = data.BatchDetails.District, SqlDbType = SqlDbType.VarChar, Size=200 },
                                   new SqlParameter() { ParameterName = "@TotalCandidates", Value = data.BatchDetails.TotalCandidates, SqlDbType = SqlDbType.Int },

                                   //Batch other details data-2
                                   new SqlParameter() { ParameterName = "@VTP_Id", Value = data.BatchDetails.VTP_Id, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@VTP_SPOC_Name", Value = data.BatchDetails.VTP_SPOC_Name, SqlDbType = SqlDbType.VarChar, Size=250 },
                                   new SqlParameter() { ParameterName = "@VTP_SPOC_Email", Value = data.BatchDetails.VTP_SPOC_Email, SqlDbType = SqlDbType.VarChar, Size=150 },
                                   new SqlParameter() { ParameterName = "@VTP_SPOC_Mobile", Value = data.BatchDetails.VTP_SPOC_Mobile, SqlDbType = SqlDbType.VarChar, Size=10 },
                                   new SqlParameter() { ParameterName = "@VTP_SPOC_Mobile2", Value = data.BatchDetails.VTP_SPOC_Mobile2, SqlDbType = SqlDbType.VarChar, Size=10 },
                                   new SqlParameter() { ParameterName = "@VTP_SPOC_AlternativeNo", Value = data.BatchDetails.VTP_SPOC_AlternativeNo, SqlDbType = SqlDbType.VarChar, Size=15 },
                                   new SqlParameter() { ParameterName = "@VTP_Address", Value = data.BatchDetails.VTP_Address, SqlDbType = SqlDbType.VarChar, Size=500 },
                                   new SqlParameter() { ParameterName = "@Centre_SPOC_Name", Value =  data.BatchDetails.Centre_SPOC_Name, SqlDbType = SqlDbType.VarChar, Size=250 },
                                   new SqlParameter() { ParameterName = "@Centre_SPOC_Email", Value = data.BatchDetails.Centre_SPOC_Email, SqlDbType = SqlDbType.VarChar, Size=150 },
                                   new SqlParameter() { ParameterName = "@Centre_SPOC_Mobile", Value = data.BatchDetails.Centre_SPOC_Mobile, SqlDbType = SqlDbType.VarChar, Size=10 },

                                   //5S Params
                                   new SqlParameter() { ParameterName = "@CreatedBy", Value = data.CreatedBy, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@ModifiedBy", Value = data.ModifiedBy, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@IsActive", Value = data.IsActive, SqlDbType = SqlDbType.Bit },

                                   new SqlParameter() { ParameterName = "BatchMasterId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.ReturnValue }
                                };

            //Comment : Here get DbConnector object
            var rowEffeted = GetDbConnector().ExecuteNonQuery("MaintainBatchMaster", QueryCommandType.StoredProcedure, parameterList);

            //if successfully executed
            if (rowEffeted > 0)
            {
                Int32 batchMasterId = Convert.ToInt32(parameterList[parameterList.Count() - 1].Value);
                return batchMasterId;
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