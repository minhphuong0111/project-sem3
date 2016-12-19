using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aptech.Models.lmp
{
    public class GenerateID
    {
        public string ID { get; set; }

        public void generate(string prefix, string table, string idcolumn)
        {
            using(var dbContxt = new StudentManagementEntities())
            {
                string dbTable ="dbContext."+table+"s";
                string dbColumn = "p."+idcolumn;
                var data = (from p in dbColumn
                            select p).Last();
                string sdata = "data."+idcolumn;
                
            }
        }
    }
}