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
    public class AssessorPersonalDetailDbService : BaseDbService, IAssessorPersonalDetailDbService
    {
        #region Public Methods

        #region Comment : Here GET/SELECTION Methods

        /// <summary>
        /// Method will return list of Assessor PerosnalDetails
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PersonalDetailsResponse IAssessorPersonalDetailDbService.GetPersonalDetails(Int64 assessorId)
        {
            PersonalDetailsResponse communicationDetailsResponse = new PersonalDetailsResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("GetAssessorPersonalDetails", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@AssessorId", Value = assessorId, SqlDbType = SqlDbType.BigInt },
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listAssessorPerosnalDetail = new List<AssessorPersonalDetail>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listAssessorPerosnalDetail.Add(
                            new AssessorPersonalDetail()
                            {
                                AssessorId = Convert.ToInt64(dataRow["AssessorId"]),
                                Name = dataRow["Name"].ToString(),
                                FatherName = dataRow["Mobile"].ToString(),

                                //rest of fields
                            });
                    }
                }

                //assign fecthed list
                communicationDetailsResponse.PerosnalDetails = listAssessorPerosnalDetail;
                communicationDetailsResponse.OperationStatus = new OperationStatus { ServiceName = "GetAssessorPersonalDetail", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                communicationDetailsResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "AssessorPersonalDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return communicationDetailsResponse;
        }

        #endregion

        #region Comment : Here POST/INSERT Methods.

        OperationStatus IAssessorPersonalDetailDbService.AddPersonalDetail(AssessorPersonalDetail data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Add/Create details

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorPerosnalDetails(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "AddAssessorPersonalDetail";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorPersonalDetail", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "AssessorPersonalDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here PUT/UPDATE Methods.

        OperationStatus IAssessorPersonalDetailDbService.UpdatePersonalDetail(AssessorPersonalDetail data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorPerosnalDetails(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "UpdateAssessorPersonalDetail";
                    operationStatus.ServiceMethod = "PUT";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorPersonalDetail", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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

        OperationStatus IAssessorPersonalDetailDbService.RemovePersonalDetail(long assessorIdId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Private Methods

        private Int64 SubmitAssessorPerosnalDetails(AssessorPersonalDetail data)
        {
            var parameterList = new List<System.Data.IDbDataParameter>
                                {                                   
                                   new SqlParameter() { ParameterName = "@AssessorId", Value = data.AssessorId, SqlDbType = SqlDbType.BigInt },
                                   new SqlParameter() { ParameterName = "@Name", Value = data.Name, SqlDbType = SqlDbType.VarChar, Size=200 },
                                   new SqlParameter() { ParameterName = "@Gender", Value = data.Gender, SqlDbType = SqlDbType.Char, Size=1 },
                                   new SqlParameter() { ParameterName = "@DOB", Value = data.DOB, SqlDbType = SqlDbType.DateTime },
                                   new SqlParameter() { ParameterName = "@MaritalStatus", Value = data.MaritalStatus, SqlDbType = SqlDbType.Bit },
                                   new SqlParameter() { ParameterName = "@FatherName", Value = data.FatherName, SqlDbType = SqlDbType.VarChar, Size=50 },
                                   new SqlParameter() { ParameterName = "@MotherName", Value = data.MotherName, SqlDbType = SqlDbType.VarChar, Size=50 },

                                   new SqlParameter() { ParameterName = "AssessorId", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.ReturnValue }
                                };

            //Comment : Here get DbConnector object
            var rowEffeted = GetDbConnector().ExecuteNonQuery("MaintainAssessorPersonalDetails", QueryCommandType.StoredProcedure, parameterList);

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