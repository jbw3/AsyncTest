using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncTest
{
    public static class AsyncEnumerableExtensions
    {
        public static async Task<bool> All<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            await foreach (TSource item in source)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static async Task<bool> All<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
        {
            await foreach (TSource item in source)
            {
                if (!await predicate(item))
                {
                    return false;
                }
            }

            return true;
        }

        public static async Task<bool> Any<TSource>(this IAsyncEnumerable<TSource> source)
        {
            await using (IAsyncEnumerator<TSource> enumerator = source.GetAsyncEnumerator())
            {
                return await enumerator.MoveNextAsync();
            }
        }

        public static async Task<bool> Any<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            await foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static async Task<bool> Any<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
        {
            await foreach (TSource item in source)
            {
                if (await predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static async IAsyncEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> source, IAsyncEnumerable<TSource> other)
        {
            foreach (TSource item in source)
            {
                yield return item;
            }

            await foreach (TSource item in other)
            {
                yield return item;
            }
        }
        public static async IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> source, IEnumerable<TSource> other)
        {
            await foreach (TSource item in source)
            {
                yield return item;
            }

            foreach (TSource item in other)
            {
                yield return item;
            }
        }

        public static async IAsyncEnumerable<TSource> Concat<TSource>(this IAsyncEnumerable<TSource> source, IAsyncEnumerable<TSource> other)
        {
            await foreach (TSource item in source)
            {
                yield return item;
            }

            await foreach (TSource item in other)
            {
                yield return item;
            }
        }

        public static async IAsyncEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
        {
            foreach (TSource item in source)
            {
                yield return await selector(item);
            }
        }

        public static async IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            await foreach (TSource item in source)
            {
                yield return selector(item);
            }
        }

        public static async IAsyncEnumerable<TResult> Select<TSource, TResult>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
        {
            await foreach (TSource item in source)
            {
                yield return await selector(item);
            }
        }

        public static async IAsyncEnumerable<TSource> Skip<TSource>(this IAsyncEnumerable<TSource> source, int count)
        {
            await using (IAsyncEnumerator<TSource> enumerator = source.GetAsyncEnumerator())
            {
                int num = 0;
                while (num < count && await enumerator.MoveNextAsync())
                {
                    ++num;
                }

                while (await enumerator.MoveNextAsync())
                {
                    yield return enumerator.Current;
                }
            }
        }

        public static async IAsyncEnumerator<TSource> Take<TSource>(this IAsyncEnumerable<TSource> source, int count)
        {
            await using (IAsyncEnumerator<TSource> enumerator = source.GetAsyncEnumerator())
            {
                int num = 0;
                while (num < count && await enumerator.MoveNextAsync())
                {
                    yield return enumerator.Current;
                    ++num;
                }
            }
        }

        public static async IAsyncEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
        {
            foreach (TSource item in source)
            {
                if (await predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static async IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            await foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static async IAsyncEnumerable<TSource> Where<TSource>(this IAsyncEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
        {
            await foreach (TSource item in source)
            {
                if (await predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
