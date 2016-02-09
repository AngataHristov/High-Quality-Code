
namespace MyStack
{
    using System;

    public class MyStack<T>
    {
        private const int DefaultCapacity = 16;

        private T[] items;

        public MyStack(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.items = new T[this.Capacity];
            this.Count = 0;
        }

        public int Capacity { get; private set; }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (this.Count == this.Capacity)
            {
                this.Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            this.ValidateNotEmpty();

            var lastItem = this.items[this.Count - 1];
            this.items[this.Count - 1] = default(T);
            this.Count--;

            return lastItem;
        }

        public T Peek()
        {
            this.ValidateNotEmpty();

            return this.items[this.Count - 1];
        }

        private void ValidateNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }

        private void Resize()
        {
            var newArray = new T[this.Capacity * 2];
            Array.Copy(this.items, newArray, this.Count);
            this.items = newArray;
            this.Capacity *= 2;
        }
    }
}
