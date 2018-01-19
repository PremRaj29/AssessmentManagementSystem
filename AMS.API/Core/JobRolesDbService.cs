using AMS.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AMS.API.DTO.JobRole;
using XCU.Common.DBHelper;
using System.Data.SqlClient;
using System.Data;
using AMS.API.DTO;

namespace AMS.API.Core
{
    public class JobRolesDbService : BaseDbService, IJobRolesDbService
    {        
        #region Public Methods

        #region Comment : Here GET/SELECTION Methods

        /// <summary>
        /// Method will return list of Job roles defined in sector skill council(SSC)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        JobRoleResponse IJobRolesDbService.GetJobRoles(JobRoleRequestParams request)
        {
            JobRoleResponse jobRolesResponse = new JobRoleResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("GetSkillCouncilJobRoles", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@JobRoleId", Value = request.JobRoleId, SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@SkillCouncilId", Value = request.SkillCouncilId, SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@OnlyActive", Value = request.IsActive, SqlDbType = SqlDbType.Bit }
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listjobRoles = new List<JobRole>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listjobRoles.Add(
                            new JobRole()
                            {
                                Id = Convert.ToInt32(dataRow["JobRoleId"]),
                                SkillCouncilTypeId = Convert.ToInt32(dataRow["SkillCouncilTypeId"]),
                                SkillCouncilId = Convert.ToInt32(dataRow["SkillCouncilId"]),
                                Code = dataRow["Code"].ToString(),
                                Name = dataRow["Name"].ToString(),
                                Description = dataRow["Description"].ToString(),
                                IsActive = Convert.ToBoolean((dataRow["IsActive"] == DBNull.Value || dataRow["IsActive"] == null) ? 0 : dataRow["IsActive"])
                            });
                    }
                }

                //assign fecthed list
                jobRolesResponse.JobRoles = listjobRoles;
                jobRolesResponse.OperationStatus = new OperationStatus { ServiceName = "GetJobRoles", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                jobRolesResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "JobRole", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return jobRolesResponse;
        }

        #endregion

        #region Comment : Here POST/INSERT Methods.

        OperationStatus IJobRolesDbService.AddJobRoles(JobRole data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int32 effectedRecordId = SubmitJobRole(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "AddJobRole";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "JobRole", DTOProperty = "JobRoleId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "JobRole", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here DELETE/REMOVE Methods.

        OperationStatus IJobRolesDbService.RemoveJobRoles(int skillCouncilId, int jobRoleId)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };
            try
            {

                var rowEffeted = GetDbConnector().ExecuteNonQuery("RemoveJobRole", QueryCommandType.StoredProcedure,
                                    new List<IDbDataParameter>
                                    {
                                        new SqlParameter() { ParameterName = "@JobRoleId", Value = jobRoleId, SqlDbType = SqlDbType.Int } ,
                                        new SqlParameter() { ParameterName = "@SkillCouncilId", Value = skillCouncilId, SqlDbType = SqlDbType.Int },
                                        //I think this should be captured who have updated record
                                        //new SqlParameter() { ParameterName = "@ModifiedBy", Value = data.ModifiedBy, SqlDbType = SqlDbType.Int }, 
                                    });

                //if successfully executed
                if (rowEffeted > 0)
                {
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "RemoveJobRole";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "JobRole", DTOProperty = "JobRoleId", IdValue = jobRoleId.ToString(), OperationType = OperationType.DELETE });
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

        #region Comment : Here PUT/UPDATE Methods.

        OperationStatus IJobRolesDbService.UpdateJobRoles(JobRole data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int32 effectedRecordId = SubmitJobRole(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "UpdateJobRole";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "JobRole", DTOProperty = "JobRoleId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "JobRole", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion        

        #region Comment : Here Custom Methods

        /// <summary>
        /// Return list of Job roles based on supplied Search-Parameters
        /// </summary>
        /// <returns></returns>
        JobRoleResponse IJobRolesDbService.SearchJobRoles(SearchJobRolesRequestParams request)
        {
            JobRoleResponse jobRolesResponse = new JobRoleResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("SearchJobRoles", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@JobRoleCode", Value = request.Code, SqlDbType = SqlDbType.VarChar, Size=10 },
                                                new SqlParameter() { ParameterName = "@JobRoleName", Value = request.Name, SqlDbType = SqlDbType.VarChar, Size=500 },
                                                new SqlParameter() { ParameterName = "@SkillCouncilTypeId", Value = request.SkillCouncilTypeId, SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@SkillCouncilId", Value = request.SkillCouncilId, SqlDbType = SqlDbType.Int },
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listjobRoles = new List<JobRole>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listjobRoles.Add(
                            new JobRole()
                            {
                                Id = Convert.ToInt32(dataRow["JobRoleId"]),
                                SkillCouncilId = Convert.ToInt32(dataRow["SkillCouncilId"]),
                                SkillCouncilCode = dataRow["SkillCouncilCode"].ToString(),
                                SkillCouncilName = dataRow["SkillCouncilName"].ToString(),
                                Code = dataRow["Code"].ToString(),
                                Name = dataRow["Name"].ToString(),
                                Description = dataRow["Description"].ToString(),
                                IsActive = Convert.ToBoolean((dataRow["IsActive"] == DBNull.Value || dataRow["IsActive"] == null) ? 0 : dataRow["IsActive"])
                            });
                    }
                }

                //assign fecthed list
                jobRolesResponse.JobRoles = listjobRoles;
                jobRolesResponse.OperationStatus = new OperationStatus { ServiceName = "SearchJobRoles", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                jobRolesResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "JobRole", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return jobRolesResponse;
        }

        #endregion

        #endregion

        #region Private Methods

        private Int32 SubmitJobRole(JobRole data)
        {
            var parameterList = new List<System.Data.IDbDataParameter>
                                {
                                   new SqlParameter() { ParameterName = "@JobRoleId", Value = data.Id, SqlDbType = SqlDbType.Int } ,
                                   new SqlParameter() { ParameterName = "@SkillCouncilId", Value = data.SkillCouncilId, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@Code", Value = data.Code, SqlDbType = SqlDbType.VarChar, Size=10 },
                                   new SqlParameter() { ParameterName = "@Name", Value = data.Name, SqlDbType = SqlDbType.VarChar, Size=500 },
                                   new SqlParameter() { ParameterName = "@Description", Value = data.Description, SqlDbType = SqlDbType.VarChar, Size=500 },

                                   new SqlParameter() { ParameterName = "@CreatedBy", Value = data.CreatedBy, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@ModifiedBy", Value = data.ModifiedBy, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@IsActive", Value = data.IsActive, SqlDbType = SqlDbType.Bit },

                                   new SqlParameter() { ParameterName = "JobRoleId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.ReturnValue }
                                };

            //Comment : Here get DbConnector object
            var rowEffeted = GetDbConnector().ExecuteNonQuery("MaintainJobRoles", QueryCommandType.StoredProcedure, parameterList);

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