using System;
using System.Runtime.InteropServices;


namespace call_queue{
    class Program
    {
        private static Guid TypeGuid => Guid.Parse("0957F186-2C36-4D95-925A-E3338DAAFA5E");

        static void Main(string[] args)
        {
            var objectType = Type.GetTypeFromCLSID(TypeGuid)
                ?? throw new ArgumentException($"Сборка с идентификатором {TypeGuid} не обнаружена");
            dynamic @object = Activator.CreateInstance(objectType);


            var rng = new Random();
            for (int i = 0; i < 1000; i++) {
                @object.pushValue(rng.Next(1000), rng.Next(1000));
            }

            for (int i = 0; i < 1000; i++) 
            {
                Console.WriteLine(@object.popValue());
            }
                
        }
    }


}