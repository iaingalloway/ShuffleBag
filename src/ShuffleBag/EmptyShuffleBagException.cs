namespace ShuffleBag
{
    using System;

    /// <summary>
    /// The exception that is thrown when a shuffle bag is created with an
    /// empty source collection.
    /// </summary>
    public sealed class EmptyShuffleBagException : InvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyShuffleBagException" />
        /// class.
        /// </summary>
        public EmptyShuffleBagException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyShuffleBagException" />
        /// class with a specified error message.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        public EmptyShuffleBagException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyShuffleBagException" />
        /// class with a specified error message and a reference to the inner exception
        /// that
        /// is the cause of this exception.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        /// <param name="innerException">
        /// The exception that is the cause of the current exception.
        /// </param>
        public EmptyShuffleBagException(
            string message,
            Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
