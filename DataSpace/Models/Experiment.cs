using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DataSpace.Models
{
    public enum ActivityType
    {
        Pure_basic_Research,
        Strategic_basic_research,
        Applied_research,
        Experimental_development
    }
    public enum ExperimentStatus
    {//dummy status
        Preparing,
        Exicuting,
        Finished
    }
    public enum EvaluationStatus
    {//dummy status
        Submitted,
        Approved,
        Rejected
    }
    public class Experiment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int ExperimentID { get; set; }
        [Required] public DateTime DateOfSubmission { get; set; }
        [Required] public String Title { get; set; }
        [Required] public ActivityType TOA { get; set; }
        [Required] public String Aim { get; set; }
        [Required] public String Objective { get; set; }
        [Required] public String Summary { get; set; }
        //is this a image? it would be ideal to store image in a seperate place and use filepath or url to access it
        [Required] public String ModuleDrawing { get; set; }
        [Required] public ExperimentStatus Status { get; set; }
        [Required] public EvaluationStatus EvaluationStatus { get; set; }
        [Required] public DateTime ExperimentDate { get; set; }
        [Required] public String FeildOfResearch { get; set; }
        [Required] public String SocialEconomicObjective { get; set; }
        [Required, ForeignKey("LeadIstitution")] public String LeadInstitutionID { get; set; }
        [Required, ForeignKey("Mission")] public int MissionID { get; set; }
        public virtual Institution LeadIstitution { get; set; }
        public virtual ICollection<Participation> Participants { get; set; }
        public virtual Mission Mission { get; set; }
        public virtual ICollection<ResultDataset> Datasets { get; set; }

        public Experiment Strip(int layer=0)
        {
            Experiment ret = new Experiment
            {
                ExperimentID = this.ExperimentID,
                DateOfSubmission = this.DateOfSubmission,
                Title = this.Title,
                TOA = TOA,
                Aim = Aim,
                Objective = Objective,
                Summary = Summary,
                ModuleDrawing = ModuleDrawing,
                Status = Status,
                EvaluationStatus = EvaluationStatus,
                ExperimentDate = ExperimentDate,
                FeildOfResearch = FeildOfResearch,
                SocialEconomicObjective = SocialEconomicObjective,
                LeadInstitutionID = LeadInstitutionID,
                MissionID = MissionID,
                LeadIstitution = null,
                Participants = null,
                Mission = null,
                Datasets = null

            };
            if (layer > 0)
            {
                ret.Mission = (Mission)this.Mission.Strip(layer - 1);
                ret.LeadIstitution = (Institution)this.LeadIstitution.Strip(layer - 1);

                ret.Participants = new List<Participation>();
                foreach (Participation p in this.Participants)
                {
                    ret.Participants.Add((Participation)p.Strip(layer - 1));
                }
                ret.Datasets = new List<ResultDataset>();
                foreach (ResultDataset p in this.Datasets)
                {
                    ret.Datasets.Add((ResultDataset)p.Strip(layer - 1));
                }
            }
            return ret;
        }
    }
}