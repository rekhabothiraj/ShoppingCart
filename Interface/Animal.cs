namespace Interface
{
   

    public class GenericClass<T>
    {
        private readonly T _className;

        public GenericClass(T className)
        {
            _className = className;
        }

       
    }

    public class Map
    {

        public string GetSound()
        {
            var Cat = new GenericClass<Cat>();

           
        }
    }
}