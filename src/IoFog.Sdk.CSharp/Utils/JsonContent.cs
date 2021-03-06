﻿/*
 *******************************************************************************
 * Copyright (c) 2018 Edgeworx, Inc.
 *
 * This program and the accompanying materials are made available under the
 * terms of the Eclipse Public License v. 2.0 which is available at
 * http://www.eclipse.org/legal/epl-2.0
 *
 * SPDX-License-Identifier: EPL-2.0
 *******************************************************************************
*/

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace IoFog.Sdk.CSharp.Utils
{
    internal class JsonContent : ByteArrayContent
    {
        private const string DefaultMediaType = "text/plain";

        public JsonContent(string content)
            : this(content, null, null)
        {
        }

        public JsonContent(string content, Encoding encoding)
            : this(content, encoding, null)
        {
        }

        public JsonContent(string content, Encoding encoding, string mediaType)
            : base(GetContentByteArray(content, encoding))
        {
            MediaTypeHeaderValue headerValue = new MediaTypeHeaderValue(mediaType ?? DefaultMediaType);
            headerValue.CharSet = null;

            Headers.ContentType = headerValue;
        }

        private static byte[] GetContentByteArray(string content, Encoding encoding)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            return encoding.GetBytes(content);
        }
    }
}
