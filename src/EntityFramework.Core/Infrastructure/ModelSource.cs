// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using JetBrains.Annotations;
using Microsoft.Data.Entity.Metadata;

namespace Microsoft.Data.Entity.Infrastructure
{
    public abstract class ModelSource
    {
        public abstract IModel GetModel([NotNull] DbContext context, [NotNull] ModelBuilderFactory builder);
    }
}
