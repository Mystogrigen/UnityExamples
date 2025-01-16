using System;
using UnityEngine;

namespace UnityExamples
{
    [Serializable]
    public class Storage
    {
        private int _amount;
        private int _capacity;
        private string _title;

        public string title => _title;
        public int amount => _amount;
        public int room => _capacity - _amount;
        public float ratio => _amount / (float)_capacity;

        public Storage(string title, int amount, int capacity)
        {
            _title = title;
            _amount = amount;
            _capacity = capacity;
        }

        public Storage(string title, int capacity)
        {
            _title = title;
            _amount = 0;
            _capacity = capacity;
        }

        public bool Add(int given, out int remainder)
        {
            if (room == 0)
            {
                remainder = given;
                return false;
            }
            else
            {
                if (given <= room)
                {
                    remainder = 0;
                    _amount += given;
                    return true;
                }
                else
                {
                    remainder = given - room;
                    _amount += room;
                    return true;
                }
            }
        }

        public bool Remove(int requested, out int given)
        {
            if (amount == 0)
            {
                given = 0;
                return false;
            }
            else if (amount >= requested)
            {
                given = requested;
                _amount -= requested;
                return true;
            }
            else
            {
                given = amount;
                _amount -= given;
                return true;
            }
        }

        public bool Fill()
        {
            if (room == 0)
                return false;
            else
            {
                _amount = _capacity;
                return true;
            }
        }
    }
}
