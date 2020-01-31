using System.Collections.Generic;

namespace SumTotal.Template.Connector.Models
{
    /// <summary>
    /// Candidate model
    /// </summary>
    public class Candidate
    {
        /// <summary>
        /// The CandidateId property gets/sets the value of the Candidate Id.
        /// </summary>
        /// <value>Id of the candidate</value>
        public string CandidateId { get; set; }

        /// <summary>
        /// The Email property gets/sets the value of the Email.
        /// </summary>
        /// <value>Email Id of the candidate</value>
        public string Email { get; set; }

        /// <summary>
        /// The DOB property gets/sets the value of the candidate Date of Birth.
        /// </summary>
        /// <value>DoB of the candidate</value>
        public string DOB { get; set; }

        /// <summary>
        /// The Gender property gets/sets the value of the Gender.
        /// </summary>
        /// <value>The candidate's gender.</value>
        public string Gender { get; set; }

        /// <summary>
        /// The PersonNameDetails property gets/sets the value of the Candidate Name's.
        /// </summary>
        /// <value>Naming details of the candidate</value>
        public CandidateName PersonNameDetails { get; set; }

        /// <summary>
        /// The PersonAddresses property gets/sets the value of the Candidate Addresses.
        /// </summary>
        /// <value>Address of the candidate</value>
        public IList<CandidateAddress> PersonAddresses { get; set; }

        /// <summary>
        ///The PersonPhones property gets/sets the value of the Candidate Phones.
        /// </summary>
        /// <value>Contact phone details of the candidate</value>
        public IList<CandidatePhone> PersonPhones{ get; set; }

        /// <summary>
        ///The PersonIdentities property gets/sets the value of the Candidate Identities.
        /// </summary>
        /// <value>Candidate identity related data.</value>
        public IList<CandidateIdentity> PersonIdentities { get; set; }

        /// <summary>
        /// The PersonLicenseDetailsList property gets/sets the value of the Candidate Licenses.
        /// </summary>
        /// <value>list of licenses available for Candidate</value>
        public IList<CandidateLicense> PersonLicenseDetailsList{ get; set; }

        /// <summary>
        /// The PersonEmploymentDetailsList property gets/sets the value of the Candidate Employment.
        /// </summary>
        /// <value>A collection of employment history for the candidate.</value>
        public IList<CandidateEmployment> PersonEmploymentDetailsList { get; set; }

        /// <summary>
        /// The PersonEducationDetailsList property gets/sets the value of the Candidate Education.
        /// </summary>
        /// <value>A collection of education history for the candidate</value>
        public IList<CandidateEducation> PersonEducationDetailsList { get; set; }

        /// <summary>
        /// The PersonReferences property gets/sets the value of the Candidate References.
        /// </summary>
        /// <value>A collection of references for the candidate.</value>
        public IList<CanidateReference> PersonReferences { get; set; }
        
    }

}