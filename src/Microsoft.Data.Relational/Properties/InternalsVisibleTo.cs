﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Runtime.CompilerServices;

#if !INTERNALS_INVISIBLE

[assembly: InternalsVisibleTo("Microsoft.Data.Relational.Tests")]

// for Moq

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

#endif