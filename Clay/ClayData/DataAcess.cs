﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClayData
{
    public class DataAcess
    {
        public List<Data> GetAllData()
        {
            ClayEntities MaClayEntities = new ClayEntities();
            return MaClayEntities.Data.ToList();
        }

        public List<Data> GetDataByDate(DateTime DateTest)
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

        public void SetData(List<Data> ListDataInsert)
        {
            ClayEntities MaClayEntities = new ClayEntities();
            List<Data> ListDataCompare = GetAllData();
            if(ListDataCompare.Count == 0)
            {
                foreach (var c in ListDataInsert)
                {
                    MaClayEntities.Data.Add(c);
                }
            }
            foreach(var a in ListDataCompare)
            {
                int i = 0;
                foreach (var b in ListDataInsert)
                {
                   
                    if(a.lot == b.lot)
                    {
                        break;
                    }
                    if (i == ListDataInsert.Count)
                    {
                        MaClayEntities.Data.Add(b);
                    }
                    i++;
                }
            }
            MaClayEntities.SaveChanges();
        }
    }
}
