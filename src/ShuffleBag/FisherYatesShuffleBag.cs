namespace ShuffleBag
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A basic shuffled collection implementation.
    /// </summary>
    /// <typeparam name="T">
    /// The type of objects to shuffle.
    /// </typeparam>
    public sealed class FisherYatesShuffleBag<T>
    {
        private readonly Random random;

        private readonly T[] source;

        private int cursor;

        /// <summary>
        /// Initializes a new instance of the <see cref="FisherYatesShuffleBag{T}" />
        /// class.
        /// </summary>
        /// <param name="source">
        /// The objects to shuffle.
        /// </param>
        public FisherYatesShuffleBag(IEnumerable<T> source)
            : this(source, new Random())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FisherYatesShuffleBag{T}" />
        /// class.
        /// </summary>
        /// <param name="source">
        /// The objects to shuffle.
        /// </param>
        /// <param name="random">
        /// The <see cref="System.Random" /> to use as a source of randomness.
        /// </param>
        public FisherYatesShuffleBag(IEnumerable<T> source, Random random)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (random == null)
            {
                throw new ArgumentNullException("random");
            }

            this.source = source.ToArray();
            if (this.source.Length == 0)
            {
                throw new EmptyShuffleBagException();
            }

            this.random = random;
        }

        /// <summary>
        /// Gets the next object from the shuffled collection.
        /// </summary>
        /// <returns>
        /// The next object from the shuffled collection.
        /// </returns>
        public T Next()
        {
            if (this.cursor < 1)
            {
                this.Shuffle();
            }

            var index = this.random.Next(this.cursor);
            var next = this.source[index];
            this.source[index] = this.source[this.cursor];
            this.source[this.cursor] = next;

            return next;
        }

        /// <summary>
        /// Shuffles the collection
        /// </summary>
        public void Shuffle()
        {
            this.cursor = this.source.Length - 1;
        }
    }
}
