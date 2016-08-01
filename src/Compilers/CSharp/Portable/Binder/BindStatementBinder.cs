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

            bool hasErrors = false;
            if (i == null)
            {
                hasErrors = true;
                Error(diagnostics, ErrorCode.ERR_InterfaceMemberNotFound, _syntax, _syntax.InterfaceIdentifier);

            }
            if (c == null)
            {
                hasErrors = true;
                Error(diagnostics, ErrorCode.ERR_ClassTypeExpected, _syntax, _syntax.ClassIdentifier);

            }

            var l1 = new List<string>();
            var l2 = new List<string>();

            if (i != null) l1.Add(i.Identifier.ValueText);
            if (c != null) l2.Add(c.Identifier.ValueText);

            var x = l1.ToImmutableArray<string>();
            var y = l2.ToImmutableArray<string>();

            BoundStatement bound = null;
            if (ExpressionStatement != null)
                bound = originalBinder.BindExpressionStatement(ExpressionStatement, diagnostics);
            return new BoundBindStatement(_syntax, x, y, bound, boundBody, hasErrors);

        }
    }
}
