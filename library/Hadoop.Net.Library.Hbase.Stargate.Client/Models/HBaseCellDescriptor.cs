#region FreeBSD

// Copyright (c) 2014, The Tribe
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
// 
//  * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// 
//  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the
//    documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
// TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;

namespace Hadoop.Net.Library.HBase.Stargate.Client.Models
{
  /// <summary>
  ///   Describes a cell in HBase.
  /// </summary>
  public class HBaseCellDescriptor : IEquatable<HBaseCellDescriptor>
  {
    /// <summary>
    ///   Gets or sets the column.
    /// </summary>
    public string Column { get; set; }

    /// <summary>
    ///   Gets or sets the qualifier.
    /// </summary>
    public string Qualifier { get; set; }

    /// <summary>
    ///   Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    public bool Equals(HBaseCellDescriptor other)
    {
      return this.CheckedEquals(other,
        (left, right) => left.Column.EqualsString(other.Column)
          && left.Qualifier.EqualsString(other.Qualifier));
    }

    /// <summary>
    ///   Returns a hash code for this instance.
    /// </summary>
    public override int GetHashCode()
    {
      return this.GetMutableHashCode();
    }

    /// <summary>
    ///   Determines whether the specified <see cref="System.Object" />, is equal to this instance.
    /// </summary>
    public override bool Equals(object other)
    {
      return Equals(other as HBaseCellDescriptor);
    }

    /// <summary>
    ///   Implements the operator ==.
    /// </summary>
    public static bool operator ==(HBaseCellDescriptor left, HBaseCellDescriptor right)
    {
      return left.CheckedEquals(right);
    }

    /// <summary>
    ///   Implements the operator !=.
    /// </summary>
    public static bool operator !=(HBaseCellDescriptor left, HBaseCellDescriptor right)
    {
      return !(left == right);
    }
  }
}