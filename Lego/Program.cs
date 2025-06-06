using Lego.Logic;
using Lego.Model;

namespace Lego
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new LegoContext();

            //control test
            //var parts = context.LegoParts.ToList();
            //foreach (var part in parts)
            //{
            //    Console.WriteLine($"Part ID: {part.PartNum}, Name: {part.Name}");
            //} 

            var colorRepo = new Lego_Repository<LegoColor>(context);
            var colors = colorRepo.GetAll();
            foreach (var color in colors)
            {
                Console.WriteLine($"Color ID: {color.Id}, Name: {color.Name}, RGB: {color.Rgb}");
            }

            var inventoryRepo = new Lego_Repository<LegoInventory>(context);
            var inventories = inventoryRepo.GetAll();
            foreach (var invent in inventories)
            {
                Console.WriteLine($"Inventory ID: {invent.Id}, Set Number: {invent.SetNum}, Version: {invent.Version}");
            }
        }
    }
}
