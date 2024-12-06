using NUnit.Framework;
using VxmlInterpreter.Core;

namespace VxmlInterpreter.Tests.UnitTests
{
    [TestFixture]
    public class InterpreterTests
    {
        [Test]
        public void Interpreter_InitialState_ShouldBeIdle()
        {
            var interpreter = new Interpreter();
            Assert.IsFalse(interpreter.IsComplete(), "Interpreter should not be complete initially.");
        }

        [Test]
        public void Interpreter_LoadNonExistentDocument_ShouldReturnDocumentNotFound()
        {
            var interpreter = new Interpreter();
            var status = interpreter.LoadDocument("nonexistentfile.vxml");
            Assert.AreEqual(StatusCode.DocumentNotFound, status, "Should return DocumentNotFound for non-existent file");
        }

        [Test]
        public void Interpreter_NoOperations_ShouldRemainIdleOrComplete()
        {
            var interpreter = new Interpreter();
            // Without calling LoadDocument or Run, interpreter should remain Idle and not complete.
            Assert.IsFalse(interpreter.IsComplete(), "Interpreter should not be complete if no document was loaded or run.");
        }
    }
}
