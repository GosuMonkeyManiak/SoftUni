namespace GenericSwapMethodIntegers
{
    public class Box<T>
    {
        public Box(T element)
        {
            this.element = element;
        }

        public T element { get; set; }


        public override string ToString()
        {
            return $"{this.element.GetType()}: {this.element}";
        }
    }
}
