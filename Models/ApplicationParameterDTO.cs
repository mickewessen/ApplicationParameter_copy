using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationParameterTest.Models
{
    [DataContract]
    public class ApplicationParameterDTO
    {
        [DataMember]
        public string objectType { get; set; }
        [DataMember]
        public string objectId { get; set; }
        [DataMember]
        public string propertyId { get; set; }
        [DataMember]
        public string indexSpec { get; set; }
        [DataMember]
        public string stringValue { get; set; }
        [DataMember]
        public double? numValue { get; set; }
        [DataMember]
        public string note { get; set; }
        [DataMember]
        public string updateNote { get; set; }
        [DataMember]
        public string updateLocation { get; set; }
        [DataMember]
        public string updateMethod { get; set; }
        [DataMember]
        public string updateReason { get; set; }
        [DataMember]
        public DateTime created { get; set; }
        [DataMember]
        public string createdUser { get; set; }
        [DataMember]
        public string updatedUser { get; set; }
        [DataMember]
        public DateTime updated { get; set; }
        [DataMember]
        public byte[] imageFile  { get; set; }
        [DataMember]
        public string imagefileName { get; set; }
        [DataMember]
        public string imagefileExtension { get; set; }
        [DataMember]
        public byte[] documentFile { get; set; }
        [DataMember]
        public string documentfileName { get; set; }
        [DataMember]
        public string documentfileExtension { get; set; }
        [DataMember]
        public string objectSwedishTitle { get; set; }
        [DataMember]
        public string objectCategory { get; set; }

        public ApplicationParameterDTO()
        {

        }

        public ApplicationParameterDTO(ApplicationParameterDTO param)
        {
            this.objectType = param.objectType;
            this.objectId = param.objectId;
            this.propertyId = param.propertyId;
            this.indexSpec = param.indexSpec;
            this.stringValue = param.stringValue;
            this.numValue = param.numValue;
            this.note = param.note;
            this.updateNote = param.updateNote;
            this.updateLocation = param.updateLocation;
            this.updateMethod = param.updateMethod;
            this.updateReason = param.updateReason;
            this.created = param.created;
            this.createdUser = param.createdUser;
            this.updatedUser = param.updatedUser;
            this.updated = param.updated;
            this.imageFile = param.imageFile;
            this.imagefileName = param.imagefileName;
            this.imagefileExtension = param.imagefileExtension;
            this.documentFile = param.documentFile;
            this.documentfileName = param.documentfileName;
            this.documentfileExtension = param.documentfileExtension;
            this.objectSwedishTitle = param.objectSwedishTitle;
            this.objectCategory = param.objectCategory;
        }
    }


}
