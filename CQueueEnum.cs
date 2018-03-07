using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Generic_Crazy_Queue
{
    public class CQueueEnum<T> : IEnumerator<T>
{
    public List<T> _queue;
    int pos = -1;

    public CQueueEnum(List<T> list)
    {
        _queue = list;
    }

    public T Current
    {
        get
        {
            try
            {
                return _queue[pos];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    object IEnumerator.Current { get { return Current; } }

    public void Dispose() { }

    public bool MoveNext()
    {
        pos++;
        return (pos < _queue.Count);
    }

    public void Reset()
    {
        pos = -1;
    }
}
}
