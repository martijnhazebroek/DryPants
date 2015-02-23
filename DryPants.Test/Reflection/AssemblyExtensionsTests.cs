using System;
using System.Linq;
using System.Reflection;
using DryPants.Reflection;
using Xunit;

namespace DryPants.Test.Reflection
{
    public class AssemblyExtensionsTests
    {
        
        public class GetInstantiableTypesTests
        {
            [Fact]
            public void SearchForPublicNonAbstractClass_TypeFoundInResult()
            {
                Assert.True(Assembly.GetExecutingAssembly().GetInstantiableTypes().Any(type => type == typeof (PublicClassFake)));
            }

            [Fact]
            public void SearchForPublicStruct_TypeFoundInResult()
            {
                Assert.True(Assembly.GetExecutingAssembly().GetInstantiableTypes().Any(type => type == typeof (PublicStructFake)));
            }

            [Fact]
            public void SearchForPublicInterface_TypeNotFoundInResult()
            {
                Assert.False(Assembly.GetExecutingAssembly().GetInstantiableTypes().Any(type => type == typeof (IPublicInterfaceFake)));
            }

            [Fact]
            public void SearchForPublicAbstractClass_TypeNotFoundInResult()
            {
                Assert.False(Assembly.GetExecutingAssembly().GetInstantiableTypes().Any(type => type == typeof (PublicAbstractClassFake)));
            }

            [Fact]
            public void SearchForPrivateClass_TypeNotFoundInResult()
            {
                Assert.False(Assembly.GetExecutingAssembly().GetInstantiableTypes().Any(type => type == typeof (PrivateClassFake)));
            }

            [Fact]
            public void SearchForProtectedClass_TypeNotFoundInResult()
            {
                Assert.False(Assembly.GetExecutingAssembly().GetInstantiableTypes().Any(type => type == typeof (ProtectedClassFake)));
            }

            [Fact]
            public void AssemblyNull_ThrowsArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => ((Assembly)null).GetInstantiableTypes());
            }

            [Fact]
            public void AssemblyWithTypeThatExtendsOtherUnavailableType_TypeNotFoundInResultAndExecutionNotTerminated()
            {
                // ReflectionTypeLoadException should NOT terminate program execution.
                Type[] types = Assembly.Load(Resources.FakeLibraryA).GetInstantiableTypes();
                Assert.False(types.Any(type => type.FullName == "FakeLibraryA.FakeClassAThatExtendsFakeClassBInOtherLibrary"));
            }

            [Fact]
            public void AssemblyWithTypeThatExtendsOtherUnavailableType_ValidTypeFoundInResult()
            {
                // ReflectionTypeLoadException for "FakeClassAThatExtendsFakeClassBInOtherLibrary" should not affect other types.
                Type[] types = Assembly.Load(Resources.FakeLibraryA).GetInstantiableTypes();
                Assert.True(types.Any(type => type.FullName == "FakeLibraryA.FakeValidClass"));
            }

            private class PrivateClassFake {}
            
            // ReSharper disable MemberCanBePrivate.Global
            protected class ProtectedClassFake {}
            // ReSharper restore MemberCanBePrivate.Global
        }
    }

    public class PublicClassFake {}

    public struct PublicStructFake {}

    public interface IPublicInterfaceFake {}

    public abstract class PublicAbstractClassFake {}
}