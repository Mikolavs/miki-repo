using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAPI.Core.Entities
{
    public class StudentStatistics
    {
        public Student Student { get; set; } 

        public int CommitNr { get; set; }

        public long ModifiedCodeLineNr { get; set; }
    }
}
