namespace ShuffleBag
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    /// <summary>
    /// Extension methods for shuffling sequences.
    /// </summary>
    public static class ShuffleBagExtensions
    {
        /// <summary>
        /// Shuffles the elements of an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of objects in the sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence to shuffle.
        /// </param>
        /// <returns>
        /// A shuffled <see cref="IEnumerable{T}"/> containing the elements
        /// of the original sequence.
        /// </returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var shuffleBag = new FisherYatesShuffleBag<T>(source);
            return shuffleBag.AsEnumerable().Take(shuffleBag.Count);
        }

        /// <summary>
        /// Shuffles the elements of an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of objects in the sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence to shuffle.
        /// </param>
        /// <param name="random">
        /// The <see cref="System.Random" /> to use as a source of randomness.
        /// </param>
        /// <returns>
        /// A shuffled <see cref="IEnumerable{T}"/> containing the elements
        /// of the original sequence.
        /// </returns>
        public static IEnumerable<T> Shuffle<T>(
            this IEnumerable<T> source,
            Random random)
        {
            var shuffleBag = new FisherYatesShuffleBag<T>(source, random);
            return shuffleBag.AsEnumerable().Take(shuffleBag.Count);
        }

        /// <summary>
        /// Shuffles the elements of an <see cref="IEnumerable{T}"/>, repeating
        /// indefinitely.
        /// </summary>
        /// <typeparam name="T">
        /// The type of objects in the sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence to shuffle.
        /// </param>
        /// <returns>
        /// A shuffled <see cref="IEnumerable{T}"/> containing the elements
        /// of the original sequence repeated indefinitely.
        /// </returns>
        public static IEnumerable<T> ShuffleInfinitely<T>(
            this IEnumerable<T> source)
        {
            var shuffleBag = new FisherYatesShuffleBag<T>(source);
            return shuffleBag.AsEnumerable();
        }

        /// <summary>
        /// Shuffles the elements of an <see cref="IEnumerable{T}"/>, repeating
        /// indefinitely.
        /// </summary>
        /// <typeparam name="T">
        /// The type of objects in the sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence to shuffle.
        /// </param>
        /// <param name="random">
        /// The <see cref="System.Random" /> to use as a source of randomness.
        /// </param>
        /// <returns>
        /// A shuffled <see cref="IEnumerable{T}"/> containing the elements
        /// of the original sequence repeated indefinitely.
        /// </returns>
        public static IEnumerable<T> ShuffleInfinitely<T>(
            this IEnumerable<T> source,
            Random random)
        {
            var shuffleBag = new FisherYatesShuffleBag<T>(source, random);
            return shuffleBag.AsEnumerable();
        }

        private static IEnumerable<T> AsEnumerable<T>(
            this FisherYatesShuffleBag<T> source)
        {
            while (true)
            {
                yield return source.Next();
            }
        }
    }
}
