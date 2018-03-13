using AMS.API.DTO;
using AMS.API.DTO.SkillCouncil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.API.Contracts
{
    public interface ISkillCouncilDbService
    {
        /// <summary>
        /// Return list of Job roles defined in sector skill council(SSC)
        /// </summary>
        /// <returns></returns>
        SkillCouncilResponse GetSkillCouncil(SkillCouncilRequestParams request);

        /// <summary>
        /// Create/Add new SkillCouncil of supplied @SkillCouncilTypeId
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus AddSkillCouncil(SkillCouncil data);

        /// <summary>
        /// Remove exisitng SkillCouncil based on @SkillCouncilTypeId and @SkillCouncilId
        /// </summary>
        /// <param name="skillCouncilId"></param>
        /// <param name="jobRoleId"></param>
        /// <returns></returns>
        OperationStatus RemoveSkillCouncil(int councilTypeId, int skillCouncilId);

        /// <summary>
        /// Modify SkillCouncil data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        OperationStatus UpdateSkillCouncil(SkillCouncil data);

        /// <summary>
        /// Return list of Skill councils based on supplied Search-Parameters
        /// </summary>
        /// <returns></returns>
        SkillCouncilResponse SearchSkillCouncils(SearchSkillCouncilsRequestParams request);
    }
}
