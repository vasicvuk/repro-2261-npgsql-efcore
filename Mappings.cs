using PostgreEFCorePerfTest.Database.Entities;
using PostgreEFCorePerfTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreEFCorePerfTest
{
    public static class Mappings
    {
        public static SampleModel GetView(this SampleEntity entity)
        {
            return new SampleModel
            {
                Data1 = entity.Data1,
                Data2 = entity.Data2,
                Data3 = entity.Data3,
                Data4 = entity.Data4,
                Data5 = entity.Data5,
                Data6 = entity.Data6,
                Data7 = entity.Data7,
                Data8 = entity.Data8,
            };
        }
    }
}
