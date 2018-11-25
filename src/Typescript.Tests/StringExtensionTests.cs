using System;
using System.Text;
using Assent;
using Typescriptr;
using Xunit;

namespace Typescript.Tests
{
    public class StringExtensionTests
    {
        [Fact]
        public void IndentEachLine_NoEmptyLines_ShouldIndentAll()
        {

            var stringToIndent = string.Join(Environment.NewLine, "ABCD".ToCharArray());
            
            var indented = stringToIndent.IndentEachLine("  ");

            this.Assent(indented);
        }

        [Fact]
        public void IndentEachLine_EmptyLines_ShouldntIndentEmptyLines()
        {
            var stringToIndent = "AB" + Environment.NewLine + Environment.NewLine + "CD";

            var indented = stringToIndent.IndentEachLine("  ");

            this.Assent(indented);
        }

        [Fact]
        public void AddNamespace_ApiNamespace_ShouldAddApiNamespace()
        {
            var builder = new StringBuilder();

            foreach (var c in "ABCD".ToCharArray())
                builder.AppendLine(c.ToString());

            var namespaced = builder.AddNamespace("Api", "  ");

            this.Assent(namespaced.ToString());
        }
    }
}