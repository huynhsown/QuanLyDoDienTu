using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDoDienTu.entity
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Income { get; set; }

        public Job(int id, string name, long income)
        {
            this.Id = id;
            this.Name = name;
            this.Income = income;
        }
    }
}
