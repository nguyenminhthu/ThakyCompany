using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThakyCompany.Models
{
    public class Procedure : BaseModel
    {
        public DateTime PostDate { get; set; }

        public bool Actived { get; set; }

        public virtual ProcedureCategory Category { get; set; }
    }
}