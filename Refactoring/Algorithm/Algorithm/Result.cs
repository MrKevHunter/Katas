using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
	public class Result
	{
		private readonly SortedDictionary<DateTime, Person> _list = new SortedDictionary<DateTime, Person>();

		public Person Person1
		{
			get
			{
				if (_list.Count < 1)
				{
					return null;
				}
				return _list.First().Value;
			}
		}

		public Person Person2
		{
			get
			{
				if (_list.Count < 2)
				{
					return null;
				}
				return _list.ElementAt(1).Value;
			}
		}

		public TimeSpan BirthDateDifference { get; set; }

		public void Add(Person p)
		{
			_list.Add(p.BirthDate, p);
		}
	}
}