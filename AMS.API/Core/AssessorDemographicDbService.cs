using AMS.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XCU.Common.DBHelper;
using System.Data.SqlClient;
using System.Data;
using AMS.API.DTO;
using AMS.API.DTO.Assessor;

namespace AMS.API.Core
{
    public class AssessorDemographicDbService : BaseDbService, IAssessorDemographicDbService
    {
        #region Public Methods

        #region Comment : Here GET/SELECTION Methods

        /// <summary>
        /// Method will return list of Assessor
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        AssessorResponse IAssessorDemographicDbService.GetAssessor(AssessorRequestParams request)
        {
            AssessorResponse assessorResponse = new AssessorResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("GetAssessor", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@AssessorId", Value = request.AssessorId, SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@IRIS_Id", Value = request.IRIS_Id, SqlDbType = SqlDbType.VarChar, Size=30 },
                                                new SqlParameter() { ParameterName = "@OnlyActive", Value = request.IsActive, SqlDbType = SqlDbType.Bit }
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listAssessors = new List<Assessor>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        //get running assessor-id for fetching related child (JobRoles, PrefLocations)
                        Int64 assessorId = Convert.ToInt64(dataRow["AssessorId"]);

                        listAssessors.Add(
                            new Assessor()
                            {
                                Id = assessorId,
                                IRIS_Id = dataRow["IRIS_Id"].ToString(),
                                NSDC_Id = dataRow["NSDC_Id"].ToString(),
                                SSC_Id = dataRow["SSC_Id"].ToString(),

                                #region Comment: Here data for dependent child data like Personal, JobRoles, PrefLocation etc

                                PerosnalDetail = new AssessorPersonalDetail()
                                {
                                    //refrence key data
                                    AssessorId = Convert.ToInt64(dataRow["AssessorId"]),
                                    //SchemeName = dataRow["SchemeName"].ToString(),
                                    //JobRoleName = dataRow["JobRoleName"].ToString(),
                                    //CityName = dataRow["CityName"].ToString(),
                                    //VTP_Name = dataRow["VTP_Name"].ToString(),
                                    //TotalCandidates = Convert.ToInt32(dataRow["TotalCandidates"]),
                                },

                                CommunicationDetail = new AssessorCommunicationDetail()
                                {
                                    //refrence key data
                                    AssessorId = Convert.ToInt64(dataRow["AssessorId"]),
                                    //SchemeName = dataRow["SchemeName"].ToString(),
                                    //JobRoleName = dataRow["JobRoleName"].ToString(),
                                    //CityName = dataRow["CityName"].ToString(),
                                    //VTP_Name = dataRow["VTP_Name"].ToString(),
                                    //TotalCandidates = Convert.ToInt32(dataRow["TotalCandidates"]),
                                },

                                OtherDetail = new AssessorOtherDetail()
                                {
                                    //refrence key data
                                    AssessorId = Convert.ToInt64(dataRow["AssessorId"]),
                                    //SchemeName = dataRow["SchemeName"].ToString(),
                                    //JobRoleName = dataRow["JobRoleName"].ToString(),
                                    //CityName = dataRow["CityName"].ToString(),
                                    //VTP_Name = dataRow["VTP_Name"].ToString(),
                                    //TotalCandidates = Convert.ToInt32(dataRow["TotalCandidates"]),
                                },

                                #region All other related details having mutiple records like JobRoles, PrefLocations will be get from Other DataSet by iteration

                                //get mutiple "IdProofs" details for this/current "Assessor"
                                IdProofs = GetAssessorIdProodDetails(assessorId,dbSet.Tables[1]),

                                //get mutiple "JobRoles" details for this/current "Assessor"
                                //JobRoles = GetAssessorJobRoles(assessorId, dbSet.Tables[2]),

                                //get mutiple "PreferredLocations" details for this/current "Assessor"
                                //PreferredLocations = GetAssessorPreferredLocations(assessorId, dbSet.Tables[3]),

                                #endregion

                                #endregion

                                //DB.Null should be checked before conversion
                                CreatedDate = (dataRow["CreatedDate"] == DBNull.Value || dataRow["CreatedDate"] == null) ? (DateTime?)null : Convert.ToDateTime(dataRow["CreatedDate"]),
                                CreatedBy = Convert.ToInt32(dataRow["CreatedBy"]),
                                ModifiedDate = (dataRow["ModifiedDate"] == DBNull.Value || dataRow["ModifiedDate"] == null) ? (DateTime?)null : Convert.ToDateTime(dataRow["ModifiedDate"]),
                                ModifiedBy = Convert.ToInt32((dataRow["ModifiedBy"] != DBNull.Value || dataRow["ModifiedBy"] != null) ? 0 : dataRow["ModifiedBy"]),
                                IsActive = Convert.ToBoolean((dataRow["IsActive"] == DBNull.Value || dataRow["IsActive"] == null) ? 0 : dataRow["IsActive"])
                            });
                    }
                }

