﻿//-------------------------------------------------------------------------------------------------
// <auto-generated> 
// Marked as auto-generated so StyleCop will ignore BDD style tests
// </auto-generated>
//-------------------------------------------------------------------------------------------------

#pragma warning disable 169
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace RedBadger.Xpf.Specs.Presentation.ElementCollectionSpecs
{
    using Machine.Specifications;

    using Moq;

    public abstract class an_ElementCollection
    {
        protected static Mock<UIElement> Child1;

        protected static Mock<UIElement> Child2;

        protected static ElementCollection ElementCollection;

        protected static Mock<UIElement> Owner;

        private Establish context = () =>
            {
                Child1 = new Mock<UIElement> { CallBase = true };
                Child2 = new Mock<UIElement> { CallBase = true };
                Owner = new Mock<UIElement> { CallBase = true };

                ElementCollection = new ElementCollection(Owner.Object);
            };
    }

    public abstract class an_ElementCollection_as_a_Templated_List
    {
        protected static Mock<UIElement> Owner;

        protected static ITemplatedList<IElement> Subject;

        private Establish context = () =>
            {
                Owner = new Mock<UIElement> { CallBase = true };
                Subject = new ElementCollection(Owner.Object);
            };
    }
}