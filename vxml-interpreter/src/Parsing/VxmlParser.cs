using System;
using System.IO;
using System.Xml;
using VxmlInterpreter.Core;
using VxmlInterpreter.Model;        // Ensure these namespaces match your project structure
using VxmlInterpreter.Model.Dialogs;

namespace VxmlInterpreter.Parsing
{
    public class VxmlParser
    {
        public VxmlParser()
        {
            // Initialize parser-related structures if needed
        }

        /// <summary>
        /// Parse a VoiceXML document from the given URI.
        /// Steps:
        /// - Load the XML.
        /// - Validate that root is <vxml>.
        /// - Parse dialogs (forms, menus).
        /// - Return a fully constructed VxmlDocument.
        /// </summary>
        public StatusCode Parse(string documentUri, out object vxmlDocument)
        {
            vxmlDocument = null;

            if (string.IsNullOrWhiteSpace(documentUri))
            {
                return StatusCode.DocumentNotFound;
            }

            if (!File.Exists(documentUri))
            {
                return StatusCode.DocumentNotFound;
            }

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(documentUri);
            }
            catch
            {
                return StatusCode.ParseError;
            }

            if (xmlDoc.DocumentElement == null || xmlDoc.DocumentElement.Name != "vxml")
            {
                return StatusCode.ValidationError;
            }

            var doc = new VxmlDocument();

            // Parse dialogs inside <vxml>
            var status = ParseDialogs(xmlDoc.DocumentElement, doc);
            if (status != StatusCode.Success)
            {
                return status;
            }

            vxmlDocument = doc;
            return StatusCode.Success;
        }

        /// <summary>
        /// Parse top-level dialogs from the VXML root element.
        /// Looks for <form>, <menu>, and other dialog elements.
        /// </summary>
        private StatusCode ParseDialogs(XmlElement root, VxmlDocument doc)
        {
            foreach (XmlNode node in root.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Element)
                {
                    var elem = (XmlElement)node;
                    switch (elem.Name)
                    {
                        case "form":
                            {
                                var formStatus = ParseForm(elem, doc);
                                if (formStatus != StatusCode.Success)
                                {
                                    return formStatus;
                                }
                                break;
                            }
                        case "menu":
                            {
                                // In the future, implement ParseMenu similarly
                                // var menuStatus = ParseMenu(elem, doc);
                                // if (menuStatus != StatusCode.Success)
                                // {
                                //     return menuStatus;
                                // }
                                break;
                            }
                        // Other top-level elements like <link>, <var>, etc. can be handled here
                        default:
                            // Ignore unknown elements at top-level or handle accordingly
                            break;
                    }
                }
            }

            return StatusCode.Success;
        }

        /// <summary>
        /// Parse a <form> element and add it to the document as a VxmlForm.
        /// This is a minimal implementation. Expand as needed:
        /// - Parse fields (<field>) and add them to the form.
        /// - Parse prompts, event handlers, etc.
        /// </summary>
        private StatusCode ParseForm(XmlElement formElement, VxmlDocument doc)
        {
            var form = new VxmlForm();

            // Extract the 'id' attribute if present
            var idAttr = formElement.GetAttribute("id");
            if (!string.IsNullOrWhiteSpace(idAttr))
            {
                form.Id = idAttr;
            }
            else
            {
                // In VoiceXML, forms usually need an id, but not strictly required by all implementations.
                // If needed, return a validation error or assign a generated id.
                form.Id = "form_" + Guid.NewGuid().ToString("N");
            }

            // Parse form children for fields, prompts, etc.
            // Example: parse a <prompt> or <field> element
            foreach (XmlNode childNode in formElement.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Element)
                {
                    var childElem = (XmlElement)childNode;
                    switch (childElem.Name)
                    {
                        case "prompt":
                            // For now, just note that the form has a prompt
                            // You may want to store this prompt text in the form.
                            // Once you have a prompt model, add it to form items.
                            // Example: form.AddFormItem(new VxmlPrompt(childElem.InnerText));
                            break;

                        case "field":
                            // Parse a field
                            var fieldStatus = ParseField(childElem, form);
                            if (fieldStatus != StatusCode.Success)
                            {
                                return fieldStatus;
                            }
                            break;

                            // Handle other form elements like <block>, <var>, <grammar>, etc.
                    }
                }
            }

            // Add the form to the document
            var addStatus = doc.AddDialog(form);
            return addStatus;
        }

        /// <summary>
        /// Parse a <field> element inside a form.
        /// Extract the name attribute and create a VxmlField object.
        /// Add it to the form.
        /// </summary>
        private StatusCode ParseField(XmlElement fieldElement, VxmlForm form)
        {
            var nameAttr = fieldElement.GetAttribute("name");
            if (string.IsNullOrWhiteSpace(nameAttr))
            {
                // Fields require a name attribute.
                return StatusCode.ValidationError;
            }

            var field = new Model.Elements.VxmlField
            {
                Name = nameAttr
            };

            // Parse prompts, noinput, nomatch inside the field if needed.
            // For now, just handle the simplest case.
            foreach (XmlNode child in fieldElement.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.Element)
                {
                    var elem = (XmlElement)child;
                    if (elem.Name == "prompt")
                    {
                        // Store the prompt text with the field if desired
                        // field.AddPrompt(elem.InnerText) -> if such a method exists
                    }
                    // Also handle <noinput>, <nomatch> similarly by assigning event handlers
                }
            }

            // Add the field to the form
            return form.AddFormItem(field);
        }

        // In the future, add ParseMenu, ParseChoice, and other methods for other dialogs and elements.
    }
}
