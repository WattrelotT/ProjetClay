using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayData
{
    public class DataAcess
    {
        private List<Data> GetAllData()
        {
            ClayEntities MaClayEntities = new ClayEntities();
            return MaClayEntities.Data.ToList();
        }

        private List<Data> GetDataByDate(DateTime DateTest)
        {
            ClayEntities MaClayEntities = new ClayEntities();
            List<Data> ListData = new List<Data>();
            foreach (var a in MaClayEntities.Data)
            {
                if (a.date == DateTest)
                {
                    ListData.Add(a);
                }
            }

            return ListData;
        }
    }
}
