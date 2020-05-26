﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        Preparing,
        Submitted,
        Approved,
        Rejected
    }
    public class Experiment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int ExperimentID { get; set; }

        [Required] public DateTime DateOfSubmission { get; set; }
        [Required] public EvaluationStatus EvaluationStatus { get; set; }
        [Required, ForeignKey("Author")] public int AuthorId { get; set; }
        [JsonIgnore] public virtual Person Author { get; set; }


        [Required] public String Title { get; set; }
        [Required] public ActivityType TOA { get; set; }
        [Required] public String Aim { get; set; }
        [Required] public String Objective { get; set; }
        [Required] public String Summary { get; set; }
        //is this a image? it would be ideal to store image in a seperate place and use filepath or url to access it
        [Required] public String ModuleDrawing { get; set; }
        [Required] public ExperimentStatus Status { get; set; }
        [Required] public DateTime ExperimentDate { get; set; }
        [Required] public String FeildOfResearch { get; set; }
        [Required] public String SocialEconomicObjective { get; set; }
        [Required, ForeignKey("LeadIstitution")] public String LeadInstitutionID { get; set; }
        [Required, ForeignKey("Mission")] public int MissionID { get; set; }
        [JsonIgnore] public virtual Institution LeadIstitution { get; set; }
        [JsonIgnore] public virtual ICollection<Participation> Participants { get; set; }
        [JsonIgnore] public virtual Mission Mission { get; set; }
        [JsonIgnore] public virtual ICollection<ResultDataset> Datasets { get; set; }

    }
}
