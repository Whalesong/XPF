#region License
/* The MIT License
 *
 * Copyright (c) 2011 Red Badger Consulting
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
*/
#endregion

using System;

namespace RedBadger.Xpf
{
    public abstract class RefEnum : IEquatable<RefEnum>
    {
        public bool Equals(RefEnum other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(_txt, other._txt) && _id == other._id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RefEnum) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_txt != null ? _txt.GetHashCode() : 0)*397) ^ _id;
            }
        }

        public static bool operator ==(RefEnum left, RefEnum right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(RefEnum left, RefEnum right)
        {
            return !Equals(left, right);
        }

        private readonly string _txt;
        private readonly int _id;

        public override string ToString(){ return _txt; }

        protected RefEnum(string txt, int id)
        {
            _txt = txt;
            _id = id;
        }
    }

    public class VerticalAlignment:RefEnum
    {
        private VerticalAlignment(string txt, int id):base(txt,id)
        {}

        public static VerticalAlignment Stretch{get{return new VerticalAlignment("Stretch",1);}}
        public static VerticalAlignment Top { get { return new VerticalAlignment("Top", 2);}}
        public static VerticalAlignment Center { get { return new VerticalAlignment("Center", 4);}}
        public static VerticalAlignment Bottom { get { return new VerticalAlignment("Bottom", 8);}}

    }
    //public enum VerticalAlignment
    //{
    //    Stretch, 
    //    Top, 
    //    Center, 
    //    Bottom
    //}
}