                //assign fecthed list
                assessorResponse.Assessor = listAssessors;
                assessorResponse.OperationStatus = new OperationStatus { ServiceName = "GetAssessors", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                assessorResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "Assessor", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return assessorResponse;
        }

        #endregion

        #region Comment : Here POST/INSERT Methods.

        OperationStatus IAssessorDemographicDbService.AddAssessor(Assessor data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorDemographicDetails(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "AddAssessor";
                    operationStatus.ServiceMethod = "POST";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "Assessor", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "Assessor", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here PUT/UPDATE Methods.

        OperationStatus IAssessorDemographicDbService.UpdateAssessor(Assessor data)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };

            #region Comment : Here Iterate all request for mapping

            try
            {
                #region Supply data object for DB insertion

                //Comment : Here record id which is being effected at db level
                Int64 effectedRecordId = SubmitAssessorDemographicDetails(data);

                //if successfully executed
                if (effectedRecordId > 0)
                {
                    //Comment : Here if data has been "successfully submitted" then capture those details
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "UpdateAssessor";
                    operationStatus.ServiceMethod = "PUT";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "Assessor", DTOProperty = "AssessorId", IdValue = effectedRecordId.ToString(), OperationType = OperationType.POST });
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
                operationStatus.Messages.Add(new Message() { DTOName = "Assessor", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message });
            }

            #endregion            

