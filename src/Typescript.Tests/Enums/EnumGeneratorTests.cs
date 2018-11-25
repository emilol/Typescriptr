using System;
using Assent;
using Typescriptr;
using Typescriptr.Formatters;
using Xunit;

namespace Typescript.Tests.Enums
{
    public class EnumGeneratorTests
    {
        class TypeWithEnum
        {
            public enum EnumType
            {
                FirstEnum,
                SecondEnum,
                ThirdEnum
            }

            public EnumType AnEnum { get; set; }
        }

        [Fact]
        public void Generator_TypeWithEnum_GeneratesSuccessfully()
        {
            var generator = TypeScriptGenerator.CreateDefault();
            var generated = generator.Generate(new[] {typeof(TypeWithEnum)});

            var result = string.Join($"{Environment.NewLine}---{Environment.NewLine}", generated.Types,
                generated.Enums);

            this.Assent(result);
        }

        [Fact]
        public void Generator_GenerateWithNamespace_GeneratesSuccessfully()
        {
            var generator = TypeScriptGenerator.CreateDefault().WithNamespace("Api", namespaceEnums: true);
            var generated = generator.Generate(new[] {typeof(TypeWithEnum)});

            this.Assent(generated.JoinTypesAndEnums());
        }
        
        class TypeWithNullableEnum
        {
            public enum EnumType
            {
                FirstEnum,
                SecondEnum,
                ThirdEnum,
            }

            public EnumType? NullableEnumProp { get; set; }
        }

        [Fact]
        public void Generator_TypeWithNullableEnum_GeneratesSuccessfully()
        {
            var generator = TypeScriptGenerator.CreateDefault();
            var generated = generator.Generate(new[] {typeof(TypeWithNullableEnum)});

            this.Assent(generated.JoinTypesAndEnums());
        }


        class TypeWithValuedEnum
        {
            public enum EnumType
            {
                First = 1,
                Second = 2,
                Third = 3,
            }
            
            public EnumType EnumWithValueProp { get; set; }
        }

        [Fact]
        public void Generator_TypeWithEnumAndEnumValueFormatter_RendersValues()
        {
            var generator = TypeScriptGenerator.CreateDefault();
            var generated = generator.Generate(new[] {typeof(TypeWithValuedEnum)});

            this.Assent(generated.JoinTypesAndEnums());
        }
    }
}