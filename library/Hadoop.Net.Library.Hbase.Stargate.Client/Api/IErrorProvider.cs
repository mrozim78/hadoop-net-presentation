﻿#region FreeBSD

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
using Hadoop.Net.Library.HBase.Stargate.Client.Models;
using RestSharp;

namespace Hadoop.Net.Library.HBase.Stargate.Client.Api
{
	/// <summary>
	///    Defines a provider for <see cref="Exception" /> instances based on <see cref="IRestResponse" /> instances.
	/// </summary>
	public interface IErrorProvider
	{
		/// <summary>
		///    Creates an exception from the response.
		/// </summary>
		/// <param name="response">The response.</param>
		Exception CreateFromResponse(IRestResponse response);

		/// <summary>
		///    Throws an exception from the response.
		/// </summary>
		/// <param name="response">The response.</param>
		void ThrowFromResponse(IRestResponse response);

		/// <summary>
		///    Throws an exception if the schema is invalid.
		/// </summary>
		/// <param name="tableSchema">The table schema.</param>
		void ThrowIfSchemaInvalid(TableSchema tableSchema);
	}
}