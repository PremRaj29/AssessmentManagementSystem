using AMS.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XCU.Common.DBHelper;
using System.Data.SqlClient;
using System.Data;
using AMS.API.DTO;
using AMS.API.DTO.SkillCouncil;

namespace AMS.API.Core
{
    public class SkillCouncilDbService : BaseDbService, ISkillCouncilDbService
    {
        #region Public Methods

        #region Comment : Here GET/SELECTION Methods

        /// <summary>
        /// Method will return list of Skill Council of suppllied CouncilType e.g SSC, School
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        SkillCouncilResponse ISkillCouncilDbService.GetSkillCouncil(SkillCouncilRequestParams request)
        {
            SkillCouncilResponse skillCouncilResponse = new SkillCouncilResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("GetSkillCouncil", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@SkillCouncilId", Value = request.SkillCouncilId, SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@CouncilTypeId", Value = request.CouncilTypeId, SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@OnlyActive", Value = request.IsActive, SqlDbType = SqlDbType.Bit }
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listSkillCouncil = new List<SkillCouncil>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listSkillCouncil.Add(
                            new SkillCouncil()
                            {
                                Id = Convert.ToInt32(dataRow["SkillCouncilId"]),
                                CouncilTypeId = Convert.ToInt32(dataRow["CouncilTypeId"]),
                                CouncilType = dataRow["CouncilType"].ToString(),
                                Code = dataRow["Code"].ToString(),
                                FullName = dataRow["FullName"].ToString(),
                                Description = dataRow["Description"].ToString(),
                                IsActive = Convert.ToBoolean((dataRow["IsActive"] == DBNull.Value || dataRow["IsActive"] == null) ? 0 : dataRow["IsActive"])
                            });
                    }
                }

                //assign fecthed list
                skillCouncilResponse.SkillCouncil = listSkillCouncil;
                skillCouncilResponse.OperationStatus = new OperationStatus { ServiceName = "GetSkillCouncils", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                skillCouncilResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "SkillCouncil", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return skillCouncilResponse;
        }

        #endregion

        #region Comment : Here POST/INSERT Methods.

        OperationStatus ISkillCouncilDbService.AddSkillCouncil(SkillCouncil data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int32 effectedRecordId = SubmitSkillCouncil(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "AddSkillCouncil";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "SkillCouncil", DTOProperty = "SkillCouncilId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "SkillCouncil", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }        

        #endregion

        #region Comment : Here PUT/UPDATE Methods.

        OperationStatus ISkillCouncilDbService.UpdateSkillCouncil(SkillCouncil data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int32 effectedRecordId = SubmitSkillCouncil(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "UpdateSkillCouncil";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "SkillCouncil", DTOProperty = "SkillCouncilId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "SkillCouncil", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here DELETE/REMOVE Methods.

        OperationStatus ISkillCouncilDbService.RemoveSkillCouncil(int councilTypeId, int skillCouncilId)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };
            try
            {

                var rowEffeted = GetDbConnector().ExecuteNonQuery("RemoveSkillCouncil", QueryCommandType.StoredProcedure,
                                    new List<IDbDataParameter>
                                    {
                                        new SqlParameter() { ParameterName = "@CouncilTypeId", Value = councilTypeId, SqlDbType = SqlDbType.Int } ,
                                        new SqlParameter() { ParameterName = "@SkillCouncilId", Value = skillCouncilId, SqlDbType = SqlDbType.Int }
                                    });

                //if successfully executed
                if (rowEffeted > 0)
                {
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "RemoveSkillCouncil";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "SkillCouncil", DTOProperty = "SkillCouncilId", IdValue = skillCouncilId.ToString(), OperationType = OperationType.DELETE });
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

        #region Private Methods

        private Int32 SubmitSkillCouncil(SkillCouncil data)
        {
            var parameterList = new List<System.Data.IDbDataParameter>
                                {
                                   new SqlParameter() { ParameterName = "@SkillCouncilId", Value = data.Id, SqlDbType = SqlDbType.Int } ,
                                   new SqlParameter() { ParameterName = "@CouncilTypeId", Value = data.CouncilTypeId, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@Code", Value = data.Code, SqlDbType = SqlDbType.VarChar, Size=10 },
                                   new SqlParameter() { ParameterName = "@FullName", Value = data.FullName, SqlDbType = SqlDbType.VarChar, Size=250 },
                                   new SqlParameter() { ParameterName = "@Description", Value = data.Description, SqlDbType = SqlDbType.VarChar, Size=500 },
                                   new SqlParameter() { ParameterName = "@IsActive", Value = data.IsActive, SqlDbType = SqlDbType.Bit },

                                   new SqlParameter() { ParameterName = "SkillCouncilId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.ReturnValue }
                                };

            //Comment : Here get DbConnector object
            var rowEffeted = GetDbConnector().ExecuteNonQuery("MaintainSkillCouncil", QueryCommandType.StoredProcedure, parameterList);

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