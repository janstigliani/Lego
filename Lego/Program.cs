using Lego.Logic;
using Lego.Model;

namespace Lego
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new LegoContext();
            //var colorRepo = new LegoRepository<LegoColor>(context);
            //var colors = colorRepo.GetAll();
            //foreach (var color in colors)
            //{
            //    Console.WriteLine($"Id: {color.Id}, Name: {color.Name}, RGB: {color.Rgb}, IsTrans: {color.IsTrans}");
            //}
            //var inventoryRepo = new LegoRepository<LegoInventory>(context);
            //var inventories = inventoryRepo.GetAll();
            //foreach (var inventory in inventories)
            //{
            //    Console.WriteLine($"Inventory Id: {inventory.Id}, Name: {inventory.Version}");
            //}
            var uow = new LegoUnitOfWork(context);


            //var crimsonColor = new LegoColor
            //{
            //    Name = "Crimson",
            //    Rgb = "DC143C",
            //    IsTrans = 'f'
            //};

            //uow.AddLegoColor(crimsonColor);

            //var colors = uow.GetLegoColors();

            //foreach (var col in colors)
            //{
            //    Console.WriteLine($"{col.Id} - {col.Name}");
            //}

            // Example of using a transaction
            //try
            //{
                //uow.BeginTransaction();

                var testColor = new LegoColor
                {
                    Name = "Pippolo",
                    Rgb = "ABCDEF",
                    IsTrans = 't'
                };

                uow.AddLegoColor(testColor, isTransaction: true);
                uow.BeginTransaction();
                uow.Commit();
            foreach (var col in uow.GetLegoColors())
            {
                Console.WriteLine($"{col.Id} - {col.Name} - {col.Rgb} - {col.IsTrans}");
            }

                // Simula un errore per testare il rollback
                //    bool testError = false; // Imposta a true per forzare il rollback
                //    if (testError)
                //        throw new Exception("Errore di test, rollback eseguito.");

                //    uow.Commit();
                //    Console.WriteLine("Transazione completata con successo.");
                //}
                //catch (Exception ex)
                //{
                //    uow.Rollback();
                //    Console.WriteLine($"Transazione annullata: {ex.Message}");
                //}
        }
    }
}
