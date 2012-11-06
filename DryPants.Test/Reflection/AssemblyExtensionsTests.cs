using DryPants.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;

namespace DryPants.Test.Reflection
{
    public class AssemblyExtensionsTests
    {
        [TestClass]
        public class GetInstantiableTypesTests
        {
            [TestMethod]
            public void SearchForPublicNonAbstractClass_TypeFoundInResult()
            {
                Assert.IsTrue(Assembly.GetExecutingAssembly().GetInstantiableTypes().Any(type => type == typeof(PublicClassFake)));
            }
            
            [TestMethod]
            public void SearchForPublicStruct_TypeFoundInResult()
            {
                Assert.IsTrue(Assembly.GetExecutingAssembly().GetInstantiableTypes().Any(type => type == typeof(PublicStructFake)));
            }

            [TestMethod]
            public void SearchForPublicInterface_TypeNotFoundInResult()
            {
                Assert.IsFalse(Assembly.GetExecutingAssembly().GetInstantiableTypes().Any(type => type == typeof(IPublicInterfaceFake)));
            }
            
            [TestMethod]
            public void SearchForPublicAbstractClass_TypeNotFoundInResult()
            {
                Assert.IsFalse(Assembly.GetExecutingAssembly().GetInstantiableTypes().Any(type => type == typeof(PublicAbstractClassFake)));
            }

            [TestMethod]
            public void SearchForPrivateClass_TypeNotFoundInResult()
            {
                Assert.IsFalse(Assembly.GetExecutingAssembly().GetInstantiableTypes().Any(type => type == typeof(PrivateClassFake)));
            }

            [TestMethod]
            public void SearchForProtectedClass_TypeNotFoundInResult()
            {
                Assert.IsFalse(Assembly.GetExecutingAssembly().GetInstantiableTypes().Any(type => type == typeof(ProtectedClassFake)));
            }

            [TestMethod, ExpectedException(typeof(ArgumentNullException))]
            public void AssemblyNull_ThrowsArgumentNullException()
            {
                ((Assembly) null).GetInstantiableTypes();
            }

            [TestMethod]
            public void AssemblyWithTypeThatExtendsOtherUnavailableType_TypeNotFoundInResultAndExecutionNotTerminated()
            {
                // ReflectionTypeLoadException should NOT terminate program execution.
                var types = Assembly.Load(Resources.FakeLibraryA).GetInstantiableTypes();
                Assert.IsFalse(types.Any(type => type.FullName == "FakeLibraryA.FakeClassAThatExtendsFakeClassBInOtherLibrary"));
            }

            [TestMethod]
            public void AssemblyWithTypeThatExtendsOtherUnavailableType_ValidTypeFoundInResult()
            {
                // ReflectionTypeLoadException for "FakeClassAThatExtendsFakeClassBInOtherLibrary" should not affect other types.
                var types = Assembly.Load(Resources.FakeLibraryA).GetInstantiableTypes();
                Assert.IsTrue(types.Any(type => type.FullName == "FakeLibraryA.FakeValidClass"));
            }

            private class PrivateClassFake { }
            protected class ProtectedClassFake { }
        }
    }

    public class PublicClassFake { }
    public struct PublicStructFake { }
    public interface IPublicInterfaceFake { }
    public abstract class PublicAbstractClassFake { }
}
