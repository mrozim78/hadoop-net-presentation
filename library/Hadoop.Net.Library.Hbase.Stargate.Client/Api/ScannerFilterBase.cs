﻿#region FreeBSD

// Copyright (c) 2013, The Tribe
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

using Hadoop.Net.Library.HBase.Stargate.Client.TypeConversion;
using Newtonsoft.Json.Linq;

namespace Hadoop.Net.Library.HBase.Stargate.Client.Api
{
	/// <summary>
	///    Provides base functionality for scanner filters.
	/// </summary>
	public abstract class ScannerFilterBase : IScannerFilter
	{
		private const string _typePropertyName = "type";

		/// <summary>
		/// Converts the filter to its JSON representation.
		/// </summary>
		/// <param name="codec">The codec to use for encoding values.</param>
		public virtual JObject ConvertToJson(ICodec codec)
		{
			var json = new JObject();

			json[_typePropertyName] = new JValue(GetFilterType());

			return json;
		}

		/// <summary>
		/// Gets the type of the filter.
		/// </summary>
		protected virtual string GetFilterType()
		{
			return GetType().Name;
		}
	}
}