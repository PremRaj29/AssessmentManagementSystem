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
    public class AssessorJobRoleDbService : BaseDbService, IAssessorJobRoleDbService
    {
        #region Public Methods

        #region Comment : Here GET/SELECTION Methods

        /// <summary>
        /// Method will return list of Assessor JobRoles
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        JobRolesResponse IAssessorJobRoleDbService.GetJobRoles(AssessorJobRoleRequestParams request)
        {
            JobRolesResponse communicationDetailsResponse = new JobRolesResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("GetAssessorJobRoles", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@Id", Value = request.Id,SqlDbType = SqlDbType.BigInt },
                                                new SqlParameter() { ParameterName = "@AssessorId", Value = request.AssessorId,SqlDbType = SqlDbType.BigInt },
                                                new SqlParameter() { ParameterName = "@JobRoleId", Value = request.JobRoleId,SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@OnlyActive", Value = request.IsActive, SqlDbType = SqlDbType.Bit }
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listAssessorPerosnalDetail = new List<AssessorJobRole>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listAssessorPerosnalDetail.Add(
                            new AssessorJobRole()
                            {
                                Id = Convert.ToInt64(dataRow["Id"]),
                                AssessorId = Convert.ToInt64(dataRow["AssessorId"]),

                                //rest of fields
                            });
                    }
                }

                //assign fecthed list
                communicationDetailsResponse.JobRoles = listAssessorPerosnalDetail;
                communicationDetailsResponse.OperationStatus = new OperationStatus { ServiceName = "GetAssessorJobRoles", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                communicationDetailsResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "AssessorJobRole", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return communicationDetailsResponse;
        }

        #endregion

        #region Comment : Here POST/INSERT Methods.

        OperationStatus IAssessorJobRoleDbService.AddJobRole(AssessorJobRole data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Add/Create details

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorJobRoles(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "AddAssessorJobRole";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorJobRole", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "AssessorJobRole", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here PUT/UPDATE Methods.

        OperationStatus IAssessorJobRoleDbService.UpdateJobRole(AssessorJobRole data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorJobRoles(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "UpdateAssessorJobRole";
                    operationStatus.ServiceMethod = "PUT";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorJobRole", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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

        OperationStatus IAssessorJobRoleDbService.RemoveJobRole(Int64 assessorId, int jobRoleId, Int64 id)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };
            try
            {
                var rowEffeted = GetDbConnector().ExecuteNonQuery("RemoveAssessorJobRoles", QueryCommandType.StoredProcedure,
                                    new List<IDbDataParameter>
                                    {
                                        new SqlParameter() { ParameterName = "@Id", Value = id,SqlDbType = SqlDbType.BigInt },
                                        new SqlParameter() { ParameterName = "@AssessorId", Value = assessorId,SqlDbType = SqlDbType.BigInt },
                                        new SqlParameter() { ParameterName = "@JobRoleId", Value = jobRoleId,SqlDbType = SqlDbType.Int },
                                    });

                //if successfully executed
                if (rowEffeted > 0)
                {
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "RemoveAssessorJobRole";
                    operationStatus.ServiceMethod = "DELETE";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorJobRole", DTOProperty = "assessorId", IdValue = assessorId.ToString(), OperationType = OperationType.DELETE });
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

        private Int64 SubmitAssessorJobRoles(AssessorJobRole data)
        {
            var parameterList = new List<System.Data.IDbDataParameter>
                                {
                                    new SqlParameter() { ParameterName = "@Id", Value = data.Id, SqlDbType = SqlDbType.BigInt},
                                    new SqlParameter() { ParameterName = "@AssessorId", Value = data.AssessorId, SqlDbType = SqlDbType.BigInt},
                                    new SqlParameter() { ParameterName = "@JobRoleId", Value = data.JobRoleId, SqlDbType = SqlDbType.Int},
                                    new SqlParameter() { ParameterName = "@ClientStatus", Value = data.ClientStatus, SqlDbType = SqlDbType.Bit},
                                    new SqlParameter() { ParameterName = "@ClientRemarks", Value = data.ClientRemarks, SqlDbType = SqlDbType.VarChar, Size=250 },
                                    
                                    //5S Params
                                    new SqlParameter() { ParameterName = "@CreatedBy", Value = data.CreatedBy, SqlDbType = SqlDbType.Int },
                                    new SqlParameter() { ParameterName = "@ModifiedBy", Value = data.ModifiedBy, SqlDbType = SqlDbType.Int },
                                    new SqlParameter() { ParameterName = "@IsActive", Value = data.IsActive, SqlDbType = SqlDbType.Bit },

                                    new SqlParameter() { ParameterName = "AssessorId", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.ReturnValue }
                                };

            //Comment : Here get DbConnector object
            var rowEffeted = GetDbConnector().ExecuteNonQuery("MaintainAssessorJobRoles", QueryCommandType.StoredProcedure, parameterList);

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