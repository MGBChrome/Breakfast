using Breakfast.Ingredients;

namespace Breakfast
{
    class Program
    {
        // 1. Gießen Sie eine Tasse Kaffee ein.
        // 2. Erhitzen Sie eine Pfanne und braten Sie zwei Eier.
        // 3. Braten Sie drei Scheiben Speck.
        // 4. Toaste zwei Stücke Brot.
        // 5. Butter und Marmelade auf den Toast geben.
        // 6. Gießen Sie ein Glas Orangensaft ein.

        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task toastTask = MakeToastWithButterAndJamAsync(2);

            Egg eggs = await eggsTask;
            Console.WriteLine("Eggs are ready");
            
            Bacon bacon = await baconTask;
            Console.WriteLine("Bacon is ready");
            
            await toastTask;
            Console.WriteLine("Toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("Oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        private static async Task MakeToastWithButterAndJamAsync(int slices)
        {   
            Toast toast = await ToastBreadAsync(slices);;
            ApplyButter(toast);
            ApplyJam(toast);
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Juice: Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) => 
            Console.WriteLine("Toast: Putting jam on the toast");

        private static void ApplyButter(Toast toast) => 
            Console.WriteLine("Toast: Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Toast: Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Toast: Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Toast: Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"Bacon: putting {slices} slices of bacon in the pan");
            Console.WriteLine("Bacon: cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Bacon: flipping a slice of bacon");
            }
            Console.WriteLine("Bacon: cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Bacon: Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Egg: Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"Egg: cracking {howMany} eggs");
            Console.WriteLine("Egg: cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Egg: Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Coffee: Pouring coffee");
            return new Coffee();
        }
    }
}