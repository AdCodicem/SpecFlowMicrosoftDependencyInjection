using BoDi;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Collections.Generic;

namespace AdCodicem.SpecFlow.MicrosoftDependencyInjection.Internal
{
    /// <inheritdoc />
    internal sealed class DelegatableServiceCollection : IDelegatableServiceCollection
    {
        /// <inheritdoc />
        public IObjectContainer DelegateServices { get; }

        private IServiceCollection DefaultServices { get; } = new ServiceCollection();

        public DelegatableServiceCollection(IObjectContainer delegateServices)
        {
            DelegateServices = delegateServices;
        }

        /// <inheritdoc />
        public IEnumerator<ServiceDescriptor> GetEnumerator() => DefaultServices.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)DefaultServices).GetEnumerator();

        /// <inheritdoc />
        public void Add(ServiceDescriptor item) => DefaultServices.Add(item);

        /// <inheritdoc />
        public void Clear() => DefaultServices.Clear();

        /// <inheritdoc />
        public bool Contains(ServiceDescriptor item) => DefaultServices.Contains(item);

        /// <inheritdoc />
        public void CopyTo(ServiceDescriptor[] array, int arrayIndex) => DefaultServices.CopyTo(array, arrayIndex);

        /// <inheritdoc />
        public bool Remove(ServiceDescriptor item) => DefaultServices.Remove(item);

        /// <inheritdoc />
        public int Count => DefaultServices.Count;

        /// <inheritdoc />
        public bool IsReadOnly => DefaultServices.IsReadOnly;

        /// <inheritdoc />
        public int IndexOf(ServiceDescriptor item) => DefaultServices.IndexOf(item);

        /// <inheritdoc />
        public void Insert(int index, ServiceDescriptor item) => DefaultServices.Insert(index, item);

        /// <inheritdoc />
        public void RemoveAt(int index) => DefaultServices.RemoveAt(index);

        /// <inheritdoc />
        public ServiceDescriptor this[int index]
        {
            get => DefaultServices[index];
            set => DefaultServices[index] = value;
        }
    }
}