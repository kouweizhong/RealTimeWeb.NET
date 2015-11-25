﻿using System;
using Soloco.RealTimeWeb.Common.Infrastructure.DryIoc;

namespace Soloco.RealTimeWeb.Common.Tests
{
    public static class TestContainer
    {
        private static IContainer _container;

        public static void Initialize(Action<IContainer> initializer = null)
        {
            if (_container != null) throw new InvalidOperationException("Initialize already called");

            _container = ContainerFactory.Create(initializer);
        }

        public static T Resolve<T>()
        {
            if (_container == null) throw new InvalidOperationException("First call Initialize from a SetUpFixture class");

            return _container.Resolve<T>();
        }

        public static void Dispose()
        {
            if (_container == null) throw new InvalidOperationException("First call Initialize from a SetUpFixture class");

            _container.Dispose();
        }
    }
}