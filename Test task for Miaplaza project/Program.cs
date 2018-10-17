using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_task_for_Miaplaza_project
{
    class Program
    {
        static void Main(string[] args)
        {
            StoreService storeService = new StoreService();
            while (storeService.ExitProgram == false)
            {
                try
                {
                    storeService.ChooseCommande();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("**{0}**", ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("**{0}**", ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("**{0}**", ex.Message);
                }
                finally
                {
                    Console.WriteLine(new string('_', 10));
                }
            }
        }
    }
}