            return operationStatus;
        }

        #endregion

        #region Comment : Here DELETE/REMOVE Methods.

        OperationStatus IAssessorDemographicDbService.RemoveAssessor(int assessorId)
        {
            OperationStatus operationStatus = new OperationStatus() { RequestProcessed = false, RequestSuccessful = false };
            try
            {

                var rowEffeted = GetDbConnector().ExecuteNonQuery("RemoveAssessor", QueryCommandType.StoredProcedure,
                                    new List<IDbDataParameter>
                                    {
                                        new SqlParameter() { ParameterName = "@AssessorId", Value = assessorId
                                        ,SqlDbType = SqlDbType.Int }
                                    });

                //if successfully executed
                if (rowEffeted > 0)
                {
                    operationStatus.RequestProcessed = true;
                    operationStatus.RequestSuccessful = true;
                    operationStatus.ServiceName = "RemoveAssessor";
                    operationStatus.ServiceMethod = "DELETE";
                    operationStatus.AffectedIds.Add(new AffectedId() { DTOName = "Assessor", DTOProperty = "AssessorId", IdValue = assessorId.ToString(), OperationType = OperationType.DELETE });
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

        #region Comment : Here Custom Methods

        /// <summary>
        /// Return list of Assessor details based on supplied Search-Parameters
        /// </summary>
        /// <returns></returns>
        AssessorResponse IAssessorDemographicDbService.SearchAssessors(SearchAssessorRequestParams request)
        {
            AssessorResponse assessorResponse = new AssessorResponse();

            try
            {
                var dbSet = GetDbConnector().LoadDataSet("SearchAssessor", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                //new SqlParameter() { ParameterName = "@BatchId", Value = request.BatchId, SqlDbType = SqlDbType.VarChar, Size=10 },
                                                //new SqlParameter() { ParameterName = "@BatchName", Value = request.BatchName, SqlDbType = SqlDbType.VarChar, Size=100 },
                                                //new SqlParameter() { ParameterName = "@SchemeId", Value = request.SchemeId, SqlDbType = SqlDbType.Int },
                                                //new SqlParameter() { ParameterName = "@JobRoleId", Value = request.JobRoleId, SqlDbType = SqlDbType.Int },
                                                //new SqlParameter() { ParameterName = "@CityId", Value = request.CityId, SqlDbType = SqlDbType.Int },
                                                //new SqlParameter() { ParameterName = "@VTP_Id", Value = request.VTP_Id, SqlDbType = SqlDbType.Int },
                                            });

                //Comment : Here fill & return generic list from DbSet
                var listAssessors = new List<Assessor>();
                if (dbSet != null && dbSet.Tables.Count > 0)
                {
                    foreach (DataRow dataRow in dbSet.Tables[0].Rows)
                    {
                        listAssessors.Add(
                            new Assessor()
                            {
                                Id = Convert.ToInt64(dataRow["AssessorId"]),
                                IRIS_Id = dataRow["IRIS_Id"].ToString(),
                                NSDC_Id = dataRow["NSDC_Id"].ToString(),
                                SSC_Id = dataRow["SSC_Id"].ToString(),

                                #region Comment: Here data for dependent child data like Personal, JobRoles, PrefLocation etc

                                PerosnalDetail = new AssessorPersonalDetail()
                                {
                                    //refrence key data
                                    AssessorId = Convert.ToInt32(dataRow["AssessorId"]),
                                    //SchemeName = dataRow["SchemeName"].ToString(),
                                    //JobRoleName = dataRow["JobRoleName"].ToString(),
                                    //CityName = dataRow["CityName"].ToString(),
                                    //VTP_Name = dataRow["VTP_Name"].ToString(),
                                    //TotalCandidates = Convert.ToInt32(dataRow["TotalCandidates"]),
                                },

                                CommunicationDetail = new AssessorCommunicationDetail()
                                {
                                    //refrence key data
                                    AssessorId = Convert.ToInt32(dataRow["AssessorId"]),
                                    //SchemeName = dataRow["SchemeName"].ToString(),
                                    //JobRoleName = dataRow["JobRoleName"].ToString(),
                                    //CityName = dataRow["CityName"].ToString(),
                                    //VTP_Name = dataRow["VTP_Name"].ToString(),
                                    //TotalCandidates = Convert.ToInt32(dataRow["TotalCandidates"]),
                                },

                                //IdProofs = new AssessorIdProofDetail()
                                //{
                                //    //refrence key data
                                //    AssessorId = Convert.ToInt32(dataRow["AssessorId"]),
                                //    //SchemeName = dataRow["SchemeName"].ToString(),
                                //    //JobRoleName = dataRow["JobRoleName"].ToString(),
                                //    //CityName = dataRow["CityName"].ToString(),
                                //    //VTP_Name = dataRow["VTP_Name"].ToString(),
                                //    //TotalCandidates = Convert.ToInt32(dataRow["TotalCandidates"]),
                                //},

                                //JobRoles = new AssessorJobRole()
                                //{
                                //    //refrence key data
                                //    AssessorId = Convert.ToInt32(dataRow["AssessorId"]),
                                //    //SchemeName = dataRow["SchemeName"].ToString(),
                                //    //JobRoleName = dataRow["JobRoleName"].ToString(),
                                //    //CityName = dataRow["CityName"].ToString(),
                                //    //VTP_Name = dataRow["VTP_Name"].ToString(),
                                //    //TotalCandidates = Convert.ToInt32(dataRow["TotalCandidates"]),
                                //},

                                //PreferredLocations = new AssessorPreferredLocation()
                                //{
                                //    //refrence key data
                                //    AssessorId = Convert.ToInt32(dataRow["AssessorId"]),
                                //    //SchemeName = dataRow["SchemeName"].ToString(),
                                //    //JobRoleName = dataRow["JobRoleName"].ToString(),
                                //    //CityName = dataRow["CityName"].ToString(),
                                //    //VTP_Name = dataRow["VTP_Name"].ToString(),
                                //    //TotalCandidates = Convert.ToInt32(dataRow["TotalCandidates"]),
                                //},

                                #endregion                                

                                IsActive = Convert.ToBoolean((dataRow["IsActive"] == DBNull.Value || dataRow["IsActive"] == null) ? 0 : dataRow["IsActive"])
                            });
                    }
                }

                //assign fecthed list
                assessorResponse.Assessor = listAssessors;
                assessorResponse.OperationStatus = new OperationStatus { ServiceName = "SearchAssessor", ServiceMethod = "Get", RequestProcessed = true, RequestSuccessful = true };
            }
            catch (Exception ex)
            {
                assessorResponse.OperationStatus = new OperationStatus { Messages = new List<Message>() { new Message() { DTOName = "Assessor", DTOProperty = "", MessageType = MessageType.SystemError, Text = ex.Message } }, RequestProcessed = true, RequestSuccessful = false };

            }

            return assessorResponse;
        }

        #endregion

        #endregion

        #region Private Methods

        private Int64 SubmitAssessorDemographicDetails(Assessor data)
        {
            var parameterList = new List<System.Data.IDbDataParameter>
                                {                                   
                                   //Assessor-Master related data
                                   new SqlParameter() { ParameterName = "@Id", Value = data.Id, SqlDbType = SqlDbType.BigInt },
                                   new SqlParameter() { ParameterName = "@IRIS_Id", Value = data.IRIS_Id, SqlDbType = SqlDbType.VarChar, Size=30 },
                                   new SqlParameter() { ParameterName = "@SSC_Id", Value = data.SSC_Id, SqlDbType = SqlDbType.VarChar, Size=20 },
                                   new SqlParameter() { ParameterName = "@NSDC_Id", Value = data.NSDC_Id, SqlDbType = SqlDbType.VarChar, Size=20 },

                                   //5S Params
                                   new SqlParameter() { ParameterName = "@CreatedBy", Value = data.CreatedBy, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@ModifiedBy", Value = data.ModifiedBy, SqlDbType = SqlDbType.Int },
                                   new SqlParameter() { ParameterName = "@IsActive", Value = data.IsActive, SqlDbType = SqlDbType.Bit },

                                   new SqlParameter() { ParameterName = "AssessorId", SqlDbType = SqlDbType.BigInt, Direction = ParameterDirection.ReturnValue }
                                };

            //Comment : Here get DbConnector object
            var rowEffeted = GetDbConnector().ExecuteNonQuery("MaintainAssessors", QueryCommandType.StoredProcedure, parameterList);

            //if successfully executed
            if (rowEffeted > 0)
            {
                Int64 assessorId = Convert.ToInt64(parameterList[parameterList.Count() - 1].Value);
                return assessorId;
            }
            else
            {
                //LoggingService.Instance.Fatal(string.Format("Unable to add user :{0}{1}", Environment.NewLine, object));
            }

            return 0;
        }

        private List<AssessorIdProofDetail> GetAssessorIdProodDetails(Int64 assessorId, DataTable data)
        {
            var listofIdProodDetails = new List<AssessorIdProofDetail>();

            //if have some data
            if (data != null)
            {
                #region Comment : Here if "IdProofs" Table consists related records with supplied "AssessorId" then only iterate respective records

                var dataRows = data.Select(string.Format("AssessorId={0}", assessorId));//, "Id ASC");
                if (dataRows.Length > 0)
                {
                    foreach (DataRow dataRow in dataRows)
                    {
                        listofIdProodDetails.Add(
                                new AssessorIdProofDetail()
                                {
                                    Id = Convert.ToInt64(dataRow["Id"]),
                                    AssessorId = Convert.ToInt64(dataRow["AssessorId"]),
                                    IdProofTypeId = Convert.ToInt16(dataRow["IdProofTypeId"].ToString()),

                                    IdProofName = dataRow["IdProofName"].ToString(),
                                    DocumentFileName = dataRow["DocumentFileName"].ToString(),
                                    UniqueNumber = dataRow["UniqueNumber"].ToString(),
                                    NameOnDocument = dataRow["NameOnDocument"].ToString(),

                                    IsActive = Convert.ToBoolean((dataRow["IsActive"] == DBNull.Value || dataRow["IsActive"] == null) ? 0 : dataRow["IsActive"])
                                }
                            );
                    }
                }

                #endregion                                
            }

            return listofIdProodDetails;
        }

        #endregion
    }
}