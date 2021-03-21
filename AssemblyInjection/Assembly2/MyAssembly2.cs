using AssemblyInterface;

namespace Assembly2
{
    public class MyAssembly2 : IMyAssembly
    {
        public string GetValue()
        {
            return "I'm using MyAssembly2";
        }
    }
}
