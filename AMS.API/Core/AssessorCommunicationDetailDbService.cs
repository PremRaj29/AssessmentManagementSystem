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
    public class AssessorCommunicationDetailDbService : BaseDbService, IAssessorCommunicationDetailDbService
    {
        #region Public Methods

        #region Comment : Here GET/SELECTION Methods

        /// <summary>
        /// Method will return list of Assessor CommunicationDetails
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        CommunicationDetailsResponse IAssessorCommunicationDetailDbService.GetCommunicationDetails(Int64 assessorId)
        {
            CommunicationDetailsResponse communicationDetailsResponse = new CommunicationDetailsResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("GetAssessorCommunicationDetails", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@AssessorId", Value = assessorId, SqlDbType = SqlDbType.BigInt },
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listAssessorCommunicationDetail = new List<AssessorCommunicationDetail>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listAssessorCommunicationDetail.Add(
                            new AssessorCommunicationDetail()
                            {
                                AssessorId = Convert.ToInt64(dataRow["AssessorId"]),
                                CityId = Convert.ToInt16(dataRow["CityId"]),
                                EmailId = dataRow["EmailId"].ToString(),
                                MobileNo = dataRow["Mobile"].ToString(),

                                //rest of fields
                            });
                    }
                }

                //assign fecthed list
                communicationDetailsResponse.CommunicationDetails = listAssessorCommunicationDetail;
                communicationDetailsResponse.OperationStatus = new OperationStatus { ServiceName = "GetAssessorCommunicationDetail", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                communicationDetailsResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "AssessorCommunicationDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return communicationDetailsResponse;
        }

        #endregion

        #region Comment : Here POST/INSERT Methods.

        OperationStatus IAssessorCommunicationDetailDbService.AddCommunicationDetail(AssessorCommunicationDetail data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Add/Create details

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorCommunicationDetails(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "AddAssessorCommunicationDetail";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorCommunicationDetail", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "AssessorCommunicationDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here PUT/UPDATE Methods.

        OperationStatus IAssessorCommunicationDetailDbService.UpdateCommunicationDetail(AssessorCommunicationDetail data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorCommunicationDetails(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "UpdateAssessorCommunicationDetail";
                    operationStatus.ServiceMethod = "PUT";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "AssessorCommunicationDetail", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "AssessorCommunicationDetail", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here DELETE/REMOVE Methods.

        OperationStatus IAssessorCommunicationDetailDbService.RemoveCommunicationDetail(Int64 assessorId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Private Methods

        private Int64 SubmitAssessorCommunicationDetails(AssessorCommunicationDetail data)
        {
            var parameterList = new List<System.Data.IDbDataParameter>
                                {
                                    new SqlParameter() { ParameterName = "@AssessorId", Value = data.AssessorId, SqlDbType = SqlDbType.BigInt},
                                    new SqlParameter() { ParameterName = "@CityId", Value = data.CityId, SqlDbType = SqlDbType.Int},
                                    new SqlParameter() { ParameterName = "@OtherLocalityName", Value = data.OtherLocalityName, SqlDbType = SqlDbType.VarChar, Size=100 },
                                    new SqlParameter() { ParameterName = "@EmailId", Value = data.EmailId, SqlDbType = SqlDbType.VarChar, Size=150 },
                                    new SqlParameter() { ParameterName = "@MobileNo", Value = data.MobileNo, SqlDbType = SqlDbType.VarChar, Size=10 },
                                    new SqlParameter() { ParameterName = "@WhatsAppOnPrimaryNo", Value = data.WhatsAppOnPrimaryNo, SqlDbType = SqlDbType.Bit},
                                    new SqlParameter() { ParameterName = "@WhatsAppNo", Value = data.WhatsAppNo, SqlDbType = SqlDbType.VarChar, Size=10 },
                                    new SqlParameter() { ParameterName = "@SecondaryEmailId", Value = data.SecondaryEmailId, SqlDbType = SqlDbType.VarChar, Size=150 },
                                    new SqlParameter() { ParameterName = "@SecondaryMobileNo", Value = data.SecondaryMobileNo, SqlDbType = SqlDbType.VarChar, Size=10 },
                                    new SqlParameter() { ParameterName = "@LandlineNo", Value = data.LandlineNo, SqlDbType = SqlDbType.VarChar, Size=15 },
                                    new SqlParameter() { ParameterName = "@EmergancyContactNo1", Value = data.EmergancyContactNo1, SqlDbType = SqlDbType.VarChar, Size=10 },
                                    new SqlParameter() { ParameterName = "@EmergancyContactNo2", Value = data.EmergancyContactNo2, SqlDbType = SqlDbType.VarChar, Size=50 },
                                    new SqlParameter() { ParameterName = "@CommAddressLine1", Value = data.CommAddressLine1, SqlDbType = SqlDbType.VarChar, Size=50 },
                                    new SqlParameter() { ParameterName = "@CommAddressLine2", Value = data.CommAddressLine2, SqlDbType = SqlDbType.VarChar, Size=50 },
                                    new SqlParameter() { ParameterName = "@CommAddressLine3", Value = data.CommAddressLine3, SqlDbType = SqlDbType.VarChar, Size=50 },
                                    new SqlParameter() { ParameterName = "@CommAddressPinCode", Value = data.CommAddressPinCode, SqlDbType = SqlDbType.VarChar, Size=5 },
                                    new SqlParameter() { ParameterName = "@HasSameAsCommAddress", Value = data.HasSameAsCommAddress, SqlDbType = SqlDbType.Bit},
                                    new SqlParameter() { ParameterName = "@PermanentAddressLine1", Value = data.PermanentAddressLine1, SqlDbType = SqlDbType.VarChar, Size=50 },
                                    new SqlParameter() { ParameterName = "@PermanentAddressLine2", Value = data.PermanentAddressLine2, SqlDbType = SqlDbType.VarChar, Size=50 },
                                    new SqlParameter() { ParameterName = "@PermanentAddressLine3", Value = data.PermanentAddressLine3, SqlDbType = SqlDbType.VarChar, Size=50 },
                                    new SqlParameter() { ParameterName = "@PermanentAddressPinCode", Value = data.PermanentAddressPinCode, SqlDbType = SqlDbType.VarChar, Size=5 },

                                    new SqlParameter() { ParameterName = "AssessorId", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.ReturnValue }
                                };

            //Comment : Here get DbConnector object
            var rowEffeted = GetDbConnector().ExecuteNonQuery("MaintainAssessorCommunicationDetails", QueryCommandType.StoredProcedure, parameterList);

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