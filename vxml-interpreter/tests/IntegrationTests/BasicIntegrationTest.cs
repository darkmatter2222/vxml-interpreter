using NUnit.Framework;
using System.IO;
using VxmlInterpreter.Core;

namespace VxmlInterpreter.Tests.IntegrationTests
{
    [TestFixture]
    public class BasicIntegrationTest
    {
        // This test assumes that you have a simple VoiceXML document available at a known path.
        // In a real scenario, we would create a temporary file before the test, or use a resource
        // embedded in the test assembly.
        private string _tempVxmlPath;

        [SetUp]
        public void Setup()
        {
            // Create a temporary VoiceXML file for testing.
            // In a real test, you’d have a minimal, valid VXML document here.
            _tempVxmlPath = Path.GetTempFileName();
            string sampleVxml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                    <vxml version=""2.1"">
                                        <form id=""testForm"">
                                            <prompt>
                                                Welcome to the test form. 
                                                Please say something when prompted.
                                            </prompt>

                                            <field name=""userInput"">
                                                <prompt>Please say your input now.</prompt>
                                                <noinput>
                                                    <prompt>I'm sorry, I didn't hear anything. Please try again.</prompt>
                                                </noinput>
                                                <nomatch>
                                                    <prompt>I didn't understand that. Please try again.</prompt>
                                                </nomatch>
                                            </field>
                                        </form>
                                    </vxml>
                                    ";
            File.WriteAllText(_tempVxmlPath, sampleVxml);
        }

        [TearDown]
        public void Teardown()
        {
            if (File.Exists(_tempVxmlPath))
            {
                File.Delete(_tempVxmlPath);
            }
        }

        [Test]
        public void Interpreter_LoadAndRunSimpleVxml_ShouldComplete()
        {
            var interpreter = new Interpreter();
            var status = interpreter.LoadDocument(_tempVxmlPath);
            Assert.AreEqual(StatusCode.Success, status, "Loading a simple VXML document should succeed.");

            status = interpreter.Initialize();
            Assert.AreEqual(StatusCode.Success, status, "Initialization should succeed for a simple document.");

            status = interpreter.Run();
            Assert.AreEqual(StatusCode.Success, status, "Running the interpreter on a simple form should complete successfully.");

            Assert.IsTrue(interpreter.IsComplete(), "Interpreter should be complete after running a simple form.");
        }
    }
}
