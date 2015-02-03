// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using JetBrains.Annotations;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Utilities;

namespace Microsoft.Data.Entity.Infrastructure
{
    public class ModelSourceBase : ModelSource
    {
        private readonly ThreadSafeDictionaryCache<Type, IModel> _models = new ThreadSafeDictionaryCache<Type, IModel>();

        private readonly DbSetFinder _setFinder;

        public ModelSourceBase([NotNull] DbSetFinder setFinder)
        {
            Check.NotNull(setFinder, "setFinder");

            _setFinder = setFinder;
        }

        public override IModel GetModel(DbContext context, ModelBuilderFactory modelBuilderFactory)
        {
            Check.NotNull(context, "context");
            Check.NotNull(modelBuilderFactory, "modelBuilderFactory");

            return _models.GetOrAdd(context.GetType(), k => CreateModel(context, modelBuilderFactory));
        }

        protected virtual IModel CreateModel(DbContext context, ModelBuilderFactory modelBuilderFactory)
        {
            var model = new Model();
            var modelBuilder = modelBuilderFactory.CreateConventionBuilder(model);

            FindSets(modelBuilder, context);

            ModelSourceHelpers.OnModelCreating(context, modelBuilder);

            return model;
        }

        protected virtual void FindSets(ModelBuilder modelBuilder, DbContext context)
        {
            foreach (var setInfo in _setFinder.FindSets(context))
            {
                modelBuilder.Entity(setInfo.EntityType);
            }
        }
    }
}
