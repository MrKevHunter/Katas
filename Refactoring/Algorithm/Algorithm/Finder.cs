using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
	public class Finder
	{
		private readonly List<Person> _people;

		private readonly Dictionary<FindThe, Func<List<Result>, Result>> _lookup = new Dictionary
			<FindThe, Func<List<Result>, Result>>
		                                                                          	{
		                                                                          		{FindThe.Closest, FindClosest},
		                                                                          		{FindThe.Furthest, FindFurthest}
		                                                                          	};


		public Finder(List<Person> people)
		{
			_people = people;
		}

		public Result Find(FindThe findThe)
		{
			var results = GetListOfPeopleWithBirthDateDifference();

			if (results.Count < 1)
			{
				return new Result();
			}

			return _lookup[findThe](results);
		}

		private static Result FindClosest(List<Result> results)
		{
			return results.First(x => x.BirthDateDifference == results.Min(y => y.BirthDateDifference));
		}

		private static Result FindFurthest(List<Result> results)
		{
			return results.First(x => x.BirthDateDifference == results.Max(y => y.BirthDateDifference));
		}

		private List<Result> GetListOfPeopleWithBirthDateDifference()
		{
			var results = new List<Result>();

			foreach (var person in _people)
			{
				foreach (Person otherPerson in _people.Except(new List<Person> {person}))
				{
					var result = new Result();
					result.Add(person);
					result.Add(otherPerson);
					result.BirthDateDifference = result.Person2.BirthDate - result.Person1.BirthDate;
					result.BirthDateDifference = new TimeSpan(Math.Abs(result.BirthDateDifference.Ticks));
					results.Add(result);
				}
			}

			return results;
		}
	}
}