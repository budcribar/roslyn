using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace Microsoft.CodeAnalysis.CSharp
{
    internal sealed class ObjectCreationExpressionBinder : Binder
    {
        private readonly ObjectCreationExpressionSyntax _syntax;
        public ExpressionSyntax Expression { get; set; }
        public ObjectCreationExpressionBinder(Binder enclosing, ObjectCreationExpressionSyntax syntax)
            : base(enclosing)
        {
            _syntax = syntax;
        }

        internal BoundExpression BindObjectCreationExpression(DiagnosticBag diagnostics, Binder originalBinder)
        {
            return BindExpression(Expression, diagnostics);
        }
    }
}
