using System.Collections.Generic;

namespace LinkedListLib
{
    public class Node<T> : INode<T>
    {
        public T Content { get; set; }
        public INode<T> Next { get; set; }

        public Node(T content) 
        {
            this.Content = content;
            Next = null;
        }
    }
    public class LinkedList<T> : ILinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int Count { get; private set; }
        public INode<T> Head => head;
        public INode<T> Tail => tail;
        public IEnumerable<INode<T>> Nodes
        {
            get
            {
                Node<T>? current = head;
                while(current != null)
                {
                    yield return current;
                    current = (Node<T>)current.Next;
                }
            }
        }
        public LinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void AddFirst(INode<T> value)
        {
            Node<T> newNode = (Node<T>)value;
            newNode.Next = head;
            head = newNode;
            if (tail == null)
            {
                tail = newNode;
            }
            Count++;
        }

        public void InsertAfterNodeIndex(INode<T> value, int position)
        {
            if (position < 0 || position >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            if (position == Count - 1)
            {
                AddLast(value);
                return;
            }

            Node<T> newNode = (Node<T>)value;
            Node<T>? current = head;
            int index = 0;

            while (index < position && current != null)
            {
                current = (Node<T>)current.Next;
                index++;
            }

            newNode.Next = current?.Next;
            current.Next = newNode;
            Count++;
        }

        public void AddLast(INode<T> value)
        {
            Node<T> newNode = (Node<T>)value;
            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            Count++;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void RemoveFirst()
        {
            if (head == null || Count == 0)
            {
                throw new InvalidOperationException();
            }

            head = (Node<T>)head.Next;
            if (head == null)
            {
                tail = null;
            }
            Count--;
        }

        public void RemoveAt(int position)
        {
            if (position < 0 || position >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            if (position == 0)
            {
                RemoveFirst();
            }
            else
            {
                Node<T>? current = head;
                for (int i = 0; i < position - 1; i++)
                {
                    current = (Node<T>?)(current?.Next);
                }
                if (current != null && current.Next != null)
                {
                    current.Next = current.Next;
                    Count--;
                }
            }
        }
        public void RemoveLast()
        {
            if (tail == null)
            {
                return;
            }

            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                Node<T>? current = head;
                while (current?.Next != tail)
                {
                    current = (Node<T>?)(current?.Next);
                }
                tail = current;
                if (tail != null)
                {
                    tail.Next = null;
                }
            }
            Count--;
        }

        public INode<T>? FindFirst(T value)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Content, value))
                {
                    return current;
                }
                current = (Node<T>)current.Next;
            }
            return null;
        }

        public INode<T>[] FindAll(T value)
        {
            List<INode<T>> foundNodes = new List<INode<T>>();
            Node<T>? current = head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Content, value))
                {
                    foundNodes.Add(current);
                }
                current = (Node<T>)current.Next;
            }
            return foundNodes.ToArray();
        }

        public void RemoveAt()
        {
            throw new NotImplementedException();
        }
    }
}