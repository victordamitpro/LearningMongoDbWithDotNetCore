using System;

namespace Electric.Core.Exeptions
{
    public class ElectricExeption : Exception
    {
        public ElectricExeption()
        { }

        public ElectricExeption(string message)
            : base(message)
        { }

        public ElectricExeption(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

    public class NotFoundExeption : Exception
    {
        public NotFoundExeption()
        { }

        public NotFoundExeption(string message)
            : base(message)
        { }

        public NotFoundExeption(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

    public class ConflictExeption : Exception
    {
        public ConflictExeption()
        { }

        public ConflictExeption(string message)
            : base(message)
        { }

        public ConflictExeption(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
