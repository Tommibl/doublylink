using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace linkedlist
{
    
        internal class DoublyLinkedList<T> : IEnumerable<T>
        {
            private DoublyNode<T> head; // головной/первый элемент
            private DoublyNode<T> tail; // последний/хвостовой элемент
            public int Count;  // количество элементов в списке

            // добавление элемента
            public void Add(T data)
            {
                var node = new DoublyNode<T>(data);

                if (head == null)
                {
                    head = node;
                }
                else
                {
                    tail.Next = node;
                    node.Previous = tail;
                }
                tail = node;
                Count++;
            }

            public void AddAt(T data, int index)
            {
                var node = new DoublyNode<T>(data);
                var current = head;
                if (index == 0)
                {
                    node.Next = current;
                    head = node;
                    if (Count == 0)
                    {
                        tail = head;
                    }
                    else
                    {
                        current.Previous = node;
                    }
                }
                else
                {
                    if (index > 0 && index < Count)
                    {
                        var k = 1;
                        while (k < index)
                        {
                            current = current.Next;
                            k++;
                        }

                        node.Next = current.Next;
                        current.Next = node;
                        node.Previous = current.Next;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Index was out of range. " +
                                                               "Must be non-negative and less than the size of the collection. " +
                                                               "(Parameter 'index')");
                    }
                }
                Count++;
            }

            public void RemoveAt(int index)
            {
                var current = head;
                var k = 0;
                if (index > 0 && index < Count)
                {
                    while (k < index)
                    {
                        current = current.Next;
                        k++;
                    }
                    if (current != null)
                    {
                        // если узел не последний
                        if (current.Next != null)
                        {
                            current.Next.Previous = current.Previous;
                        }
                        else
                        {
                            // если последний, переустанавливаем tail
                            tail = current.Previous;
                        }

                        // если узел не первый
                        if (current.Previous != null)
                        {
                            current.Previous.Next = current.Next;
                        }
                        else
                        {
                            // если первый, переустанавливаем head
                            head = current.Next;
                        }
                        Count--;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index was out of range. " +
                                                           "Must be non-negative and less than the size of the collection. " +
                                                           "(Parameter 'index')");
                }
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                var current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }

            public T this[int i]
            {
                get
                {
                    if (head == null || i >= Count || i < 0)
                    {
                        throw new IndexOutOfRangeException("Index was outside the bounds of the array");
                    }
                    var current = head;
                    if (i == 0)
                    {
                        return current.Data;
                    }
                    var k = 1;
                    while (k <= i)
                    {
                        current = current.Next;
                        k++;
                    }
                    return current.Data;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            public IEnumerator<T> GetEnumerator()
            {
                DoublyNode<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }
    }

