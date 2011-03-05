namespace Gaur
{
	using System;
	using System.Text;
	using C5;
	using SCG = System.Collections.Generic;

	/// <summary>
	/// Generic set
	/// </summary>
	/// <typeparam name="T">Generic type</typeparam>
	public class Set<T> : HashSet<T>
	{
		/// <summary>
		/// Initializes a new instance of the Set class.
		/// </summary>
		/// <param name="enm">Enumerable containing set elements</param>
		public Set(SCG.IEnumerable<T> enm) : base()
		{
			if (enm == null)
			{
				throw new ArgumentNullException("enm");
			}
			else
			{
				this.AddAll(enm);
			}
		}

		/// <summary>
		/// Initializes a new instance of the Set class.
		/// </summary>
		/// <param name="elems">Open array of elements.</param>
		public Set(params T[] elems) : this((SCG.IEnumerable<T>)elems)
		{
			if (elems == null)
			{
				throw new ArgumentNullException("elems");
			}
		}

		/// <summary>
		/// Union operator +.
		/// </summary>
		/// <param name="s1">Generic set s1.</param>
		/// <param name="s2">Generic set s2.</param>
		/// <exception cref="ArgumentNullException"></exception>
		/// <returns>Returns s1 + s2.</returns>
		public static Set<T> operator +(Set<T> s1, Set<T> s2)
		{
			if (s1 == null || s2 == null)
			{
				throw new ArgumentNullException("Set+Set");
			}
			else
			{
				Set<T> res = new Set<T>(s1);
				res.AddAll(s2);
				return res;
			}
		}

		/// <summary>
		/// Difference operator -.
		/// </summary>
		/// <param name="s1">Generic set s1.</param>
		/// <param name="s2">Generic set s2.</param>
		/// <returns>Returns s1 - s2.</returns>
		public static Set<T> operator -(Set<T> s1, Set<T> s2)
		{
			if (s1 == null || s2 == null)
			{
				throw new ArgumentNullException("Set-Set");
			}
			else
			{
				Set<T> res = new Set<T>(s1);
				res.RemoveAll(s2);
				return res;
			}
		}

		/// <summary>
		/// Intersection operator *.
		/// </summary>
		/// <param name="s1">Generic set s1.</param>
		/// <param name="s2">Generic set s2.</param>
		/// <returns>Returns s1 * s2.</returns>
		public static Set<T> operator *(Set<T> s1, Set<T> s2)
		{
			if (s1 == null || s2 == null)
			{
				throw new ArgumentNullException("Set*Set");
			}
			else
			{
				Set<T> res = new Set<T>(s1);
				res.RetainAll(s2);
				return res;
			}
		}

		/// <summary>
		/// Superset operator &lt;=.
		/// </summary>
		/// <param name="s1">Generic set s1.</param>
		/// <param name="s2">Generic set s2.</param>
		/// <returns>Returns true if s1 is superset of s2.</returns>
		public static bool operator >=(Set<T> s1, Set<T> s2)
		{
			if (s1 == null || s2 == null)
			{
				throw new ArgumentNullException("Set>=Set");
			}
			else
			{
				return s1.ContainsAll(s2);
			}
		}

		/// <summary>
		/// Subset operator &gt;=.
		/// </summary>
		/// <param name="s1">Generic set s1.</param>
		/// <param name="s2">Generic set s2.</param>
		/// <returns>Returns true if s1 is subset of s2.</returns>
		public static bool operator <=(Set<T> s1, Set<T> s2)
		{
			if (s1 == null || s2 == null)
			{
				throw new ArgumentNullException("Set<=Set");
			}
			else
			{
				return s2.ContainsAll(s1);
			}
		}

		/// <summary>
		/// Equality operator ==.
		/// </summary>
		/// <param name="s1">Generic set s1.</param>
		/// <param name="s2">Generic set s2.</param>
		/// <returns>True is sets are equal</returns>
		public static bool operator ==(Set<T> s1, Set<T> s2)
		{
			return EqualityComparer<Set<T>>.Default.Equals(s1, s2);
		}

		/// <summary>
		/// Inequality the operator !=.
		/// </summary>
		/// <param name="s1">Generic set s1.</param>
		/// <param name="s2">Generic set s2.</param>
		/// <returns>True if sets are not equal.</returns>
		public static bool operator !=(Set<T> s1, Set<T> s2)
		{
			return !(s1 == s2);
		}

		/// <summary>
		/// Equalses the specified that.
		/// </summary>
		/// <param name="that">Argument object.</param>
		/// <returns>True if two sets are equal, False otherwise</returns>
		public override bool Equals(object that)
		{
			return this == (that as Set<T>);
		}

		/// <summary>
		/// Serves as a hash function for a particular type.
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="T:System.Object"/>.
		/// </returns>
		public override int GetHashCode()
		{
			return EqualityComparer<Set<T>>.Default.GetHashCode(this);
		}

		/// <summary>
		/// Toes the string.
		/// </summary>
		/// <returns>Set converted to string</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("{");
			bool first = true;
			foreach (T x in this)
			{
				if (!first)
				{
					sb.Append(",");
				}

				sb.Append(x);
				first = false;
			}

			sb.Append("}");
			return sb.ToString();
		}
	}

}