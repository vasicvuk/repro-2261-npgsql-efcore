using Microsoft.EntityFrameworkCore;
using PostgreEFCorePerfTest.Database;
using PostgreEFCorePerfTest.Database.Entities;
using PostgreEFCorePerfTest.Model;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PostgreEFCorePerfTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new SampleContext();
            await context.Database.MigrateAsync();
            if (!await context.Samples.AnyAsync())
            {
                for (var i = 0; i < 100; i++)
                {
                    var std = new SampleEntity()
                    {
                        Data1 = "Bill1",
                        Data2 = "Bill2",
                        Data3 = "Bill3",
                        Data4 = "Bill4",
                        Data5 = "Bill5",
                        Data6 = "Bill6",
                        Data7 = "Bill7",
                        Data8 = "Bill8"
                    };
                    await context.Samples.AddAsync(std);
                }
                await context.SaveChangesAsync();

            }
            Console.WriteLine("Writing finished");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < 1000; i++)
            {
                var results = await context.Samples.Skip(0).Take(20).Select(x => Mappings.GetView(x)).ToListAsync();
            }
            Console.WriteLine("Elapsed miliseconds: {0}", sw.Elapsed.TotalMilliseconds);
        }

    }
}
