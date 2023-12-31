﻿using EventExcercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExcercise
{
    public class NoisyList<T> : List<T>
    {

        private List<T> list;
        public string Name { get; set; }  
        public NoisyList() 
        { 
            this.list = new List<T>();
        }
        public NoisyList(T[] _array)
        {
            list = new List<T>();
        }
        public void Add(T item)  
        {
            list.Add(item);
            if (OnItemAdded != null)
            {
                var arg = new OnItemAddedEventArgs<T>
                {
                    CountBeforeAddition = list.Count - 1,
                    CountAfterAddition = list.Count,
                    ItemAdded = item,
                    InsertionTimestamp = DateTime.Now,
                    ItemPositionInList = list.IndexOf(item)
                };
                OnItemAdded.Invoke(this, arg);
            };
        }
        public void Clear() 
        {
            list.Clear(); 
            if (OnListCleared != null)
            {
                OnListCleared.Invoke(this);
            }
        }
        public bool Contains(T item) { return list.Contains(item); }
        public void Remove(T item0) 
        {
            list.Remove(item0); 
            if(OnItemRemoved != null)
            {
                OnItemRemoved.Invoke(this, (list.Count + 1, list.Count, item0, DateTime.Now));
            }
        }
        public T this[int index] { get => list[index]; set => list[index] = value; }

        public event ItemAddedEventDelegate<T> OnItemAdded;
        public event Action<NoisyList<T>> OnListCleared;
        public event Action<NoisyList<T>,(int CountBeforeRemove, int CountAfterRemove, T? ItemRemoved, DateTime RemoveTimeStamp)> OnItemRemoved;

        }
    }
    public delegate void ItemAddedEventDelegate<T>(NoisyList<T> sender, OnItemAddedEventArgs<T> args);
    public class OnItemAddedEventArgs<T> : EventArgs
    {
        public int CountBeforeAddition { get; set; }
        public int CountAfterAddition { get; set; }
        public T? ItemAdded { get; set; }
        public DateTime InsertionTimestamp { get; set; }
        public int ItemPositionInList { get; set; }
    }
