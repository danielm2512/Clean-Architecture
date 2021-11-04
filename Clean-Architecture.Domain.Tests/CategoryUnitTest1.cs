using Clean_Architecture.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Clean_Architecture.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name ");
            action.Should()
                 .NotThrow<Clean_Architecture.Domain.Validation.DomainExecptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name ");
            action.Should()
                .Throw<Clean_Architecture.Domain.Validation.DomainExecptionValidation>()
                 .WithMessage("Invalid Id Value");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<Clean_Architecture.Domain.Validation.DomainExecptionValidation>()
                   .WithMessage("Invalid name, too short, minimun 3 charecters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<Clean_Architecture.Domain.Validation.DomainExecptionValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<Clean_Architecture.Domain.Validation.DomainExecptionValidation>();
        }
    }
}