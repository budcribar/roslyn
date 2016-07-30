using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace Microsoft.CodeAnalysis.CSharp
{
    internal sealed class BindStatementBinder : Binder
    {
        private readonly BindStatementSyntax _syntax;
        public ExpressionStatementSyntax ExpressionStatement { get; set; }
        public BindStatementBinder(Binder enclosing, BindStatementSyntax syntax)
            : base(enclosing)
        {
            _syntax = syntax;
        }

        internal override BoundStatement BindBindStatementParts(DiagnosticBag diagnostics, Binder originalBinder)
        {
            BoundStatement boundBody = originalBinder.BindPossibleEmbeddedStatement(_syntax.Statement, diagnostics);

            IdentifierNameSyntax i = _syntax.InterfaceIdentifier as IdentifierNameSyntax;
            IdentifierNameSyntax c = _syntax.ClassIdentifier as IdentifierNameSyntax;

            var x = (new List<string> { i.Identifier.ValueText }).ToImmutableArray<string>();
            var y = (new List<string> { c.Identifier.ValueText }).ToImmutableArray<string>();

            var bound = originalBinder.BindExpressionStatement(ExpressionStatement, diagnostics);
            return new BoundBindStatement(_syntax, x, y, bound, boundBody);

        }
    }
}
