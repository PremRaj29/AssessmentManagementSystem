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
                                    AssessorId = Convert.ToInt32(dataRow["AssessorId"]),
                                    Name = dataRow["AssessorName"].ToString(),
                                    FatherName = dataRow["FatherName"].ToString(),
                                    MotherName = dataRow["MotherName"].ToString(),
                                    //conversion fields
                                    Gender = Convert.ToChar((dataRow["Gender"] == DBNull.Value || dataRow["Gender"] == null) ? null : dataRow["Gender"]),
                                    DOB = ((dataRow["DOB"] == DBNull.Value || dataRow["DOB"] == null) ? (DateTime?)null : Convert.ToDateTime(dataRow["DOB"])),                                    
                                    MaritalStatus = ((dataRow["MaritalStatus"] == DBNull.Value || dataRow["MaritalStatus"] == null) ? (bool?)null : Convert.ToBoolean(dataRow["MaritalStatus"])),
                                },

                                CommunicationDetail = new AssessorCommunicationDetail()
                                {
                                    //refrence key data
                                    AssessorId = Convert.ToInt32(dataRow["AssessorId"]),
                                    EmailId = dataRow["EmailId"].ToString(),
                                    MobileNo = dataRow["MobileNo"].ToString(),                                    
                                    CityId = ((dataRow["CityId"] == DBNull.Value || dataRow["CityId"] == null) ? (int?)null : Convert.ToInt16(dataRow["CityId"])),
                                    CityName = dataRow["CityName"].ToString(),

                                    StateId = ((dataRow["StateId"] == DBNull.Value || dataRow["StateId"] == null) ? (int?)null : Convert.ToInt16(dataRow["StateId"])),
                                    StateName = dataRow["StateName"].ToString(),
                                    OtherLocalityName = dataRow["OtherLocalityName"].ToString(),
                                    WhatsAppOnPrimaryNo = ((dataRow["WhatsAppOnPrimaryNo"] == DBNull.Value || dataRow["WhatsAppOnPrimaryNo"] == null) ? (bool?)null : Convert.ToBoolean(dataRow["WhatsAppOnPrimaryNo"])),
                                    WhatsAppNo = dataRow["WhatsAppNo"].ToString(),
                                    SecondaryEmailId = dataRow["SecondaryEmailId"].ToString(),
                                    SecondaryMobileNo = dataRow["SecondaryMobileNo"].ToString(),
                                    LandlineNo = dataRow["LandlineNo"].ToString(),

                                    EmergancyContactNo1 = dataRow["EmergancyContactNo1"].ToString(),
                                    EmergancyContactNo2 = dataRow["EmergancyContactNo2"].ToString(),
                                    CommAddressLine1 = dataRow["CommAddressLine1"].ToString(),
                                    CommAddressLine2 = dataRow["CommAddressLine2"].ToString(),
                                    CommAddressLine3 = dataRow["CommAddressLine3"].ToString(),
                                    CommAddressPinCode = dataRow["CommAddressPinCode"].ToString(),

                                    HasSameAsCommAddress = ((dataRow["HasSameAsCommAddress"] == DBNull.Value || dataRow["HasSameAsCommAddress"] == null) ? (bool?)null : Convert.ToBoolean(dataRow["HasSameAsCommAddress"])),
                                    PermanentAddressLine1 = dataRow["PermanentAddressLine1"].ToString(),
                                    PermanentAddressLine2 = dataRow["PermanentAddressLine2"].ToString(),
                                    PermanentAddressLine3 = dataRow["PermanentAddressLine3"].ToString(),
                                    PermanentAddressPinCode = dataRow["PermanentAddressPinCode"].ToString(),                                    
                                },

                                OtherDetail = new AssessorOtherDetail()
                                {
                                    //refrence key data
                                    AssessorId = Convert.ToInt64(dataRow["AssessorId"]),
                                    OdigoOkayStatus = dataRow["OdigoOkayStatus"].ToString(),
                                    BankName = dataRow["BankName"].ToString(),
                                    AccountNumber = dataRow["AccountNumber"].ToString(),
                                    IFSC_Code = dataRow["IFSC_Code"].ToString(),
                                    BankAddress = dataRow["BankAddress"].ToString(),
                                    HighestQualificationId = ((dataRow["HighestQualificationId"] == DBNull.Value || dataRow["HighestQualificationId"] == null) ? (int?)null : Convert.ToInt16(dataRow["HighestQualificationId"])),
                                    Qualifications = dataRow["Qualifications"].ToString(),
                                },

                                #region All other related details having mutiple records like JobRoles, PrefLocations will be get from Other DataSet by iteration

                                //get mutiple "IdProofs" details for this/current "Assessor"
                                IdProofs = GetAssessorIdProodDetails(assessorId,dbSet.Tables[1]),

                                //get mutiple "JobRoles" details for this/current "Assessor"
                                JobRoles = GetAssessorJobRoleDetails(assessorId, dbSet.Tables[2]),

                                //get mutiple "PreferredLocations" details for this/current "Assessor"
                                PreferredLocations = GetAssessorPreferredLocationDetails(assessorId, dbSet.Tables[3]),

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
                    //Must set related id to object
                    operationStatus.RecordKey = effectedRecordId;

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

        OperationStatus IAssessorDemographicDbService.RemoveAssessor(Int64 assessorId)
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
                var dbSet = GetDbConnector().LoadDataSet("SearchAssessors", QueryCommandType.StoredProcedure,
                                            new List<System.Data.IDbDataParameter>
                                            {
                                                new SqlParameter() { ParameterName = "@Name", Value = request.Name, SqlDbType = SqlDbType.VarChar, Size=200 },
                                                new SqlParameter() { ParameterName = "@IRIS_Id", Value = request.IRIS_Id, SqlDbType = SqlDbType.VarChar, Size=30 },
                                                new SqlParameter() { ParameterName = "@Gender", Value = request.Gender, SqlDbType = SqlDbType.Char,Size=1 },
                                                new SqlParameter() { ParameterName = "@EmailId", Value = request.EmailId, SqlDbType = SqlDbType.VarChar, Size=150 },
                                                new SqlParameter() { ParameterName = "@MobileNo", Value = request.MobileNo, SqlDbType = SqlDbType.VarChar, Size=10 },
                                                new SqlParameter() { ParameterName = "@StateId", Value = request.StateId, SqlDbType = SqlDbType.Int },
                                                new SqlParameter() { ParameterName = "@CityId", Value = request.CityId, SqlDbType = SqlDbType.Int },

                                                //later will add other search params like "JobRole, IdProofTypeId" etc
                                                new SqlParameter() { ParameterName = "@AccountNumber", Value = request.AccountNumber, SqlDbType = SqlDbType.VarChar, Size=20 },
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
                                    Name = dataRow["AssessorName"].ToString(),
                                    Gender = Convert.ToChar((dataRow["Gender"] == DBNull.Value || dataRow["IsActive"] == null) ? null : dataRow["Gender"]),
                                },

                                CommunicationDetail = new AssessorCommunicationDetail()
                                {
                                    //refrence key data
                                    AssessorId = Convert.ToInt32(dataRow["AssessorId"]),
                                    EmailId = dataRow["EmailId"].ToString(),
                                    MobileNo = dataRow["MobileNo"].ToString(),
                                    CityName = dataRow["CityName"].ToString(),
                                    StateName = dataRow["StateName"].ToString(),
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

        /// <summary>
        /// Method will return List of "IdProofDetails" of Assessor like "PAN, Aadhar, Annexture etc"
        /// </summary>
        /// <param name="assessorId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method will return List of "JobRoles" of Assessor like "Yoga Instructor, Beutician, Health Counseller"
        /// </summary>
        /// <param name="assessorId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private List<AssessorJobRole> GetAssessorJobRoleDetails(Int64 assessorId, DataTable data)
        {
            var listofJobRolesDetails = new List<AssessorJobRole>();

            //if have some data
            if (data != null)
            {
                #region Comment : Here if "JobRoles" Table consists related records with supplied "AssessorId" then only iterate respective records

                var dataRows = data.Select(string.Format("AssessorId={0}", assessorId));//, "Id ASC");
                if (dataRows.Length > 0)
                {
                    foreach (DataRow dataRow in dataRows)
                    {
                        listofJobRolesDetails.Add(
                                new AssessorJobRole()
                                {
                                    Id = Convert.ToInt64(dataRow["Id"]),
                                    AssessorId = Convert.ToInt64(dataRow["AssessorId"]),
                                    
                                    JobRoleName = dataRow["JobRoleName"].ToString(),
                                    JobRoleCode = dataRow["JobRoleCode"].ToString(),
                                    JobRoleId = Convert.ToInt16(dataRow["JobRoleId"].ToString()),
                                    SkillCouncilTypeId = Convert.ToInt16(dataRow["SkillCouncilTypeId"].ToString()),
                                    SkillCouncilId = Convert.ToInt16(dataRow["SkillCouncilId"].ToString()),

                                    ClientStatus = ((dataRow["ClientStatus"] == DBNull.Value || dataRow["ClientStatus"] == null) ? (bool?)null : Convert.ToBoolean(dataRow["ClientStatus"])),
                                    ClientRemarks = dataRow["ClientRemarks"].ToString(),

                                    IsActive = Convert.ToBoolean((dataRow["IsActive"] == DBNull.Value || dataRow["IsActive"] == null) ? 0 : dataRow["IsActive"])
                                }
                            );
                    }
                }

                #endregion                                
            }

            return listofJobRolesDetails;
        }

        /// <summary>
        /// Method will return List of "PreferredLocation" of Assessor like "Jaipr, Bikaner, Jodhpur etc"
        /// </summary>
        /// <param name="assessorId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private List<AssessorPreferredLocation> GetAssessorPreferredLocationDetails(Int64 assessorId, DataTable data)
        {
            var listofPreferredLocationDetails = new List<AssessorPreferredLocation>();

            //if have some data
            if (data != null)
            {
                #region Comment : Here if "PreferredLocation" Table consists related records with supplied "AssessorId" then only iterate respective records

                var dataRows = data.Select(string.Format("AssessorId={0}", assessorId));//, "Id ASC");
                if (dataRows.Length > 0)
                {
                    foreach (DataRow dataRow in dataRows)
                    {
                        listofPreferredLocationDetails.Add(
                                new AssessorPreferredLocation()
                                {
                                    Id = Convert.ToInt64(dataRow["Id"]),
                                    AssessorId = Convert.ToInt64(dataRow["AssessorId"]),

                                    CityName = dataRow["CityName"].ToString(),
                                    CityId = Convert.ToInt16(dataRow["CityId"].ToString()),
                                    StateId = Convert.ToInt16(dataRow["StateId"].ToString()),
                                    StateName = dataRow["StateName"].ToString(),

                                    IsActive = Convert.ToBoolean((dataRow["IsActive"] == DBNull.Value || dataRow["IsActive"] == null) ? 0 : dataRow["IsActive"])
                                }
                            );
                    }
                }

                #endregion                                
            }

            return listofPreferredLocationDetails;
        }

        #endregion
    }
}