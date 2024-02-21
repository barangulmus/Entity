using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace WindowsFormsApp1
{
    public class veritabanibaglan:DbContext
    {
        public veritabanibaglan(): base("baglan")
        {

        }

        public DbSet<MusteriClass> musteris{ get; set; }
    }
   
}
