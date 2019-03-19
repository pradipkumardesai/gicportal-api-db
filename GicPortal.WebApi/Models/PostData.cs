using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GicPortal.WebApi.Models
{
    public class PostData
    {

        public int EmployeeId { get; set; }
        public string EMailId { get; set; }
        public string Name { get; set; }
        public string DeskNo { get; set; }
        public string Designation { get; set; }
        public DateTime CreatedOn { get; set; }

        public override string ToString()
        {
            return string.Empty;//$"PostData with [Id: {this.Id.ToString()}] - [Name: {this.Name}] - [IsTrue: {this.IsTrue.ToString()}] - [CreatedOn: {this.CreatedOn.ToString("dd/MM/yyy")}].";
        }
    }
}