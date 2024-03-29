﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    public struct KeyValue<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    }
    class MyHashCode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;

        //constructor to initialise
        public MyHashCode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];

        }

        //method to find the position of the hash table (creatind hash code)
        protected int getArrayPosition(K key)
        {
            int hash = key.GetHashCode();
            int position = hash % size;
            return Math.Abs(position);
        }
        //method to get a value stored in perticular key
        public V get(K key)
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;

                }
            }
            return default(V);
        }

        //Add method for insert value in hashtable
        public void Add(K key, V value)
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            //object of keyvalue
            //object initialisation(declaration and intialization at a one time)
            //it does not invoke constructor
            KeyValue<K, V> item = new KeyValue<K, V>() 
            //assign value to key and value
            { Key = key, Value = value };
            if (linkedlist.Count != 0)
            {
                foreach (KeyValue<K, V> item1 in linkedlist)
                {
                    if (item1.Key.Equals(key))
                    {
                        Remove(key);
                        break;
                    }
                }

            }
            linkedlist.AddLast(item);
        }
        //to remove the if already exist
        public void Remove(K key)
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> founditem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    founditem = item;
                }
            }
            if (itemFound)
            {
                linkedlist.Remove(founditem);
            }

        }
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedlist = items[position];
            if (linkedlist == null)
            {
                linkedlist = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedlist;

            }
            return linkedlist;

        }
        

        public bool Exists(K key)
        {
            int position = getArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedlist = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedlist)
            {
                if (item.Key.Equals(key))
                {
                    return true;

                }
            }
            return false;
        }

        public void Display()
        {
            foreach (var linkedlist in items)
            {
                if (linkedlist != null)
                {
                    foreach (var element in linkedlist)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + " = " + element.Value);
                    }

                }

            }

        }

    }
}
