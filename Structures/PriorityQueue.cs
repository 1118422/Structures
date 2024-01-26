    using System.Collections;

    namespace Structures;

/// <summary>
/// Stores items, along with a priority for each item
/// </summary>
/// <typeparam name="T"></typeparam>
public class PriorityQueue<T>
{
    private LinkedList<PrioritizedItem> queue = new LinkedList<PrioritizedItem>();
    
    public int Count
    { 
        get { return queue.Count; }
    }

    public void Enqueue(T item, int priority)
    {
        queue.Append(new PrioritizedItem(item, priority));
    }

    public T Peek()
    {
        LinkedListNode<PrioritizedItem> chosenNode = queue.First;

        LinkedListNode<PrioritizedItem> queueEnum = queue.First;
        for (int i = 0; i < queue.Count; i ++)
        {
            if (queueEnum.Value.Priority > chosenNode.Value.Priority)
            {
                chosenNode = queueEnum;
            }
            queueEnum = queueEnum.Next;
        }

        return chosenNode.Value.Value;
    }

    public T Dequeue()
    {
        LinkedListNode<PrioritizedItem> chosenNode = queue.First;

        LinkedListNode<PrioritizedItem> queueEnum = queue.First;
        for (int i = 0; i < queue.Count; i ++)
        {
            if (queueEnum.Value.Priority > chosenNode.Value.Priority)
            {
                chosenNode = queueEnum;
            }
            queueEnum = queueEnum.Next;
        }

        queue.Remove(chosenNode);
        return chosenNode.Value.Value;
    }

    public void Clear()
    {
        queue = new LinkedList<PrioritizedItem>();
    }

    // Stores an item and its priority
    private struct PrioritizedItem
    {
        public readonly T Value;
        public readonly int Priority;

        public PrioritizedItem(T value, int priority)
        {
            this.Value = value;
            this.Priority = priority;
        }
    }
}